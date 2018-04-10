using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GeoTetra.Common.Assets
{
    [CreateAssetMenu(fileName = "Curve", menuName = "Curve")]
    public class CurveAsset : ScriptableObject
    {
        [SerializeField]
        private AnimationCurve _curve;

        public AnimationCurve Curve
        {
            get
            {
                return _curve;
            }
        }
    }
}