using UnityEngine;

namespace GeoTetra.GTCommon.ScriptableObjects
{
    public abstract class Variable<T> : ScriptableObject
    {
        [Multiline] 
        [SerializeField]
        private string _developerDescription;

        public abstract T Value { get; set; }
    }
}