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
        public event Action<SubscribableBehaviour> Started;
        
        public event Action<SubscribableBehaviour> Destroyed;

        public Task Starting { get; private set; }

        public RectTransform RectTransform => transform as RectTransform;

        private void Start()
        {
            Starting = StartAsync();
        }

        protected virtual async Task StartAsync()
        {
            Started?.Invoke(this);
        }
        
        protected virtual void OnDestroy()
        {
            Destroyed?.Invoke(this);
        }
    }
}