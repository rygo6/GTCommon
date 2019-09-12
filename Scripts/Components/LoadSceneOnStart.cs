using System;
using System.Collections;
using System.Collections.Generic;
using GeoTetra.GTCommon.Attributes;
using GeoTetra.GTCommon.ScriptableObjects;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace GeoTetra.GTUI
{
    public class LoadSceneOnStart : MonoBehaviour
    {
        [ScenePath]
        [SerializeField] 
        private string _scene;
        private void Start()
        {
            Debug.Log(_scene);
            SceneManager.LoadSceneAsync(_scene, LoadSceneMode.Additive);
        }
    }
}