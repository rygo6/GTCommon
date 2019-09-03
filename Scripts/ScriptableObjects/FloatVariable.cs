using UnityEngine;

namespace GeoTetra.GTCommon.Variables
{
    [CreateAssetMenu]
    public class FloatVariable : Variable<float>
    {
        //This must go here because if it goes in the base type as a T it won't be serialized.
        [SerializeField]
        private float _value;

        public override float Value
        {
            get => _value;
            set => _value = value;
        }
    }
}