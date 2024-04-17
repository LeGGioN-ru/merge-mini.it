using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[Serializable]
public static class IEnumerableExtension
{
    public static bool TryTakeFirstObject<T>(this IEnumerable<Behaviour> list, out T result)
    {
        if (list.FirstOrDefault().TryGetComponent(out T component))
        {
            result = component;
            return true;
        }

        result = default;
        return false;
    }

    public static T GetRandomElement<T>(this IEnumerable<T> list)
    {
        int amountElements = list.Count();
        int randomElement = UnityEngine.Random.Range(0, amountElements);
        return list.ElementAt(randomElement);
    }
}
