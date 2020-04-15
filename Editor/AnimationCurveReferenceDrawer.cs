using UnityEditor;
using UnityEngine;

namespace GeoTetra.GTCommon.ScriptableObjects
{
    [CustomPropertyDrawer(typeof(AnimationCurveReference))]
    public class AnimationCurveReferenceDrawer : VariableReferenceDrawer
    { }
}