using System.Collections.Generic;
//BP
namespace System.Windows.Forms
{
    internal static class EnumerableExtentions
    {
        public static IEnumerable<TSource> Append<TSource>(this IEnumerable<TSource> source, TSource element)
        {
            foreach (var cur in source)
            {
                yield return cur;
            }
            yield return element;
        }
    }
}
