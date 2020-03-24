using UnityEngine;

namespace GeoTetra.GTCommon.Extensions
{
    public static class FloatExtensions
    {
        public static float Snap(this float value, float increment)
        {
            return Mathf.Round(value / increment) * increment;
        }
    }
}