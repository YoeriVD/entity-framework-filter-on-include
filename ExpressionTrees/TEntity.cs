using System.Collections.Generic;

namespace Data
{
	public class TEntity
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public virtual ICollection<TChildEntity> Wheels { get; set; } 
	}
}