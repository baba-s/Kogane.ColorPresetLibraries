using System.IO;
using UnityEditor;

namespace Kogane.Internal
{
    internal static class ColorPresetLibraries
    {
        [MenuItem( "Kogane/ColorPresetLibraries/コピー" )]
        private static void Copy()
        {
            var isOk = EditorUtility.DisplayDialog
            (
                title: "",
                message: "Color Preset Library を「Assets/Editor」フォルダにコピーしますか？",
                ok: "はい",
                cancel: "いいえ"
            );

            if ( !isOk ) return;

            var guidArray = new[]
            {
                "2227df3a0d4df16488a206f5748fe5e3",
                "c06b5879a1bd46b4fb3e2f1ca74a8311",
                "c3dfd73f0921f7e4ebf68d7fd3965712",
                "977b682df8cc06341b03fcf3513932c2",
                "d6b438e5d43d2df42a0bd4226932b245",
            };

            const string directoryName = "Assets/Editor";

            AssetDatabase.StartAssetEditing();

            try
            {
                if ( !AssetDatabase.IsValidFolder( directoryName ) )
                {
                    AssetDatabase.CreateFolder( "Assets", "Editor" );
                }

                foreach ( var guid in guidArray )
                {
                    var assetPath = AssetDatabase.GUIDToAssetPath( guid );
                    var fileName  = Path.GetFileName( assetPath );
                    var newPath   = $"{directoryName}/{fileName}";

                    AssetDatabase.CopyAsset( assetPath, newPath );
                }
            }
            finally
            {
                AssetDatabase.StopAssetEditing();
                AssetDatabase.Refresh();
            }

            EditorUtility.DisplayDialog
            (
                title: "",
                message: "Color Preset Library を「Assets/Editor」フォルダにコピーしました",
                ok: "OK"
            );
        }
    }
}