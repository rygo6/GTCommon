using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GeoTetra.Psikart.Services
{
    public class ColorPallete : MonoBehaviour
    {
        [Serializable]
        public class ColorDefinition
        {
            [SerializeField]
            private string _colorName;

            [SerializeField]
            private Color _colorValue;

            public string ColorName
            {
                get { return _colorName; }
            }

            public Color ColorValue
            {
                get { return _colorValue; }
            }
        }
        
        [SerializeField]
        private List<ColorDefinition> _colorDefinitions = new List<ColorDefinition>();

        public Color GetColor(string colorName)
        {
            ColorDefinition colorDefinition = _colorDefinitions.Find(c => c.ColorName == colorName);
            if (null != colorDefinition)
            {
                return colorDefinition.ColorValue;
            }
            else
            {
                Debug.LogWarning(colorName + " Color not found");
                return Color.black;
            }
        }
    }
}