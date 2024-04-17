using System.Collections;
using System.Collections.Generic;
using System;
using System.Linq;

namespace MiniIT.UTILITY
{
    public static class Validator
    {
        public static void ValidateIEnumerableUnique<T>(IEnumerable<T> collection)
        {
            ValidateNull(collection);

            int uniqueElements = GetAmountUniqueElements(collection);

            if (uniqueElements != collection.Count())
                throw new ArgumentException($"List with type: {typeof(T).Name} have non unique elements");
        }

        private static int GetAmountUniqueElements<T>(IEnumerable<T> collection)
        {
            return collection.Distinct().Count();
        }

        private static void ValidateNull(IEnumerable collection)
        {
            if (collection == null)
            {
                throw new NullReferenceException("Collection in validator must be not null!");
            }
        }
    }

}
