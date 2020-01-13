using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GeoTetra.GTCommon.Components
{
    public class SubscribableBehaviour : MonoBehaviour
    {
        public event Action<SubscribableBehaviour> Destroyed;

        public RectTransform RectTransform => transform as RectTransform;
        
        protected virtual void OnDestroy()
        {
            Destroyed?.Invoke(this);
        }
    }
}