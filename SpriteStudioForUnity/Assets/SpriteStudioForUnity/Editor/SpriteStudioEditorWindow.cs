using UnityEngine;
using UnityEditor;
using System;
using System.IO;
using System.Collections.Generic;
using CurveExtended;

namespace SpriteStudioForUnity
{
	enum Interpolation
	{
		Step,
		Linear
	}

    public class SpriteStudioEditorWindow : EditorWindow
    {
        bool flg = true;
        Vector2 scrollPosition;
        string outputFolderName = "OutputData";
        string projectFilePath;
        int pixelPerUnit = 100;
		Interpolation interpolation = Interpolation.Step;

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
                    outputFolderName = EditorGUILayout.TextField("Output folder", outputFolderName);
                    pixelPerUnit = EditorGUILayout.IntField("Pixel per unit", pixelPerUnit);
					interpolation = (Interpolation)EditorGUILayout.EnumPopup("Curve interpolation", interpolation);
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

			baker.tangentMode = this.interpolation == Interpolation.Step ? TangentMode.Stepped : TangentMode.Linear;

            CreateFolders(baker);
            result = DeserializeProject(baker);

            if (result)
                result = DeserializeCellMaps(baker);
            if (result)
                result = DeserializeEffects(baker);
            if (result)
                result = DeserializeAnimePacks(baker);
            if (result)
                result = CreateTextures(baker);
            if (result)
                result = CreateMaterials(baker);
            if (result)
                result = CreateCellDatas(baker);
            if (result)
                result = CreateEffects(baker);
            if (result)
                result = CreateAnimations(baker);

            AssetDatabase.Refresh();
            EditorUtility.ClearProgressBar();

            if (result)
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
            guid = AssetDatabase.CreateFolder(baker.destDirectory, "Effects");
            baker.effectDirectory = AssetDatabase.GUIDToAssetPath(guid);
            guid = AssetDatabase.CreateFolder(baker.destDirectory, "Animations");
            baker.animationsDirectory = AssetDatabase.GUIDToAssetPath(guid);
            guid = AssetDatabase.CreateFolder(baker.destDirectory, "Prefabs");
            baker.prefabsDirectory = AssetDatabase.GUIDToAssetPath(guid);
        }

        bool DeserializeProject(SpriteStudioBaker baker)
        {
            string message = null;
            try
            {
                message = projectFilePath;
                EditorUtility.DisplayProgressBar("Sprite Studio For Unity", "Deserialize Project : " + projectFilePath, 0.1f);
                baker.DeserializeProject(projectFilePath);
            } catch (Exception e)
            {
                EditorUtility.DisplayDialog("Error", "Deserialize Project : " + message, "OK");
                Debug.Log(e.StackTrace);
                return false;
            }
            return true;
        }

        bool DeserializeCellMaps(SpriteStudioBaker baker)
        {
            baker.cellMapList = new List<SpriteStudioCellMap>();

            if (baker.projectData.cellmapNames == null)
                return true;

            string message = null;
            try
            {
                for (int i = 0; i < baker.projectData.cellmapNames.Length; i++)
                {
                    string cellmapName = baker.projectData.cellmapNames [i];
                    message = cellmapName;
                    EditorUtility.DisplayProgressBar("Sprite Studio For Unity", "Deserialize CellMap(" + (i + 1) + "/" + baker.projectData.cellmapNames.Length + ") : " + cellmapName, 0.2f);
                    baker.DeserializeCellMap(baker.sourceDirectory + "/" + cellmapName);
                }           
            } catch (Exception e)
            {
                EditorUtility.DisplayDialog("Error", "Deserialize CellMap : " + message, "OK");
                Debug.Log(e.StackTrace);
                return false;
            }
            return true;
        }

        bool DeserializeEffects(SpriteStudioBaker baker)
        {
            baker.effectList = new List<SpriteStudioEffect>();

            if (baker.projectData.effectFileNames == null)
                return true;

            string message = null;
            try
            {
                for (int i = 0; i < baker.projectData.effectFileNames.Length; i++)
                {
                    string effectFileName = baker.projectData.effectFileNames [i];
                    message = effectFileName;
                    EditorUtility.DisplayProgressBar("Sprite Studio For Unity", "Deserialize Effect(" + (i + 1) + "/" + baker.projectData.effectFileNames.Length + ") : " + effectFileName, 0.3f);
                    baker.DeserializeEffect(baker.sourceDirectory + "/" + effectFileName);
                }           
            } catch (Exception e)
            {
                EditorUtility.DisplayDialog("Error", "Deserialize Effect : " + message, "OK");
                Debug.Log(e.StackTrace);
                return false;
            }
            return true;
        }

        bool DeserializeAnimePacks(SpriteStudioBaker baker)
        {
            baker.animePackList = new List<SpriteStudioAnimePack>();

            if (baker.projectData.animepackNames == null)
                return true;

            string message = null;
            try
            {
                for (int i = 0; i < baker.projectData.animepackNames.Length; i++)
                {
                    string animepackName = baker.projectData.animepackNames [i];
                    message = animepackName;
                    EditorUtility.DisplayProgressBar("Sprite Studio For Unity", "Deserialize AnimePack(" + (i + 1) + "/" + baker.projectData.animepackNames.Length + ") : " + animepackName, 0.4f);
                    baker.DeserializeAnimePack(baker.sourceDirectory + "/" + animepackName);
                }
            } catch (Exception e)
            {
                EditorUtility.DisplayDialog("Error", "Deserialize AnimePack : " + message, "OK");
                Debug.Log(e.StackTrace);
                return false;
            }
            return true;
        }

        bool CreateTextures(SpriteStudioBaker baker)
        {
            string message = null;

            if (baker.cellMapList == null)
                return true;

            try
            {
                for (int i = 0; i < baker.cellMapList.Count; i++)
                {
                    SpriteStudioCellMap cellMap = baker.cellMapList [i];
                    message = cellMap.imagePath;
                    EditorUtility.DisplayProgressBar("Sprite Studio For Unity", "Create Texture(" + (i + 1) + "/" + baker.cellMapList.Count + ") : " + cellMap.name, 0.5f);
                    baker.CreateTexture(cellMap);
                }
            } catch (Exception e)
            {
                EditorUtility.DisplayDialog("Error", "Create Texture : " + message, "OK");
                Debug.Log(e.StackTrace);
                return false;
            }
            return true;
        }

        bool CreateMaterials(SpriteStudioBaker baker)
        {
            baker.addMaterialDict = new Dictionary<string, Material>();
            baker.mixMaterialDict = new Dictionary<string, Material>();
            baker.mulMaterialDict = new Dictionary<string, Material>();
            baker.subMaterialDict = new Dictionary<string, Material>();                

            if (baker.cellMapList == null)
                return true;

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
            } catch (Exception e)
            {
                EditorUtility.DisplayDialog("Error", "Create Material : " + message, "OK");
                Debug.Log(e.StackTrace);
                return false;
            }
            return true;
        }

        bool CreateCellDatas(SpriteStudioBaker baker)
        {
            baker.cellMaps = new Dictionary<string, List<SpriteStudioCell>>();

            if (baker.cellMapList == null)
                return true;

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
            } catch (Exception e)
            {
                EditorUtility.DisplayDialog("Error", "Create CellData : " + message, "OK");
                Debug.Log(e.StackTrace);
                return false;
            }
            return true;
        }

        bool CreateEffects(SpriteStudioBaker baker)
        {
            if (baker.effectList == null)
                return true;

            string message = null;
            try
            {
                for (int i = 0; i < baker.effectList.Count; i++)
                {
                    SpriteStudioEffect effect = baker.effectList [i];
                    message = effect.name;
                    EditorUtility.DisplayProgressBar("Sprite Studio For Unity", "Create Effect(" + (i + 1) + "/" + baker.effectList.Count + ") : " + effect.name, 0.8f);
                    baker.CreateEffect(effect);
                }
            } catch (Exception e)
            {
                EditorUtility.DisplayDialog("Error", "Create Effect : " + message, "OK");
                Debug.Log(e.StackTrace);
                return false;
            }
            return true;
        }

        bool CreateAnimations(SpriteStudioBaker baker)
        {
            string message = null;

            if (baker.animePackList == null)
                return true;

            try
            {
                for (int i = 0; i < baker.animePackList.Count; i++)
                {
                    SpriteStudioAnimePack animePack = baker.animePackList [i];
                    message = animePack.name;
                    EditorUtility.DisplayProgressBar("Sprite Studio For Unity", "Create Animator(" + (i + 1) + "/" + baker.animePackList.Count + ") : " + animePack.name, 0.9f);
                    baker.CreateAnimator(animePack);
                }
            } catch (Exception e)
            {
                EditorUtility.DisplayDialog("Error", "Create Animator : " + message, "OK");
                Debug.Log(e.StackTrace);
                return false;
            }
            return true;
        }

    }
}

