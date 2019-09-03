using System;
using System.Collections.Generic;
using Partak;
using UnityEngine;

#if UNITY_EDITOR
using UnityEditor;
#endif

namespace GeoTetra.GTCommon.Variables
{
    [CreateAssetMenu]
    public class ComponentContainer : ScriptableObject
    {
#if UNITY_EDITOR
        [Multiline] 
        [SerializeField]
        private string _developerDescription = "";
#endif

        [SerializeField]
        private List<Component> _components = new List<Component>(); //make not editable
        
        private Dictionary<Type, Component> _componentDictionary = new Dictionary<Type, Component>();

        public T Get<T>() where T : Component
        {
            _componentDictionary.TryGetValue(typeof(T), out Component component);
            return (T)component;
        }
        
        public void RegisterComponent(Component component)
        {
            _componentDictionary.Add(component.GetType(), component);
            _components.Add(component);
        }
        
        public void UnregisterComponent(Component component)
        {
            _componentDictionary.Remove(component.GetType());
            _components.Remove(component);
        }
        
        [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
        private void Reset()
        {
            Debug.Log("Reset");
            _components.Clear();
            _componentDictionary.Clear();
        }
    }
}