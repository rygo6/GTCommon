using System;
using System.Reflection.Emit;
using UnityEngine;

namespace GeoTetra.GTCommon.Variables
{
    [Serializable]
    public abstract class Reference<T> 
    {
        [SerializeField]
        protected bool _useConstant = true;
        
        [SerializeField]
        protected T _constantValue;

        public Reference()
        { }

        public Reference(T value)
        {
            _useConstant = true;
            _constantValue = value;
        }
        
        public T Value
        {
            get => _useConstant ? _constantValue : Variable.Value;
            set
            {
                if (_useConstant)
                {
                    _constantValue = value;
                }
                else
                {
                    Variable.Value = value;
                }
            }
        }

        public static implicit operator T(Reference<T> reference)
        {
            return reference.Value;
        }

        protected abstract Variable<T> Variable { get; }
    }
}