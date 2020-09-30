using Rotorz.ReorderableList;
using UnityEngine;
using UnityEditor;
using StansAssets.Plugins.Editor;

namespace StansAssets.Facebook.Editor
{
    /// <summary>
    /// Facebook settings editor window.
    /// </summary>
    public class FbEditorWindow : EditorWindow
    {
        static UnityEditor.Editor s_FacebookSettingsEditor;
        const string k_MyAppsPageUrl = "https://developers.facebook.com/apps/";

        [SerializeField]
        Vector2 m_ScrollPosition;

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
            
            using (new IMGUIBlockWithSpace(new GUIContent("Documentation")))
            {
                using (new IMGUIBeginHorizontal())
                {
                    if (GUILayout.Button("Initialization", GUILayout.Width(150)))
                        Application.OpenURL("https://github.com/StansAssets/com.stansassets.facebook/wiki/Initialization");

                    if (GUILayout.Button("Get Friends", GUILayout.Width(150)))
                        Application.OpenURL("https://github.com/StansAssets/com.stansassets.facebook/wiki/GetFriends");

                    if (GUILayout.Button("Get Profile Url", GUILayout.Width(150)))
                        Application.OpenURL("https://github.com/StansAssets/com.stansassets.facebook/wiki/GetProfileUrl");
                }

                using (new IMGUIBeginHorizontal())
                {
                    if (GUILayout.Button("Get User Info", GUILayout.Width(150)))
                        Application.OpenURL("https://github.com/StansAssets/com.stansassets.facebook/wiki/Get-User-Info");
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
        
        void OnEnable()
        {
            titleContent = new GUIContent(FbPackage.DisplayName);
        }

        void OnGUI()
        {
            using (new IMGUIBeginScrollView(ref m_ScrollPosition))
            {
                DrawSettingsUI();
            }
        }

        static void DrawEmptyScopes()
        {
            EditorGUILayout.LabelField("Each permission has its own set of requirements and usage that are subject to Facebook Platform Policies " +
                "and your own privacy policy.", SettingsWindowStyles.MiniLabel);
        }

        static FbPermissions DrawScopeItem(Rect rect, FbPermissions item) => (FbPermissions)EditorGUI.EnumPopup(rect, item);
    }
}
