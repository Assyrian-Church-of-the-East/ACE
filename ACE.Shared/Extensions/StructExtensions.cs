using System;
using System.Linq;

namespace ACE.Shared.Extensions
{
    public static class StructExtensions
    {
        public static bool In<T>(this T val, params T[] values) where T : struct => values.Contains(val);
    }
}
