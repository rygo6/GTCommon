using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GeoTetra.GTCommon
{
    public class Rotater : MonoBehaviour
    {
        [SerializeField] private Vector3 _rotationAmount;
        private void Update()
        {
            transform.Rotate(_rotationAmount * Time.deltaTime);
        }
    }
}