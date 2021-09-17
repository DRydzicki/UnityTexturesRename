#if UNITY_EDITOR
using System.Linq;
using UnityEngine;
using UnityEditor;

namespace Lero.Tools
{
    public class RenameTexturesOnFolderName : MonoBehaviour
    {
        [MenuItem("Assets/LeroTools/Rename Textures to Folder Name", false, 1100)]
        private static void RenameTexturesBasedOnFolderName()
        {
            RenameTextures(GetFolderName(), GetFolderPath());
        }

        private static string GetFolderName()
        {
            return AssetDatabase.GetAssetPath(Selection.activeInstanceID).Split('/').Last();
        }

        private static string GetFolderPath()
        {
            return AssetDatabase.GetAssetPath(Selection.activeInstanceID);
        }

        private static void RenameTextures(string newName, string folderPath)
        {
            const string type = "t:Texture";
            var textures = AssetDatabase.FindAssets(type, new[] {folderPath});
            foreach (var texture in textures)
            {
                var texturePath = AssetDatabase.GUIDToAssetPath(texture);
                var textureType = texturePath.Split('_').Last();
                AssetDatabase.RenameAsset(texturePath, $"{newName}_{textureType}");
            }
        }
    }
}
#endif
