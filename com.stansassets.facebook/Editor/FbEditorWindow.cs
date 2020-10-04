using StansAssets.Plugins.Editor;
using UnityEngine;

namespace StansAssets.Facebook.Editor
{
    /// <summary>
    /// Facebook settings editor window.
    /// </summary>
    class FbEditorWindow : IMGUISettingsWindow<FbEditorWindow>
    {
        public const string WikiHomeUrl = "https://github.com/StansAssets/com.stansassets.facebook/wiki";
        
        static IMGUIDocumentationBlock s_DocumentationBlock;
        
        protected override void OnAwake()
        {
            titleContent = new GUIContent(FbPackage.DisplayName);
            SetPackageName(FbPackage.PackageName);
            SetDocumentationUrl(WikiHomeUrl);
            
            AddMenuItem("Settings", CreateInstance<FbSettingsTab>());
            AddMenuItem("Documentation", CreateInstance<FbDocumentationTab>());
            AddMenuItem("About", CreateInstance<IMGUIAboutTab>());
        }
    }
}
