using System;
using Data;

namespace ExpressionTrees
{
	internal class Program
	{
		private static void Main(string[] args)
		{
			Queries.FilterOnInclude<Car, Wheel>(car => car.Wheels, wheel => wheel.SizeInInches == 14)
				.ForEach(car => Console.WriteLine($"car : {car.Name} wheels: {car.Wheels.Count}"));
			Console.ReadKey();
		}
	}
}