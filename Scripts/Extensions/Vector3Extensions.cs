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

        public static Vector3 Snap(this Vector3 vector3, float increment)
        {
            return new Vector3(vector3.x.Snap(increment), vector3.y.Snap(increment), vector3.z.Snap(increment));
        }
    }
}