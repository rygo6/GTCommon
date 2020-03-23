using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GeoTetra.GTCommon.Utility
{
    public static class Vector3Utility
    {
        public static Vector3 Clamp(Vector3 vector3, float min, float max)
        {
            return new Vector3(Mathf.Clamp(vector3.x, min, max), Mathf.Clamp(vector3.y, min, max), Mathf.Clamp(vector3.z, min, max));
        }
        
        public static bool Approximately(Vector3 a, Vector3 b)
        {
            return Mathf.Approximately(a.x, b.x) &&
                   Mathf.Approximately(a.y, b.y) &&
                   Mathf.Approximately(a.z, b.z);
        }
        
        public static float RatioBetweenTwo(Vector3 start, Vector3 end, Vector3 point)
        {
            point = ClosestPointOnLine(start, end, point);

            float startDistance = (start - point).sqrMagnitude;
            float endDistance = (end - point).sqrMagnitude;
            float ratio = startDistance / (startDistance + endDistance);

            if (!InFrontOfLine(start, end, point))
            {
                ratio = -ratio;
            }
            else if (!InFrontOfLine(end, start, point))
            {
                ratio = 1 + (1 - ratio);
            }

            return ratio;
        }

        public static Vector3 ClosestPointOnLine(Vector3 lineStart, Vector3 lineEnd, Vector3 point)
        {
            Vector3 startPoint = point - lineStart;
            Vector3 startEnd = lineEnd - lineStart;
            return lineStart + Vector3.Dot(startPoint, startEnd) / Vector3.Dot(startEnd, startEnd) * startEnd;
        }

        /// <summary>
        /// Is point in front of line?
        /// Point must be between lineStart and lineEnd.
        /// Use ClosestPointOnLine to ensure this.
        /// </summary>
        public static bool InFrontOfLine(Vector3 lineStart, Vector3 lineEnd, Vector3 point)
        {
            Vector3 lineSegment = lineEnd - lineStart;
            Vector3 pointSegment = point - lineStart;
            float dot = Vector3.Dot(lineSegment, pointSegment);
            return dot > 0;
        }

        /// <summary>
        /// Determine angle between two vectors with negative value.
        /// </summary>
        public static float AngleSigned(Vector3 vectorA, Vector3 vectorB, Vector3 upVector)
        {
            return Mathf.Atan2(
              Vector3.Dot(upVector, Vector3.Cross(vectorA, vectorB)),
              Vector3.Dot(vectorA, vectorB)) * Mathf.Rad2Deg;
        }

        public static Vector3 TranslatePointAlongDirection(Vector3 point, Vector3 direction, float distance)
        {
            return point + (direction.normalized * distance);
        }

        /// <summary>
        /// Angle around localTransform's y axis.
        /// </summary>
        public static float AngleAroundLocalAxis(Transform localTransform, Vector3 point)
        {
            Vector3 localPoint = localTransform.InverseTransformPoint(point);
            float angle = Mathf.Atan2(localPoint.x, localPoint.z) * Mathf.Rad2Deg;
            return angle;
        }

        //Calculate the intersection point of two lines. Returns true if lines intersect, otherwise false.
        //Note that in 3d, two lines do not intersect most of the time.
        public static bool LineLineIntersection(out Vector3 intersection, Vector3 linePoint1, Vector3 lineVec1, Vector3 linePoint2, Vector3 lineVec2)
        {
            Vector3 lineVec3 = linePoint2 - linePoint1;
            Vector3 crossVec1and2 = Vector3.Cross(lineVec1, lineVec2);
            Vector3 crossVec3and2 = Vector3.Cross(lineVec3, lineVec2);

            float planarFactor = Vector3.Dot(lineVec3, crossVec1and2);

            //is coplanar, and not parrallel
            if (Mathf.Abs(planarFactor) < 0.0001f && crossVec1and2.sqrMagnitude > 0.0001f)
            {
                float s = Vector3.Dot(crossVec3and2, crossVec1and2) / crossVec1and2.sqrMagnitude;
                intersection = linePoint1 + (lineVec1 * s);
                return true;
            }
            else
            {
                intersection = Vector3.zero;
                return false;
            }
        }
    }
}