/*
using UnityEngine;
using UnityEditor;
using SA.Foundation.Editor;
using SA.Foundation.UtilitiesEditor;

namespace SA.Facebook
{
    public class SA_FB_EditorWindow : EditorWindow
    {
        static Editor s_FacebookSettingsEditor;
        static string s_NewPermission = string.Empty;
        const string k_SdkDownloadUrl = "https://developers.facebook.com/docs/unity";
        const string k_MyAppsPageUrl = "https://developers.facebook.com/apps/";

        void OnEnable()
        {
            titleContent = new GUIContent("Facebook");
            minSize = new Vector2(350, 100);
        }

        void OnGUI()
        {
            DrawSettingsUI();
        }

        public static void DrawSettingsUI()
        {
            using (new SA_WindowBlockWithSpace(new GUIContent("Facebook SDK")))
            {
                if (SA_FB.IsSDKInstalled)
                {
                    EditorGUILayout.HelpBox("Facebook SDK Installed!", MessageType.Info);
                    var click = GUILayout.Button("My Apps Page", EditorStyles.miniButton, GUILayout.Width(120));
                    if (click) Application.OpenURL(k_MyAppsPageUrl);
                }
                else
                {
                    EditorGUILayout.HelpBox("Facebook SDK Required!", MessageType.Warning);
                    using (new SA_GuiBeginHorizontal())
                    {
                        GUILayout.FlexibleSpace();
                        var click = GUILayout.Button("Download SDK", EditorStyles.miniButton, GUILayout.Width(120));
                        if (click) Application.OpenURL(k_SdkDownloadUrl);

                        var refreshClick = GUILayout.Button("Refresh", EditorStyles.miniButton, GUILayout.Width(120));
                        if (refreshClick) SA_FB_InstallationProcessing.ProcessAssets();
                    }
                }
            }

            if (!SA_FB.IsSDKInstalled)
                return;

            using (new SA_WindowBlockWithSpace(new GUIContent("SDK Settings")))
            {
                if (s_FacebookSettingsEditor == null)
                {
                    var facebookSettings = Resources.Load("FacebookSettings") as ScriptableObject;
                    if (facebookSettings != null) s_FacebookSettingsEditor = Editor.CreateEditor(facebookSettings);
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
                if (EditorGUI.EndChangeCheck()) SA_EditorUtility.SetDirty(s_FacebookSettingsEditor.target);
            }

            GUI.changed = false;
            using (new SA_WindowBlockWithSpace(new GUIContent("Scopes")))
            {
                SA_EditorGUILayout.ReorderablList(SA_FB_Settings.Instance.Scopes, item => item);

                using (new SA_GuiBeginHorizontal())
                {
                    EditorGUILayout.LabelField("Add new scope: ");
                    s_NewPermission = EditorGUILayout.TextField(s_NewPermission);
                }

                using (new SA_GuiBeginHorizontal())
                {
                    EditorGUILayout.Space();
                    if (GUILayout.Button("Documentation", GUILayout.Width(100))) Application.OpenURL("https://developers.facebook.com/docs/facebook-login/permissions/v2.0");

                    if (GUILayout.Button("Add", GUILayout.Width(100)))
                        if (s_NewPermission != string.Empty)
                        {
                            s_NewPermission = s_NewPermission.Trim();
                            if (!SA_FB_Settings.Instance.Scopes.Contains(s_NewPermission)) SA_FB_Settings.Instance.Scopes.Add(s_NewPermission);
                            s_NewPermission = string.Empty;
                        }
                }

                if (GUI.changed) SA_FB_Settings.Save();
            }
        }
    }
}
*/