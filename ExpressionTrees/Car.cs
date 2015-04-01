using System.Collections.Generic;

namespace ExpressionTrees
{
	public class Car
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public virtual ICollection<Wheel> Wheels { get; set; } 
	}
}