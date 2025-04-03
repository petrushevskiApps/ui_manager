﻿using UnityEngine;

namespace PetrushevskiApps.UIManager.Utilities.Extensions
{
    public static class GameObjectExtensions
    {
        public static void SetLayerRecursively(this GameObject go, int layerNumber)
        {
            foreach (Transform trans in go.GetComponentsInChildren<Transform>(true))
            {
                trans.gameObject.layer = layerNumber;
            }
        }
    }
}