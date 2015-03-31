using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using Data;

namespace ExpressionTrees
{
	internal class Program
	{
		private static void Main(string[] args)
		{
			FilterOnInclude(car => car.Wheels, wheel => wheel.SizeInInches == 14)
				.ForEach(car => Console.WriteLine($"car : {car.Name} wheels: {car.Wheels.Count}"));
		}

		private static IEnumerable<TEntity> FilterOnInclude(
			Expression<Func<TEntity, IEnumerable<TChildEntity>>> propertyExpression, Expression<Func<TChildEntity,bool>> predicateExpression)
		{
			using (var context = new CarContext())
			{
				context.Configuration.LazyLoadingEnabled = false;

				var selector = CreateSelector(propertyExpression, predicateExpression);
				return
					context.Cars.Select(
						selector
						).ToList().Select(e => e.Entity).ToArray();
			}
		}

		private static Expression<Func<TEntity, EntityWithFilteredChildren<TEntity, TChildEntity>>> CreateSelector(
			Expression<Func<TEntity, IEnumerable<TChildEntity>>> propertyExpression, Expression<Func<TChildEntity, bool>> predicateExpression)
		{
			var selectType = typeof(EntityWithFilteredChildren<TEntity, TChildEntity>);

			//bind entity
			var entityValueParam = Expression.Parameter(typeof(TEntity), "entityValue");
			var entityProp = selectType.GetProperty("Entity");
			var entityValueAssignment = Expression.Bind(
				entityProp, entityValueParam);
			//bind collection
			var childrenProp = selectType.GetProperty("Children");
			var descriptionsMemberExpression = (propertyExpression.Body as MemberExpression);
			var descriptionsPropertyInfo = (PropertyInfo)descriptionsMemberExpression.Member;
			var descriptionsProperty = Expression.Property(entityValueParam, descriptionsPropertyInfo);
			//perform where call
			var whereCall = Expression.Call(typeof(Enumerable), "Where",new []{ typeof(TChildEntity) }, descriptionsProperty, predicateExpression);

			var descriptionValueAssignment = Expression.Bind(
				childrenProp, whereCall);

			var ctor = Expression.New(selectType);
			var memberInit = Expression.MemberInit(ctor, entityValueAssignment, descriptionValueAssignment);
			var selector = Expression.Lambda<Func<TEntity, EntityWithFilteredChildren<TEntity, TChildEntity>>>(memberInit, entityValueParam);

			return selector;
		}

		public class EntityWithFilteredChildren<T, TChild>
		{
			public T Entity { get; set; }
			public IEnumerable<TChild> Children { get; set; }
		}
	}
}