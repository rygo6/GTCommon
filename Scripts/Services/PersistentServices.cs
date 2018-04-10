using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

namespace GeoTetra.Common.Services
{
    public class PersistentServices : MonoBehaviour
    {
        [SerializeField]
        private bool _enabled;

        static private PersistentServices _instance;

        [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
        static private void Init()
        {
            Debug.Log("Initializing Persistent Components.");
            PersistentServices prefab = Resources.Load<PersistentServices>("PersistentServices");
            if (prefab._enabled)
            {
                GameObject instance = Instantiate(prefab.gameObject);
                DontDestroyOnLoad(instance);
            }
        }

        static public T Get<T>() where T : Component
        {
            if (null == _instance)
            {
                _instance = FindObjectOfType<PersistentServices>();
            }
            return _instance.GetComponentInChildren<T>();
        }
    }
}
