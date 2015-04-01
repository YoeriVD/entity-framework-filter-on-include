using System.Collections.Generic;

namespace Data
{
	internal class EntityWithFilteredChildren<T, TChild>
	{
		internal T Entity { get; set; }
		internal IEnumerable<TChild> Children { get; set; }
	}
}
