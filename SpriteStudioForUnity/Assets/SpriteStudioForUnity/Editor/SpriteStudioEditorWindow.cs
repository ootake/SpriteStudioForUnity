using UnityEngine;
using UnityEditor;
using System;
using System.IO;
using System.Collections.Generic;

namespace SpriteStudioForUnity
{
    public class SpriteStudioEditorWindow : EditorWindow
    {
        bool flg = true;
        Vector2 scrollPosition;
        string outputFolderName = "OutputData";
        string projectFilePath;
        int pixelPerUnit = 100;

        [MenuItem("Window/SpriteStudioForUnity/Window")]
        static void OpenWindow()
        {
            EditorWindow.GetWindow(typeof(SpriteStudioEditorWindow), false, "SpriteStudioForUnity");
        }

        void PrefsLoad()
        {
            string prefsPath = EditorPrefs.GetString("SPRITE_STUDIO_FILE_PATH", "");
            projectFilePath = System.String.Copy(System.Text.UTF8Encoding.UTF8.GetString(System.Convert.FromBase64String(prefsPath)));
        }
        
        void PrefsSave()
        {
            if (projectFilePath.Length > 0)
            {
                string prefsPath = System.Convert.ToBase64String(System.Text.UTF8Encoding.UTF8.GetBytes(projectFilePath));
                EditorPrefs.SetString("SPRITE_STUDIO_FILE_PATH", prefsPath);
            }
        }

        void OnGUI()
        {
            if (flg)
            {
                flg = false;
                PrefsLoad();
            }

            using (EditorGUILayout.ScrollViewScope scrollView = new EditorGUILayout.ScrollViewScope(scrollPosition))
            {
                scrollPosition = scrollView.scrollPosition;
                using (new EditorGUILayout.VerticalScope())
                {                    
                    outputFolderName = EditorGUILayout.TextField("Output Folder", outputFolderName);
                    pixelPerUnit = EditorGUILayout.IntField("Pixel per unit", pixelPerUnit);
                }
                if (GUILayout.Button("Import"))
                {
                    EditorApplication.delayCall += OpenFilePanel;
                }
            }
        }

        void OpenFilePanel()
        {
            projectFilePath = EditorUtility.OpenFilePanel("Select ssjp file", projectFilePath, "sspj");
            if (projectFilePath.Length == 0)
            {
                EditorUtility.DisplayDialog("Message", "Please select a project file", "OK");
            } else
            {
                PrefsSave();
                EditorApplication.delayCall += Import;
            }
        }

        void Import()
        {
            bool result;

            SpriteStudioBaker baker = new SpriteStudioBaker();
            baker.pixelPerUnit = pixelPerUnit;
            baker.sourceDirectory = Path.GetDirectoryName(projectFilePath);

            CreateFolders(baker);
            result = ParseProject(baker);

            if (result)
                result = ParseCellMaps(baker);
            if (result)
                result = ParseAnimePacks(baker);
            if (result)
                result = CreateTextures(baker);
            if (result)
                result = CreateMaterials(baker);
            if (result)
                result = CreateCellDataS(baker);
            if (result)
                result = CreateAnimations(baker);

            AssetDatabase.Refresh();
            EditorUtility.ClearProgressBar();

            if(result)
                EditorUtility.DisplayDialog("Sprite Studio For Unity", "Complate", "OK");
        }

        void CreateFolders(SpriteStudioBaker baker)
        {
            string guid = AssetDatabase.CreateFolder("Assets", outputFolderName);
            baker.destDirectory = AssetDatabase.GUIDToAssetPath(guid);
            guid = AssetDatabase.CreateFolder(baker.destDirectory, "Textures");
            baker.texturesDirectory = AssetDatabase.GUIDToAssetPath(guid);
            guid = AssetDatabase.CreateFolder(baker.destDirectory, "Materials");
            baker.materialsDirectory = AssetDatabase.GUIDToAssetPath(guid);
            guid = AssetDatabase.CreateFolder(baker.destDirectory, "Cells");
            baker.cellDataDirectory = AssetDatabase.GUIDToAssetPath(guid);
            guid = AssetDatabase.CreateFolder(baker.destDirectory, "Animations");
            baker.animationsDirectory = AssetDatabase.GUIDToAssetPath(guid);
            guid = AssetDatabase.CreateFolder(baker.destDirectory, "Prefabs");
            baker.prefabsDirectory = AssetDatabase.GUIDToAssetPath(guid);
        }

        bool ParseProject(SpriteStudioBaker baker)
        {
            string message = null;
            try
            {
                message = projectFilePath;
                EditorUtility.DisplayProgressBar("Sprite Studio For Unity", "Parse Project : " + projectFilePath, 0.1f);
                baker.GetProjectFile(projectFilePath);
                return true;
            } catch (Exception e)
            {
                EditorUtility.DisplayDialog("Error", "Parse Project : " + message, "OK");
                Debug.Log(e.StackTrace);
                return false;
            }
        }

        bool ParseCellMaps(SpriteStudioBaker baker)
        {
            baker.cellMapList = new List<SpriteStudioCellMap>();

            string message = null;
            try
            {
                for (int i = 0; i < baker.projectData.cellmapNames.Length; i++)
                {
                    string cellmapName = baker.projectData.cellmapNames [i];
                    message = cellmapName;
                    EditorUtility.DisplayProgressBar("Sprite Studio For Unity", "Parse CellMap(" + (i + 1) + "/" + baker.projectData.cellmapNames.Length + ") : " + cellmapName, 0.2f);
                    baker.GetCellMap(baker.sourceDirectory + "/" + cellmapName);
                }           
                return true;
            } catch (Exception e)
            {
                EditorUtility.DisplayDialog("Error", "Parse CellMap : " + message, "OK");
                Debug.Log(e.StackTrace);
                return false;
            }

        }

        bool ParseAnimePacks(SpriteStudioBaker baker)
        {
            baker.animePackList = new List<SpriteStudioAnimePack>();

            string message = null;
            try
            {
                for (int i = 0; i < baker.projectData.animepackNames.Length; i++)
                {
                    string animepackName = baker.projectData.animepackNames [i];
                    message = animepackName;
                    EditorUtility.DisplayProgressBar("Sprite Studio For Unity", "Parse AnimePack(" + (i + 1) + "/" + baker.projectData.animepackNames.Length + ") : " + animepackName, 0.3f);
                    baker.GetAnimePack(baker.sourceDirectory + "/" + animepackName);
                }
                return true;
            } catch (Exception e)
            {
                EditorUtility.DisplayDialog("Error", "Parse AnimePack : " + message, "OK");
                Debug.Log(e.StackTrace);
                return false;
            }
        }

        bool CreateTextures(SpriteStudioBaker baker)
        {
            string message = null;
            try
            {
                for (int i = 0; i < baker.cellMapList.Count; i++)
                {
                    SpriteStudioCellMap cellMap = baker.cellMapList [i];
                    message = cellMap.imagePath;
                    EditorUtility.DisplayProgressBar("Sprite Studio For Unity", "Create Texture(" + (i + 1) + "/" + baker.cellMapList.Count + ") : " + cellMap.name, 0.4f);
                    baker.CreateTexture(cellMap);
                }
                return true;
            } catch (Exception e)
            {
                EditorUtility.DisplayDialog("Error", "Create Texture : " + message, "OK");
                Debug.Log(e.StackTrace);
                return false;
            }
        }

        bool CreateMaterials(SpriteStudioBaker baker)
        {
            baker.addMaterialDict = new Dictionary<string, Material>();
            baker.mixMaterialDict = new Dictionary<string, Material>();
            baker.mulMaterialDict = new Dictionary<string, Material>();
            baker.subMaterialDict = new Dictionary<string, Material>();                

            string message = null;
            try
            {
                for (int i = 0; i < baker.cellMapList.Count; i++)
                {
                    SpriteStudioCellMap cellMap = baker.cellMapList [i];
                    message = cellMap.imagePath;
                    EditorUtility.DisplayProgressBar("Sprite Studio For Unity", "Create Material(" + (i + 1) + "/" + baker.cellMapList.Count + ") : " + cellMap.name, 0.6f);
                    baker.CreateMaterials(cellMap);                    
                }
                return true;
            } catch (Exception e)
            {
                EditorUtility.DisplayDialog("Error", "Create Material : " + message, "OK");
                Debug.Log(e.StackTrace);
                return false;
            }
        }

        bool CreateCellDataS(SpriteStudioBaker baker)
        {
            baker.cellMaps = new Dictionary<string, List<SpriteStudioCell>>();
            int mapId = 0;

            string message = null;
            try
            {
                for (int i = 0; i < baker.cellMapList.Count; i++)
                {
                    SpriteStudioCellMap cellMap = baker.cellMapList [i];
                    message = cellMap.name;
                    EditorUtility.DisplayProgressBar("Sprite Studio For Unity", "Create CellData(" + (i + 1) + "/" + baker.cellMapList.Count + ") : " + cellMap.name, 0.7f);
                    baker.CreateCellData(cellMap, mapId);                  
                    mapId++;
                }
                return true;
            } catch (Exception e)
            {
                EditorUtility.DisplayDialog("Error", "Create CellData : " + message, "OK");
                Debug.Log(e.StackTrace);
                return false;
            }
        }

        bool CreateAnimations(SpriteStudioBaker baker)
        {
            string message = null;
            try
            {
                for (int i = 0; i < baker.animePackList.Count; i++)
                {
                    SpriteStudioAnimePack animePack = baker.animePackList [i];
                    message = animePack.name;
                    EditorUtility.DisplayProgressBar("Sprite Studio For Unity", "Create Animator(" + (i + 1) + "/" + baker.animePackList.Count + ") : " + animePack.name, 0.8f);
                    baker.CreateAnimator(animePack);
                }
                return true;
            } catch (Exception e)
            {
                EditorUtility.DisplayDialog("Error", "Create Animator : " + message, "OK");
                Debug.Log(e.StackTrace);
                return false;
            }
        }

    }
}

