using System;
using System.Collections.Generic;
using GeoTetra.GTCommon.Components;
using UnityEngine;
using Object = UnityEngine.Object;
#if UNITY_EDITOR
using UnityEditor;
#endif

namespace GeoTetra.GTCommon.ScriptableObjects
{
    [CreateAssetMenu(menuName = "GeoTetra/Common/ComponentContainer")]
    public class ComponentContainer : ScriptableObject
    {
#if UNITY_EDITOR
        [Multiline] 
        [SerializeField]
        private string _developerDescription = "";
#endif
        /// <summary>
        /// Loads a default Container via Resources.Load().
        ///
        /// This must be done because if you make a SerializeField reference to a component container that then gets put
        /// into an AssetBundle, the AssetBundle will actually serialize an alternate ComponentContainer ScriptableObject
        /// and not end up using the one in the project that everything else use. You could conversely put a ComponentContainer
        /// in an AssetBundle and have them all load that one too. 
        /// </summary>
//        public static ComponentContainer DefaultContainer(SubscribableBehaviour registerBehavior = null)
//        {
//            ComponentContainer container = Resources.Load<ComponentContainer>("ComponentContainer");
//            if (registerBehavior != null) container.RegisterComponent(registerBehavior);
//            return container;
//        }
        
//        [SerializeField]
//        private List<ScriptableObject> _preloadComponents = new List<ScriptableObject>();
        private readonly Dictionary<System.Type, Object> _objectDictionary = new Dictionary<System.Type, Object>();

        private void Awake()
        {
            LoadDictionary();
        }

        private void OnValidate()
        {
            LoadDictionary();
        }

        private void Reset()
        {
            LoadDictionary();
        }

        private void LoadDictionary()
        {
            _objectDictionary.Clear();
//            for (int i = 0; i < _preloadComponents.Count; ++i)
//            {
//                _objectDictionary.Add(_preloadComponents[i].GetType(), _preloadComponents[i]);
//            }
        }

        public void Populate<T>(out T reference) where T : Object
        {
            reference = Get<T>();
        }
        
        public T Get<T>() where T : Object
        {
            _objectDictionary.TryGetValue(typeof(T), out Object returnObject);
            return (T)returnObject;
        }

        public void RegisterComponent(SubscribableBehaviour behaviour)
        {
            _objectDictionary.Add(behaviour.GetType(), behaviour);
            behaviour.Destroyed += UnregisterComponent;
        }

        public void UnregisterComponent(Object unregisterObject)
        {
            Debug.Log("Unregistering " + unregisterObject);
            _objectDictionary.Remove(unregisterObject.GetType());
        }
    }
}