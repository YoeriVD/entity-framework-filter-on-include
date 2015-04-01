using System;
using System.Collections.Generic;
using System.Linq;

namespace Data
{
	public static class EnumerableExtentions
	{
		public static IEnumerable<T> ForEach<T>(this IEnumerable<T> enumerable, Action<T> action)
		{
			var forEach = enumerable as T[] ?? enumerable.ToArray();
			foreach (var item in forEach)
			{
				action(item);
			}
			return forEach;
		}
	}
}