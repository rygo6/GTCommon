using System;
using UnityEngine;

namespace GeoTetra.GTCommon.Variables
{
    [Serializable]
    public class FloatReference : Reference<float>
    {
        //This must go here because if it goes in the base type as a Variable<T> it won't be serialized.
        [SerializeField] private FloatVariable _variable;

        protected override Variable<float> Variable => _variable;
    }
}