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
		static void OpenWindow ()
		{
			EditorWindow.GetWindow (typeof(SpriteStudioEditorWindow), false, "SpriteStudioForUnity");
		}

		void PrefsLoad ()
		{
			string prefsPath = EditorPrefs.GetString ("PROJECT_FILE_PATH", "");
			projectFilePath = System.String.Copy (System.Text.UTF8Encoding.UTF8.GetString (System.Convert.FromBase64String (prefsPath)));
		}
		
		void PrefsSave ()
		{
			if (projectFilePath.Length > 0) {
				string prefsPath = System.Convert.ToBase64String (System.Text.UTF8Encoding.UTF8.GetBytes (projectFilePath));
				EditorPrefs.SetString ("PROJECT_FILE_PATH", prefsPath);
			}
		}

		void OnGUI ()
		{
			if (flg) {
				flg = false;
				PrefsLoad ();
			}

			using (EditorGUILayout.ScrollViewScope scrollView = new EditorGUILayout.ScrollViewScope(scrollPosition)) {
				scrollPosition = scrollView.scrollPosition;
				using (new EditorGUILayout.VerticalScope()) {					 
					outputFolderName = EditorGUILayout.TextField ("Output Folder", outputFolderName);
					pixelPerUnit = EditorGUILayout.IntField ("Pixel per unit", pixelPerUnit);
				}
				if (GUILayout.Button ("Import")) {
					EditorApplication.delayCall += OpenFilePanel;
				}
			}
		}

		void OpenFilePanel ()
		{
			projectFilePath = EditorUtility.OpenFilePanel ("Select ssjp file", projectFilePath, "sspj");
			if (projectFilePath.Length == 0) {
				EditorUtility.DisplayDialog ("Message", "Please select a project file", "OK");
			} else {
				PrefsSave ();
				EditorApplication.delayCall += Import;
			}
		}

		void Import ()
		{
			try {
				string guid = AssetDatabase.CreateFolder ("Assets", outputFolderName);
				
				SpriteStudioBaker baker = new SpriteStudioBaker ();
				baker.destDirectory = AssetDatabase.GUIDToAssetPath (guid);
				guid = AssetDatabase.CreateFolder (baker.destDirectory, "Textures");
				baker.texturesDirectory = AssetDatabase.GUIDToAssetPath (guid);
				guid = AssetDatabase.CreateFolder (baker.destDirectory, "Materials");
				baker.materialsDirectory = AssetDatabase.GUIDToAssetPath (guid);
				guid = AssetDatabase.CreateFolder (baker.destDirectory, "Cells");
				baker.cellDataDirectory = AssetDatabase.GUIDToAssetPath (guid);
				guid = AssetDatabase.CreateFolder (baker.destDirectory, "Animations");
				baker.animationsDirectory = AssetDatabase.GUIDToAssetPath (guid);
				guid = AssetDatabase.CreateFolder (baker.destDirectory, "Prefabs");
				baker.prefabsDirectory = AssetDatabase.GUIDToAssetPath (guid);

				baker.pixelPerUnit = pixelPerUnit;
				baker.sourceDirectory = Path.GetDirectoryName (projectFilePath);

				EditorUtility.DisplayProgressBar ("Sprite Studio For Unity", "Parse Project : " + projectFilePath, 0.1f);
				baker.GetProjectFile (projectFilePath);

				baker.cellMapList = new List<SpriteStudioCellMap> ();
				for (int i = 0; i < baker.projectData.cellmapNames.Length; i++) {
					string cellmapName = baker.projectData.cellmapNames [i];
					EditorUtility.DisplayProgressBar ("Sprite Studio For Unity", "Parse CellMap(" + (i + 1) + "/" + baker.projectData.cellmapNames.Length + ") : " + cellmapName, 0.2f);
					baker.GetCellMap (baker.sourceDirectory + "/" + cellmapName);
				}			

				baker.animePackList = new List<SpriteStudioAnimePack> ();
				for (int i = 0; i < baker.projectData.animepackNames.Length; i++) {
					string animepackName = baker.projectData.animepackNames [i];
					EditorUtility.DisplayProgressBar ("Sprite Studio For Unity", "Parse AnimePack(" + (i + 1) + "/" + baker.projectData.animepackNames.Length + ") : " + animepackName, 0.3f);
					baker.GetAnimePack (baker.sourceDirectory + "/" + animepackName);
				}
				
				for (int i = 0; i < baker.cellMapList.Count; i++) {
					SpriteStudioCellMap cellMap = baker.cellMapList [i];
					EditorUtility.DisplayProgressBar ("Sprite Studio For Unity", "Create Texture(" + (i + 1) + "/" + baker.cellMapList.Count + ") : " + cellMap.name, 0.4f);
					baker.CreateTexture (cellMap);
				}

				baker.addMaterialDict = new Dictionary<string, Material> ();
				baker.mixMaterialDict = new Dictionary<string, Material> ();
				baker.mulMaterialDict = new Dictionary<string, Material> ();
				baker.subMaterialDict = new Dictionary<string, Material> ();				
				for (int i = 0; i < baker.cellMapList.Count; i++) {
					SpriteStudioCellMap cellMap = baker.cellMapList [i];
					EditorUtility.DisplayProgressBar ("Sprite Studio For Unity", "Create Material(" + (i + 1) + "/" + baker.cellMapList.Count + ") : " + cellMap.name, 0.6f);
					baker.CreateMaterials (cellMap);					
				}

				baker.cellMaps = new Dictionary<string, List<SpriteStudioCell>> ();
				int mapId = 0;
				for (int i = 0; i < baker.cellMapList.Count; i++) {
					SpriteStudioCellMap cellMap = baker.cellMapList [i];
					EditorUtility.DisplayProgressBar ("Sprite Studio For Unity", "Create CellData(" + (i + 1) + "/" + baker.cellMapList.Count + ") : " + cellMap.name, 0.7f);
					baker.CreateCellData (cellMap, mapId);					
					mapId++;
				}
				for (int i = 0; i < baker.animePackList.Count; i++) {
					SpriteStudioAnimePack animePack = baker.animePackList [i];
					EditorUtility.DisplayProgressBar ("Sprite Studio For Unity", "Create Animator(" + (i + 1) + "/" + baker.animePackList.Count + ") : " + animePack.name, 0.8f);
					baker.CreateAnimator (animePack);
				}

				EditorUtility.ClearProgressBar ();
				EditorUtility.DisplayDialog ("Sprite Studio For Unity", "Complate", "OK");
			} catch (Exception e) {
				EditorUtility.ClearProgressBar ();
				Debug.Log (e.StackTrace);
			} finally {
				AssetDatabase.Refresh ();
			}
		}
	}
}

