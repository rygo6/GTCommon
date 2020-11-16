using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

namespace GeoTetra.GTCommon.Components
{
    /// <summary>
    /// Custom extension of MonoBehavior that includes extra functionality.
    /// </summary>
    public class SubscribableBehaviour : MonoBehaviour
    {
        public event Action<SubscribableBehaviour> Initialized;
        
        public event Action<SubscribableBehaviour> Destroyed;

        public RectTransform RectTransform => transform as RectTransform;

        protected async void Start()
        {
            await
            Initialize();
        }

        protected async virtual Task Initialize()
        {
            Initialized?.Invoke(this);
        }
        
        protected virtual void OnDestroy()
        {
            Destroyed?.Invoke(this);
        }
    }
}