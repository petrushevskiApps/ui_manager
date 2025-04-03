using System.Collections.Generic;
using PetrushevskiApps.UIManager.Utilities.Extensions;
using UnityEngine;

namespace MenuManager.Scripts.Components.NonInteractive
{
    public class UIObjectPresenter : MonoBehaviour, IUIObjectPresenter
    {
        private const string LAYER_NAME = "Island";

        [SerializeField] 
        private Transform _loadedParent;
        [SerializeField] 
        private Transform _unloadedParent;
        
        // Internal
        private GameObject _loadedObject;
        private readonly Dictionary<string, GameObject> _unloadedObjects = new();
        
        public void LoadObject(GameObject prefab)
        {
            if (_loadedObject != null)
            {
                if (_loadedObject.name.Equals(prefab.name))
                {
                    return;
                }
                UnloadObject();
            }
            if (_unloadedObjects.ContainsKey(prefab.name))
            {
                _loadedObject = _unloadedObjects[prefab.name];
                _unloadedObjects.Remove(prefab.name);
            }
            else
            {
                _loadedObject = Instantiate(prefab);
                _loadedObject.SetLayerRecursively(LayerMask.NameToLayer(LAYER_NAME));
            }
            
            _loadedObject.SetActive(true);
            _loadedObject.transform.SetParent(_loadedParent, false);
            _loadedObject.transform.localPosition = Vector3.zero;
            _loadedObject.transform.localRotation = Quaternion.identity;
        }

        public void UnloadObject()
        {
            _loadedObject.transform.SetParent(_unloadedParent, false);
            _loadedObject.SetActive(false);
            _unloadedObjects.Add(_loadedObject.name, _loadedObject);
            _loadedObject = null;
        }

        public void ToggleActivity(bool isActive)
        {
            gameObject.SetActive(isActive);
        }
    }
}