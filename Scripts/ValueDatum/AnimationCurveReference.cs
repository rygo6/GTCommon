using System;
using UnityEngine;

namespace GeoTetra.GTCommon.ScriptableObjects
{
    [Serializable]
    public class AnimationCurveReference : Reference<AnimationCurve>
    {
        //This must go here because if it goes in the base type as a Variable<T> it won't be serialized.
        [SerializeField] private AnimationCurveVariable _variable;

        protected override Variable<AnimationCurve> Variable => _variable;
    }
}