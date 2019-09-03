using UnityEngine;
using System.Collections;

namespace GeoTetra.GTCommon.Extensions
{
    public static class Vector3Extensions
    {
        public static Vector3 RotateAroundPivot(this Vector3 Point, Vector3 Pivot, Quaternion Angle)
        {
            return Angle * (Point - Pivot) + Pivot;
        }
    }
}