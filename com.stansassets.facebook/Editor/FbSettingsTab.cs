using System;
using Rotorz.ReorderableList;
using StansAssets.Plugins.Editor;
using UnityEditor;
using UnityEngine;

namespace StansAssets.Facebook.Editor
{
    [Serializable]
    class FbSettingsTab : IMGUILayoutElement
    {
        static UnityEditor.Editor s_FacebookSettingsEditor;
        const string k_MyAppsPageUrl = "https://developers.facebook.com/apps/";

        /// <summary>
        /// In case you need to draw the Facebook settings editor window UI inside
        /// your Editor interface, you may used this method.
        /// Please note that method should be called during the OnGUI loop,
        /// </summary>
        public static void DrawSettingsUI()
        {
            using (new IMGUIBlockWithSpace(new GUIContent("Facebook SDK")))
            {
                var click = GUILayout.Button("My Apps Page", EditorStyles.miniButton, GUILayout.Width(120));
                if (click) Application.OpenURL(k_MyAppsPageUrl);

                ReorderableListGUI.Title("Permission Scopes");
                ReorderableListGUI.ListField(FbSettings.Permissions, DrawScopeItem, DrawEmptyScopes);
                using (new IMGUIBeginHorizontal())
                {
                    EditorGUILayout.Space();
                    if (GUILayout.Button("Permissions Reference", GUILayout.Width(150)))
                        Application.OpenURL("https://developers.facebook.com/docs/facebook-login/permissions/v2.0");
                }
            }

            using (new IMGUIBlockWithSpace(new GUIContent("Default SDK Settings")))
            {
                if (s_FacebookSettingsEditor == null)
                {
                    var facebookSettings = Resources.Load("FacebookSettings") as ScriptableObject;
                    if (facebookSettings != null) s_FacebookSettingsEditor = UnityEditor.Editor.CreateEditor(facebookSettings);
                }

                if (s_FacebookSettingsEditor == null)
                {
                    EditorGUILayout.HelpBox("Facebook Settings Resources can't be located! " +
                        "Try to use Facebook plugin top menu in order to trigger Settings Resources creation.",
                        MessageType.Warning);
                    return;
                }

                EditorGUI.BeginChangeCheck();
                s_FacebookSettingsEditor.OnInspectorGUI();
                if (EditorGUI.EndChangeCheck())
                    EditorUtility.SetDirty(s_FacebookSettingsEditor.target);
            }
        }

        static void DrawEmptyScopes()
        {
            EditorGUILayout.LabelField("Each permission has its own set of requirements and usage that are subject to Facebook Platform Policies " +
                "and your own privacy policy.", SettingsWindowStyles.MiniLabel);
        }

        static FbPermissions DrawScopeItem(Rect rect, FbPermissions item) => (FbPermissions)EditorGUI.EnumPopup(rect, item);

        public override void OnGUI()
        {
            DrawSettingsUI();
        }
    }
}
