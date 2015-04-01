using System.Collections.Generic;
using System.Data.Entity;

namespace ExpressionTrees
{
	public class CarContext : DbContext
	{
		public DbSet<Car> Cars { get; set; }
		public DbSet<Wheel> Wheels { get; set; }

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
				new Car {Name = "Car1", Wheels = new List<Wheel>() {new Wheel() {SizeInInches = 14}, new Wheel() { SizeInInches = 15 }, new Wheel() { SizeInInches = 16 },new Wheel() { SizeInInches = 17 } } },
				new Car {Name = "Car2", Wheels = new List<Wheel>() {new Wheel() {SizeInInches = 14}, new Wheel() { SizeInInches = 15 }, new Wheel() { SizeInInches = 16 },new Wheel() { SizeInInches = 17 } } },
				new Car {Name = "Car3", Wheels = new List<Wheel>() {new Wheel() {SizeInInches = 14}, new Wheel() { SizeInInches = 15 }, new Wheel() { SizeInInches = 16 },new Wheel() { SizeInInches = 17 } } },
				new Car {Name = "Car4", Wheels = new List<Wheel>() {new Wheel() {SizeInInches = 14}, new Wheel() { SizeInInches = 15 }, new Wheel() { SizeInInches = 16 },new Wheel() { SizeInInches = 17 } } },
				new Car {Name = "Car5", Wheels = new List<Wheel>() {new Wheel() {SizeInInches = 14}, new Wheel() { SizeInInches = 15 }, new Wheel() { SizeInInches = 16 },new Wheel() { SizeInInches = 17 } } },
				new Car {Name = "Car6", Wheels = new List<Wheel>() {new Wheel() {SizeInInches = 14}, new Wheel() { SizeInInches = 15 }, new Wheel() { SizeInInches = 16 },new Wheel() { SizeInInches = 17 } } }
			});
			base.Seed(context);
		}
	}
}