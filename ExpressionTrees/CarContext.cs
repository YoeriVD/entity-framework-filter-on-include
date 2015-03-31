using System.Collections.Generic;
using System.Data.Entity;
using ExpressionTrees;

namespace Data
{
	public class CarContext : DbContext
	{
		public DbSet<TEntity> Cars { get; set; }
		public DbSet<TChildEntity> Wheels { get; set; }

		public CarContext()
		{
			Database.SetInitializer(new CarInitializer());
		}
	}

	internal class CarInitializer : DropCreateDatabaseAlways<CarContext>
	{
		protected override void Seed(CarContext context)
		{
			context.Cars.AddRange(new[]
			{
				new TEntity {Name = "Car1", Wheels = new List<TChildEntity>() {new TChildEntity() {SizeInInches = 14}, new TChildEntity() { SizeInInches = 15 }, new TChildEntity() { SizeInInches = 16 },new TChildEntity() { SizeInInches = 17 } } },
				new TEntity {Name = "Car2", Wheels = new List<TChildEntity>() {new TChildEntity() {SizeInInches = 14}, new TChildEntity() { SizeInInches = 15 }, new TChildEntity() { SizeInInches = 16 },new TChildEntity() { SizeInInches = 17 } } },
				new TEntity {Name = "Car3", Wheels = new List<TChildEntity>() {new TChildEntity() {SizeInInches = 14}, new TChildEntity() { SizeInInches = 15 }, new TChildEntity() { SizeInInches = 16 },new TChildEntity() { SizeInInches = 17 } } },
				new TEntity {Name = "Car4", Wheels = new List<TChildEntity>() {new TChildEntity() {SizeInInches = 14}, new TChildEntity() { SizeInInches = 15 }, new TChildEntity() { SizeInInches = 16 },new TChildEntity() { SizeInInches = 17 } } },
				new TEntity {Name = "Car5", Wheels = new List<TChildEntity>() {new TChildEntity() {SizeInInches = 14}, new TChildEntity() { SizeInInches = 15 }, new TChildEntity() { SizeInInches = 16 },new TChildEntity() { SizeInInches = 17 } } },
				new TEntity {Name = "Car6", Wheels = new List<TChildEntity>() {new TChildEntity() {SizeInInches = 14}, new TChildEntity() { SizeInInches = 15 }, new TChildEntity() { SizeInInches = 16 },new TChildEntity() { SizeInInches = 17 } } }
			});
			base.Seed(context);
		}
	}
}