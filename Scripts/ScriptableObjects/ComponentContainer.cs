using System.Collections.Generic;
using GeoTetra.GTCommon.Components;
using UnityEngine;
#if UNITY_EDITOR
using UnityEditor;
#endif

namespace GeoTetra.GTCommon.ScriptableObjects
{
    [CreateAssetMenu(menuName = "Partak/ComponentContainer")]
    public class ComponentContainer : ScriptableObject
    {
#if UNITY_EDITOR
        [Multiline] 
        [SerializeField]
        private string _developerDescription = "";
#endif
        
        [SerializeField]
        private List<Component> _components = new List<Component>(); //make not editable, for debugging, or read dict in editor class
        
        private readonly Dictionary<System.Type, Component> _componentDictionary = new Dictionary<System.Type, Component>();

        private void OnValidate()
        {
            _componentDictionary.Clear();
        }

        public void Populate<T>(out T reference) where T : Component
        {
            reference = Get<T>();
        }
        
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
        
        public void RegisterComponent(SubscribableBehaviour behaviour)
        {
            _componentDictionary.Add(behaviour.GetType(), behaviour);
            _components.Add(behaviour);
            behaviour.Destroyed += UnregisterComponent;
        }

        public void UnregisterComponent(Component component)
        {
            _componentDictionary.Remove(component.GetType());
            _components.Remove(component);
        }
    }
}