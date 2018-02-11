using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using ElementCollection.Infracture.Models;

namespace ElementCollection.Engine.FilterExtensions
{
    public static class ElementFilter
    {
        public static Collection<Element> FilterUniqueNumAndAgeBiggerThan20(this IEnumerable<Element> elements, int minAge = 20)
        {
            if (elements == null)
            {
                throw new ArgumentNullException(nameof(elements));
            }

            return new Collection<Element>(
                elements
                    .Where(x => x.Age > minAge)
                    .GroupBy(x => x.Num)
                    .Select(grp => grp.First()).ToList()
            );
        }
    }
}
