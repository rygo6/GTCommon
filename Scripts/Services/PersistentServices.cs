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

        private static PersistentServices _instance;

//        [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
//        static private void Init()
//        {
//            Debug.Log("Initializing Persistent Components.");
//            PersistentServices prefab = Resources.Load<PersistentServices>("PersistentServices");
//            if (prefab._enabled)
//            {
//                GameObject instance = Instantiate(prefab.gameObject);
//                DontDestroyOnLoad(instance);
//            }
//        }

        public static T Get<T>() where T : Component
        {
            if (null == _instance)
            {
                _instance = FindObjectOfType<PersistentServices>();
            }
            return _instance.GetComponentInChildren<T>();
        }
    }
}
