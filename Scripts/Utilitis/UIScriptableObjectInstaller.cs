using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace PetrushevskiApps.UIManager.Utilities
{
    [CreateAssetMenu(
        fileName = "ScriptableObjectInstaller",
        menuName = "Configuration/ScriptableObjectInstaller")]
    public class MainScriptableObjectInstaller : ScriptableObjectInstaller<MainScriptableObjectInstaller>
    {
        [SerializeField]
        private List<ScriptableObject> _scriptableObjectsToBind;

        public override void InstallBindings()
        {
            foreach (ScriptableObject scriptableObject in _scriptableObjectsToBind)
            {
                Container
                    .BindInterfacesTo(scriptableObject.GetType())
                    .FromInstance(scriptableObject);
                Container.QueueForInject(scriptableObject);
            }
        }
    }
}