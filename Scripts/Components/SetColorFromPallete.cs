using System.Collections;
using System.Collections.Generic;
using GeoTetra.Common.Services;
using GeoTetra.Common.UnityEvents;
using GeoTetra.Psikart.Services;
using UnityEngine;

namespace GeoTetra.Common.Components
{
	public class SetColorFromPallete : MonoBehaviour
	{
		[SerializeField]
		private string _colorName;
		
		[SerializeField]
		private ColorUnityEvent _applyColor;

		private void Start()
		{
			Color color = PersistentServices.Get<ColorPallete>().GetColor(_colorName);
			_applyColor.Invoke(color);
		}
	}
}