using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GeoTetra.GTCommon.Types
{
    [System.Serializable]
    public class SerializableList<T>
    {
        [SerializeField]
        private List<T> _serializedList = new List<T>();

        public List<T> SerializedList
        {
            get { return _serializedList; }
        }
    }
}
