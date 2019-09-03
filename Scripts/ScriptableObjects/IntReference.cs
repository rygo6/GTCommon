using System;
using UnityEngine;

namespace GeoTetra.GTCommon.Variables
{
    [Serializable]
    public class IntReference : Reference<int>
    {
        //This must go here because if it goes in the base type as a Variable<T> it won't be serialized.
        [SerializeField] private IntVariable _variable;

        protected override Variable<int> Variable => _variable;
    }
}