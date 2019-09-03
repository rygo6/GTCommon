using UnityEngine;

namespace GeoTetra.GTCommon.Variables
{
    public abstract class Variable<T> : ScriptableObject
    {
#if UNITY_EDITOR
        [Multiline] 
        [SerializeField]
        private string _developerDescription = "";
#endif

        public abstract T Value { get; set; }
    }
}