using System;
using System.Collections;
using System.Collections.Generic;
using GeoTetra.GTCommon.Attributes;
using GeoTetra.GTCommon.ScriptableObjects;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.SceneManagement;

namespace GeoTetra.GTUI
{
    public class LoadSceneOnStart : MonoBehaviour
    {
        [SerializeField] private SceneLoadSystem _sceneLoadSystem;
        [SerializeField] private AssetReference _sceneReference;
        
        private void Start()
        {
            _sceneLoadSystem.Load(null, _sceneReference);
        }
    }
}