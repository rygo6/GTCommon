using UnityEngine;

namespace GeoTetra.GTCommon.ScriptableObjects
{
    [CreateAssetMenu]
    public class AnimationCurveVariable : Variable<AnimationCurve>
    {
        //This must go here because if it goes in the base type as a T it won't be serialized.
        [SerializeField]
        private AnimationCurve _value;

        public override AnimationCurve Value
        {
            get => _value;
            set => _value = value;
        }
    }
}