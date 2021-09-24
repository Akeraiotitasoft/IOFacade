using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Akeraiotitasoft.IOFacade.Mock.Extensions
{
    internal static class EnumerableExtensions
    {
        public static void ForEach<T>(this IEnumerable<T> enumerable, Action<T> action)
        {
            if (enumerable == null) throw new ArgumentNullException(nameof(enumerable), "enumerable cannot be null");
            if (enumerable == null) throw new ArgumentNullException(nameof(action), "action cannot be null");
            foreach (T item in enumerable)
            {
                action(item);
            }
        }
    }
}
