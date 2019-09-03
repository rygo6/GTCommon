using UnityEngine;

namespace GeoTetra.GTCommon.Variables
{
    [CreateAssetMenu]
    public class IntVariable : Variable<int>
    {
        //This must go here because if it goes in the base type as a T it won't be serialized.
        [SerializeField]
        private int _value;

        public override int Value
        {
            get => _value;
            set => _value = value;
        }
    }
}