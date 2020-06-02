/*

using System;
using UnityEngine;
using UnityEditor;
using SA.Foundation.Config;

namespace SA.Facebook
{
    class SA_FB_EditorMenu : MonoBehaviour
    {
        [MenuItem(SA_Config.EditorMenuRoot + "Facebook/Settings", false, 500)]
        public static void EditSettings()
        {
            //We want to dock next to the Unity Inspector window
            var inspectorType = Type.GetType("UnityEditor.InspectorWindow, UnityEditor.dll");
            EditorWindow.GetWindow<SA_FB_EditorWindow>(new Type[] { inspectorType });
        }
    }
}
*/