using System;
using System.Collections.Generic;

namespace TwoOneTwoGames.UIManager.Utilities.Extensions
{
    public static class ListExtensions
    {
        public static List<T> SafeGetRange<T>(this List<T> list, int index, int count)
        {
            if (list == null || list.Count == 0 || index >= list.Count)
                return new List<T>();

            if (index < 0)
                index = 0;

            if (count < 0)
                count = 0;

            // Calculate how many items can be returned safely
            int safeCount = Math.Min(count, list.Count - index);

            return list.GetRange(index, safeCount);
        }
    }

}