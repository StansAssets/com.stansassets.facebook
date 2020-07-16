using SA.Facebook;
using StansAssets.Plugins.Editor;
using UnityEditor;

namespace StansAssets.Facebook.Editor
{
    static class FbEditorMenu
    {
        [MenuItem(PackagesConfigEditor.RootMenu + "/" + FbPackage.DisplayName, false, 500)]
        public static void EditSettings()
        {
            EditorWindowUtils.OpenAndDockNextToInspector<FbEditorWindow>();
        }
    }
}
