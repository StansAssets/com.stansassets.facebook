using System;
using StansAssets.Plugins.Editor;

namespace StansAssets.Facebook.Editor
{
    [Serializable]
    class FbDocumentationTab : IMGUILayoutElement
    {
        static IMGUIDocumentationBlock s_DocumentationBlock;

        static IMGUIDocumentationBlock DocumentationBlock
        {
            get
            {
                if (s_DocumentationBlock == null)
                {
                    s_DocumentationBlock = new IMGUIDocumentationBlock();
                    s_DocumentationBlock.AddDocumentationUrl("Initialization", "https://github.com/StansAssets/com.stansassets.facebook/wiki/Initialization");
                    s_DocumentationBlock.AddDocumentationUrl("Get User Info", "https://github.com/StansAssets/com.stansassets.facebook/wiki/Get-User-Info");
                    s_DocumentationBlock.AddDocumentationUrl("Get Friends", "https://github.com/StansAssets/com.stansassets.facebook/wiki/GetFriends");
                    s_DocumentationBlock.AddDocumentationUrl("Get Profile Url", "https://github.com/StansAssets/com.stansassets.facebook/wiki/GetProfileUrl");
                    
                    s_DocumentationBlock.AddSampleScene("General Sample", $"{FbPackageEditor.SamplesPath}/General/SA_FB_ExampleScene.unity");
                    
                }

                return s_DocumentationBlock;
            }
        }

        public override void OnGUI()
        {
            DocumentationBlock.Draw();
        }
    }
}
