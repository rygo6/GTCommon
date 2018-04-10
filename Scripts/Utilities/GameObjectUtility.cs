using UnityEngine;
using System.Collections;

namespace GeoTetra.Common.Utility
{
    static public class GameObjectUtility
    {
        static public T FindGameObjectOfTypeOnTypeNamedGameObject<T>()
        {
            string[] elements = typeof(T).ToString().Split('.');
            return GameObject.Find(elements[elements.Length - 1]).GetComponent<T>();
        }
    }
}