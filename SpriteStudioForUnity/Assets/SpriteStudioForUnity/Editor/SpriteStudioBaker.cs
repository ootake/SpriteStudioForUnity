using UnityEngine;
using UnityEditor;
using UnityEditor.Animations;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Linq;
using System.Xml.Serialization;
using CurveExtended;

namespace SpriteStudioForUnity
{
	public static class Extensions
	{
		public static TangentMode ToTangentMode (this string s)
		{
			switch (s) {
			case "linear":
				return TangentMode.Linear;
			default:
				return TangentMode.Stepped;
			}
		}
	}

	public class SpriteStudioBaker
	{
		public string destDirectory;
		public string texturesDirectory;
		public string materialsDirectory;
		public string cellDataDirectory;
		public string animationsDirectory;
		public string prefabsDirectory;
		public int pixelPerUnit = 1;
		public string sourceDirectory;
		public SpriteStudioProject projectData;
		public List<SpriteStudioCellMap> cellMapList;
		public List<SpriteStudioAnimePack> animePackList;
		public Dictionary<string, Material> addMaterialDict;
		public Dictionary<string, Material> mixMaterialDict;
		public Dictionary<string, Material> mulMaterialDict;
		public Dictionary<string, Material> subMaterialDict;
		public Dictionary<string, List<SpriteStudioCell>> cellMaps;

		public void GetProjectFile (string path)
		{
			XmlSerializer serializer = new XmlSerializer (typeof(SpriteStudioProject));
			using (StreamReader sr = new StreamReader(path, new UTF8Encoding(false))) {
				projectData = serializer.Deserialize (sr) as SpriteStudioProject;
			}
		}
		
		public void GetCellMap (string path)
		{
			XmlSerializer serializer = new XmlSerializer (typeof(SpriteStudioCellMap));			
			using (StreamReader sr = new StreamReader(path, new UTF8Encoding(false))) {
				SpriteStudioCellMap cellMap = serializer.Deserialize (sr) as SpriteStudioCellMap;
				cellMapList.Add (cellMap);
			}
		}
		
		public void GetAnimePack (string path)
		{
			XmlSerializer serializer = new XmlSerializer (typeof(SpriteStudioAnimePack));
			using (StreamReader sr = new StreamReader(path,new UTF8Encoding(false))) {
				SpriteStudioAnimePack animePack = serializer.Deserialize (sr) as SpriteStudioAnimePack;
				animePackList.Add (animePack);
			}
		}

		public void CreateTexture (SpriteStudioCellMap cellMap)
		{			
			string destFileName = texturesDirectory + "/" + cellMap.imagePath;
			File.Copy (sourceDirectory + "/" + cellMap.imagePath, destFileName, true);
			AssetDatabase.ImportAsset (destFileName);
			TextureImporter importer = TextureImporter.GetAtPath (destFileName) as TextureImporter;
			if (importer != null) {
				importer.textureType = TextureImporterType.Advanced;
				importer.maxTextureSize = 4096;
				importer.textureFormat = TextureImporterFormat.AutomaticTruecolor;
				importer.isReadable = false;
				importer.filterMode = FilterMode.Bilinear;
				importer.npotScale = TextureImporterNPOTScale.None;
				importer.wrapMode = TextureWrapMode.Clamp;
				importer.mipmapEnabled = false;
				importer.spriteImportMode = SpriteImportMode.Multiple;
				importer.spritePixelsPerUnit = pixelPerUnit;
					
				List<SpriteMetaData> spritesheet = new List<SpriteMetaData> ();
				Vector2 pixelSize = GetVector2 (cellMap.pixelSize);
				foreach (SpriteStudioCellMapCell cell in cellMap.cells) {
					SpriteMetaData metaData = new SpriteMetaData ();
					metaData.alignment = (int)SpriteAlignment.Custom;
					metaData.name = cell.name;
					Vector2 size = GetVector2 (cell.size);
					Vector2 pos = GetVector2 (cell.pos);
					Vector2 pivot = GetVector2 (cell.pivot);
					metaData.rect = new Rect (pos.x, pixelSize.y - pos.y - size.y, size.x, size.y);
					metaData.pivot = new Vector2 (pivot.x + 0.5f, pivot.y + 0.5f);
					spritesheet.Add (metaData);
				}
				importer.spritesheet = spritesheet.ToArray ();
				AssetDatabase.ImportAsset (destFileName);
				AssetDatabase.SaveAssets ();
				AssetDatabase.Refresh ();
			}
		}

		public void CreateMaterials (SpriteStudioCellMap cellMap)
		{
			string destFileName = texturesDirectory + "/" + cellMap.imagePath;
			string fileName = Path.GetFileNameWithoutExtension (cellMap.imagePath);
			Texture2D texture = AssetDatabase.LoadAssetAtPath (destFileName, typeof(Texture2D)) as Texture2D;
				
			Material addMaterial = new Material (Shader.Find ("Custom/SpriteStudio5/Add"));
			addMaterial.mainTexture = texture;
			AssetDatabase.CreateAsset (addMaterial, materialsDirectory + "/" + fileName + "_Add.mat");
			addMaterialDict [cellMap.name] = addMaterial;
				
			Material mixMaterial = new Material (Shader.Find ("Custom/SpriteStudio5/Mix"));
			mixMaterial.mainTexture = texture;
			AssetDatabase.CreateAsset (mixMaterial, materialsDirectory + "/" + fileName + "_Mix.mat");
			mixMaterialDict [cellMap.name] = mixMaterial;
				
			Material mulMaterial = new Material (Shader.Find ("Custom/SpriteStudio5/Mul"));
			mulMaterial.mainTexture = texture;
			AssetDatabase.CreateAsset (mulMaterial, materialsDirectory + "/" + fileName + "_Mul.mat");
			mulMaterialDict [cellMap.name] = mulMaterial;
				
			Material subMaterial = new Material (Shader.Find ("Custom/SpriteStudio5/Sub"));
			subMaterial.mainTexture = texture;
			AssetDatabase.CreateAsset (subMaterial, materialsDirectory + "/" + fileName + "_Sub.mat");
			subMaterialDict [cellMap.name] = subMaterial;
				
			AssetDatabase.SaveAssets ();
			AssetDatabase.Refresh ();
		}

		public void CreateCellData (SpriteStudioCellMap cellMap, int mapId)
		{
			List<SpriteStudioCell> cellList = new List<SpriteStudioCell> ();
			string guid = AssetDatabase.CreateFolder (cellDataDirectory, cellMap.name);
			string subDirectory = AssetDatabase.GUIDToAssetPath (guid);
			foreach (SpriteStudioCellMapCell cell in cellMap.cells) {
				SpriteStudioCell c = ScriptableObject.CreateInstance<SpriteStudioCell> ();
				c.mapId = mapId;
				c.mixMaterial = mixMaterialDict [cellMap.name];
				c.addMaterial = addMaterialDict [cellMap.name];
				c.mulMaterial = mulMaterialDict [cellMap.name];
				c.subMaterial = subMaterialDict [cellMap.name];
				c.size = GetVector2 (cell.size);
				c.pos = GetVector2 (cell.pos);
				c.pivot = GetVector2 (cell.pivot);
				c.pixelSize = GetVector2 (cellMap.pixelSize);
				c.pixelPerUnit = pixelPerUnit;
				c.Calculate ();

				cellList.Add (c);
				AssetDatabase.CreateAsset (c, subDirectory + "/" + cell.name + ".asset");
				AssetDatabase.SaveAssets ();
				AssetDatabase.Refresh ();
			}
			
			cellMaps [cellMap.name] = cellList;
		}

		public void CreateAnimator (SpriteStudioAnimePack animePack)
		{
			GameObject controllerObj = new GameObject (animePack.name);
			SpriteStudioController controller = controllerObj.AddComponent<SpriteStudioController> ();

			List<SpriteStudioCell> cellList = new List<SpriteStudioCell> ();
			int mapId = 0;
			int cellId = 0;
			foreach (string cellmapName in animePack.cellmapNames) {
				SpriteStudioCellMap cellMap = cellMapList.FirstOrDefault (u => u.name == Path.GetFileNameWithoutExtension (cellmapName));
				List<SpriteStudioCell> cells = cellMaps [cellMap.name];
				foreach (SpriteStudioCell cell in cells) {
					cell.mapId = mapId;
					cell.cellId = cellId;
					cellList.Add (cell);
					cellId++;
				}
				mapId++;
			}
			controller.cellList = cellList;

			List<SpriteStudioPart> partList = new List<SpriteStudioPart> ();
				
			foreach (SpriteStudioAnimePackModelValue model in animePack.Model.partList) {
				GameObject partObj = new GameObject (model.name);
				SpriteStudioPart part = partObj.AddComponent<SpriteStudioPart> ();
				part.controller = controller;
				part.name = model.name;
				part.arrayIndex = model.arrayIndex;
				part.parentIndex = model.parentIndex;
				part.partType = model.type.ToPartType ();
				part.boundsType = model.boundsType.ToBoundType ();
				part.alphaBlendType = model.alphaBlendType.ToAlphaBlendType ();
				part.inheritType = model.inheritType.ToInheritType ();
				part.inheritAlph = model.ineheritRates.ALPH == 1;
				part.inheritFlph = model.ineheritRates.FLPH == 1;
				part.inheritFlpv = model.ineheritRates.FLPV == 1;
				part.inheritHide = model.ineheritRates.HIDE == 1;
				part.inheritIflh = model.ineheritRates.IFLH == 1;
				part.inheritIflv = model.ineheritRates.IFLV == 1;

				partList.Add (part);

				if (part.parentIndex == -1) {
					partObj.transform.parent = controllerObj.transform;
					part.path = part.name;
				} else {
					SpriteStudioPart parentPart = partList.SingleOrDefault (v => v.arrayIndex == model.parentIndex);
					if (parentPart != null) {
						partObj.transform.parent = parentPart.transform;
						part.path = parentPart.path + "/" + part.name;
						part.parent = parentPart;
					}
				}

			}

			string animatorPath = animationsDirectory + "/" + animePack.name + ".controller";
			AnimatorController animatorController = AnimatorController.CreateAnimatorControllerAtPath (animatorPath);                   
			Animator animator = controllerObj.GetComponent<Animator> ();
			animator.runtimeAnimatorController = animatorController;

			foreach (SpriteStudioAnimePackAnime packAnime in animePack.animeList) {
				AnimationClip clip = new AnimationClip ();
				clip.name = packAnime.name;
				clip.frameRate = packAnime.settings.fps;				
				animatorController.AddMotion (clip);
				AssetDatabase.AddObjectToAsset (clip, animatorController);
					
				foreach (SpriteStudioAnimePackAnimePartAnime partAnime in packAnime.partAnimes) {
					SpriteStudioPart part = partList.SingleOrDefault (v => v.name == partAnime.partName);
					SpriteStudioAnimePackAnimePartAnimeAttribute attribute = null;
					attribute = partAnime.attributes.SingleOrDefault (v => v.tag == "CELL");
					if (attribute != null) {
						AnimationCurve curveCellId = new AnimationCurve ();
						for (int i = 0; i < attribute.key.Length; i++) {
							SpriteStudioAnimePackAnimePartAnimeAttributeKey key = attribute.key [i];
							float time = GetTime (key, clip.frameRate);
							SpriteStudioCell cell = cellList.SingleOrDefault (v => v.mapId == key.value.mapId && v.name == key.value.name);
							curveCellId.AddKey (KeyframeUtil.GetNew (time, (float)cell.cellId, TangentMode.Stepped));
						}
						clip.SetCurve (part.path, typeof(SpriteStudioPart), "cellId", curveCellId);
					}
					attribute = partAnime.attributes.SingleOrDefault (v => v.tag == "POSX");
					if (attribute != null) {
						AnimationCurve curve = new AnimationCurve ();
						for (int i = 0; i < attribute.key.Length; i++) {
							SpriteStudioAnimePackAnimePartAnimeAttributeKey key = attribute.key [i];
							float time = GetTime (key, clip.frameRate);
							float value = GetValue (key) / pixelPerUnit;
							TangentMode tangentMode = key.ipType.ToTangentMode ();
							curve.AddKey (KeyframeUtil.GetNew (time, value, tangentMode));
						}
						curve.UpdateAllLinearTangents ();
						clip.SetCurve (part.path, typeof(Transform), "localPosition.x", curve);
					}
					attribute = partAnime.attributes.SingleOrDefault (v => v.tag == "POSY");
					if (attribute != null) {
						AnimationCurve curve = new AnimationCurve ();
						for (int i = 0; i < attribute.key.Length; i++) {
							SpriteStudioAnimePackAnimePartAnimeAttributeKey key = attribute.key [i];
							float time = GetTime (key, clip.frameRate);
							float value = GetValue (key) / pixelPerUnit;
							TangentMode tangentMode = key.ipType.ToTangentMode ();
							curve.AddKey (KeyframeUtil.GetNew (time, value, tangentMode));
						}
						curve.UpdateAllLinearTangents ();
						clip.SetCurve (part.path, typeof(Transform), "localPosition.y", curve);
					}
					attribute = partAnime.attributes.SingleOrDefault (v => v.tag == "POSZ");
					if (attribute != null) {
						AnimationCurve curve = new AnimationCurve ();
						for (int i = 0; i < attribute.key.Length; i++) {
							SpriteStudioAnimePackAnimePartAnimeAttributeKey key = attribute.key [i];
							float time = GetTime (key, clip.frameRate);
							float value = GetValue (key) / pixelPerUnit;
							TangentMode tangentMode = key.ipType.ToTangentMode ();
							curve.AddKey (KeyframeUtil.GetNew (time, value, tangentMode));
						}
						curve.UpdateAllLinearTangents ();
						clip.SetCurve (part.path, typeof(Transform), "localPosition.z", curve);
					}
					attribute = partAnime.attributes.SingleOrDefault (v => v.tag == "ROTX");
					if (attribute != null) {
						AnimationCurve curve = new AnimationCurve ();
						for (int i = 0; i < attribute.key.Length; i++) {
							SpriteStudioAnimePackAnimePartAnimeAttributeKey key = attribute.key [i];
							float time = GetTime (key, clip.frameRate);
							float value = GetValue (key);
							TangentMode tangentMode = key.ipType.ToTangentMode ();
							curve.AddKey (KeyframeUtil.GetNew (time, value, tangentMode));
						}
						curve.UpdateAllLinearTangents ();
						clip.SetCurve (part.path, typeof(SpriteStudioPart), "rotationX", curve);
					}
					attribute = partAnime.attributes.SingleOrDefault (v => v.tag == "ROTY");
					if (attribute != null) {
						AnimationCurve curve = new AnimationCurve ();
						for (int i = 0; i < attribute.key.Length; i++) {
							SpriteStudioAnimePackAnimePartAnimeAttributeKey key = attribute.key [i];
							float time = GetTime (key, clip.frameRate);
							float value = GetValue (key);
							TangentMode tangentMode = key.ipType.ToTangentMode ();
							curve.AddKey (KeyframeUtil.GetNew (time, value, tangentMode));
						}
						curve.UpdateAllLinearTangents ();
						clip.SetCurve (part.path, typeof(SpriteStudioPart), "rotationY", curve);
					}
					attribute = partAnime.attributes.SingleOrDefault (v => v.tag == "ROTZ");
					if (attribute != null) {
						AnimationCurve curve = new AnimationCurve ();
						for (int i = 0; i < attribute.key.Length; i++) {
							SpriteStudioAnimePackAnimePartAnimeAttributeKey key = attribute.key [i];
							float time = GetTime (key, clip.frameRate);
							float value = GetValue (key);
							TangentMode tangentMode = key.ipType.ToTangentMode ();
							curve.AddKey (KeyframeUtil.GetNew (time, value, tangentMode));
						}
						curve.UpdateAllLinearTangents ();
						clip.SetCurve (part.path, typeof(SpriteStudioPart), "rotationZ", curve);
					}
					attribute = partAnime.attributes.SingleOrDefault (v => v.tag == "SCLX");
					if (attribute != null) {
						AnimationCurve curve = new AnimationCurve ();
						for (int i = 0; i < attribute.key.Length; i++) {
							SpriteStudioAnimePackAnimePartAnimeAttributeKey key = attribute.key [i];
							float time = GetTime (key, clip.frameRate);
							float value = GetValue (key);
							TangentMode tangentMode = key.ipType.ToTangentMode ();
							curve.AddKey (KeyframeUtil.GetNew (time, value, tangentMode));
						}
						curve.UpdateAllLinearTangents ();
						clip.SetCurve (part.path, typeof(Transform), "localScale.x", curve);
					}
					attribute = partAnime.attributes.SingleOrDefault (v => v.tag == "SCLY");
					if (attribute != null) {
						AnimationCurve curve = new AnimationCurve ();
						for (int i = 0; i < attribute.key.Length; i++) {
							SpriteStudioAnimePackAnimePartAnimeAttributeKey key = attribute.key [i];
							float time = GetTime (key, clip.frameRate);
							float value = GetValue (key);
							TangentMode tangentMode = key.ipType.ToTangentMode ();
							curve.AddKey (KeyframeUtil.GetNew (time, value, tangentMode));
						}
						curve.UpdateAllLinearTangents ();
						clip.SetCurve (part.path, typeof(Transform), "localScale.y", curve);
					}
					attribute = partAnime.attributes.SingleOrDefault (v => v.tag == "ALPH");
					if (attribute != null) {
						AnimationCurve curve = new AnimationCurve ();
						for (int i = 0; i < attribute.key.Length; i++) {
							SpriteStudioAnimePackAnimePartAnimeAttributeKey key = attribute.key [i];
							float time = GetTime (key, clip.frameRate);
							float value = GetValue (key);
							TangentMode tangentMode = key.ipType.ToTangentMode ();
							curve.AddKey (KeyframeUtil.GetNew (time, value, tangentMode));
						}
						curve.UpdateAllLinearTangents ();
						clip.SetCurve (part.path, typeof(SpriteStudioPart), "alpha", curve);
					}
					attribute = partAnime.attributes.SingleOrDefault (v => v.tag == "PRIO");
					if (attribute != null) {
						AnimationCurve curve = new AnimationCurve ();
						for (int i = 0; i < attribute.key.Length; i++) {
							SpriteStudioAnimePackAnimePartAnimeAttributeKey key = attribute.key [i];
							float time = GetTime (key, clip.frameRate);
							float value = GetValue (key);
							TangentMode tangentMode = key.ipType.ToTangentMode ();
							curve.AddKey (KeyframeUtil.GetNew (time, value, tangentMode));
						}
						clip.SetCurve (part.path, typeof(SpriteStudioPart), "sortingOrder", curve);
					}
					attribute = partAnime.attributes.SingleOrDefault (v => v.tag == "FLPH");
					if (attribute != null) {
						AnimationCurve curve = new AnimationCurve ();
						for (int i = 0; i < attribute.key.Length; i++) {
							SpriteStudioAnimePackAnimePartAnimeAttributeKey key = attribute.key [i];
							float time = GetTime (key, clip.frameRate);
							float value = GetBoolValue (key);
							curve.AddKey (KeyframeUtil.GetNew (time, value, TangentMode.Stepped));
						}
						clip.SetCurve (part.path, typeof(SpriteStudioPart), "flipH", curve);
					}
					attribute = partAnime.attributes.SingleOrDefault (v => v.tag == "FLPV");
					if (attribute != null) {
						AnimationCurve curve = new AnimationCurve ();
						for (int i = 0; i < attribute.key.Length; i++) {
							SpriteStudioAnimePackAnimePartAnimeAttributeKey key = attribute.key [i];
							float time = GetTime (key, clip.frameRate);
							float value = GetBoolValue (key);
							curve.AddKey (KeyframeUtil.GetNew (time, value, TangentMode.Stepped));
						}
						clip.SetCurve (part.path, typeof(SpriteStudioPart), "flipV", curve);
					}
					attribute = partAnime.attributes.SingleOrDefault (v => v.tag == "HIDE");
					if (attribute != null) {
						AnimationCurve curve = new AnimationCurve ();
						for (int i = 0; i < attribute.key.Length; i++) {
							SpriteStudioAnimePackAnimePartAnimeAttributeKey key = attribute.key [i];
							float time = GetTime (key, clip.frameRate);
							float value = GetBoolValue (key);
							if (i == 0 && time != 0) {
								curve.AddKey (KeyframeUtil.GetNew (0, 0, TangentMode.Stepped));
							}
							curve.AddKey (KeyframeUtil.GetNew (time, value, TangentMode.Stepped));
						}
						clip.SetCurve (part.path, typeof(MeshRenderer), "m_Enabled", curve);
					} else {
						AnimationCurve curve = new AnimationCurve ();
						curve.AddKey (KeyframeUtil.GetNew (0, 0, TangentMode.Stepped));
						clip.SetCurve (part.path, typeof(MeshRenderer), "m_Enabled", curve);
					}
					attribute = partAnime.attributes.SingleOrDefault (v => v.tag == "VCOL");
					if (attribute != null) {
						AnimationCurve curveBlend = new AnimationCurve ();
						AnimationCurve curveLBR = new AnimationCurve ();
						AnimationCurve curveLBG = new AnimationCurve ();
						AnimationCurve curveLBB = new AnimationCurve ();
						AnimationCurve curveLBA = new AnimationCurve ();
						AnimationCurve curveRBR = new AnimationCurve ();
						AnimationCurve curveRBG = new AnimationCurve ();
						AnimationCurve curveRBB = new AnimationCurve ();
						AnimationCurve curveRBA = new AnimationCurve ();
						AnimationCurve curveLTR = new AnimationCurve ();
						AnimationCurve curveLTG = new AnimationCurve ();
						AnimationCurve curveLTB = new AnimationCurve ();
						AnimationCurve curveLTA = new AnimationCurve ();
						AnimationCurve curveRTR = new AnimationCurve ();
						AnimationCurve curveRTG = new AnimationCurve ();
						AnimationCurve curveRTB = new AnimationCurve ();
						AnimationCurve curveRTA = new AnimationCurve ();
						for (int i = 0; i < attribute.key.Length; i++) {
							SpriteStudioAnimePackAnimePartAnimeAttributeKey key = attribute.key [i];
							float time = GetTime (key, clip.frameRate);
							ColorBlendTarget target = key.value.target.ToColorBlendTarget ();
							ColorBlendType type = key.value.blendType.ToColorBlendType ();
							float coorBlendValue = (float)type + 1.0f;
							float valueLBR = 1;
							float valueLBG = 1;
							float valueLBB = 1;
							float valueLBA = 1;
							float valueRBR = 1;
							float valueRBG = 1;
							float valueRBB = 1;
							float valueRBA = 1;
							float valueLTR = 1;
							float valueLTG = 1;
							float valueLTB = 1;
							float valueLTA = 1;
							float valueRTR = 1;
							float valueRTG = 1;
							float valueRTB = 1;
							float valueRTA = 1;
							if (target == ColorBlendTarget.Whole) {
								valueLBA = valueRBA = valueLTA = valueRTA = System.Int32.Parse (key.value.color.rgba.Substring (0, 2), System.Globalization.NumberStyles.HexNumber) / 255.0f;
								valueLBR = valueRBR = valueLTR = valueRTR = System.Int32.Parse (key.value.color.rgba.Substring (2, 2), System.Globalization.NumberStyles.HexNumber) / 255.0f;
								valueLBG = valueRBG = valueLTG = valueRTG = System.Int32.Parse (key.value.color.rgba.Substring (4, 2), System.Globalization.NumberStyles.HexNumber) / 255.0f;
								valueLBB = valueRBB = valueLTB = valueRTB = System.Int32.Parse (key.value.color.rgba.Substring (6, 2), System.Globalization.NumberStyles.HexNumber) / 255.0f;
							} else {
								valueLBA = System.Int32.Parse (key.value.LB.rgba.Substring (0, 2), System.Globalization.NumberStyles.HexNumber) / 255.0f;
								valueLBR = System.Int32.Parse (key.value.LB.rgba.Substring (2, 2), System.Globalization.NumberStyles.HexNumber) / 255.0f;
								valueLBG = System.Int32.Parse (key.value.LB.rgba.Substring (4, 2), System.Globalization.NumberStyles.HexNumber) / 255.0f;
								valueLBB = System.Int32.Parse (key.value.LB.rgba.Substring (6, 2), System.Globalization.NumberStyles.HexNumber) / 255.0f;
								valueRBA = System.Int32.Parse (key.value.RB.rgba.Substring (0, 2), System.Globalization.NumberStyles.HexNumber) / 255.0f;
								valueRBR = System.Int32.Parse (key.value.RB.rgba.Substring (2, 2), System.Globalization.NumberStyles.HexNumber) / 255.0f;
								valueRBG = System.Int32.Parse (key.value.RB.rgba.Substring (4, 2), System.Globalization.NumberStyles.HexNumber) / 255.0f;
								valueRBB = System.Int32.Parse (key.value.RB.rgba.Substring (6, 2), System.Globalization.NumberStyles.HexNumber) / 255.0f;
								valueLTA = System.Int32.Parse (key.value.LT.rgba.Substring (0, 2), System.Globalization.NumberStyles.HexNumber) / 255.0f;
								valueLTR = System.Int32.Parse (key.value.LT.rgba.Substring (2, 2), System.Globalization.NumberStyles.HexNumber) / 255.0f;
								valueLTG = System.Int32.Parse (key.value.LT.rgba.Substring (4, 2), System.Globalization.NumberStyles.HexNumber) / 255.0f;
								valueLTB = System.Int32.Parse (key.value.LT.rgba.Substring (6, 2), System.Globalization.NumberStyles.HexNumber) / 255.0f;
								valueRTA = System.Int32.Parse (key.value.RT.rgba.Substring (0, 2), System.Globalization.NumberStyles.HexNumber) / 255.0f;
								valueRTR = System.Int32.Parse (key.value.RT.rgba.Substring (2, 2), System.Globalization.NumberStyles.HexNumber) / 255.0f;
								valueRTG = System.Int32.Parse (key.value.RT.rgba.Substring (4, 2), System.Globalization.NumberStyles.HexNumber) / 255.0f;
								valueRTB = System.Int32.Parse (key.value.RT.rgba.Substring (6, 2), System.Globalization.NumberStyles.HexNumber) / 255.0f;
							}

							TangentMode tangentMode = key.ipType.ToTangentMode ();
							curveBlend.AddKey (KeyframeUtil.GetNew (time, coorBlendValue, tangentMode));
							curveLBR.AddKey (KeyframeUtil.GetNew (time, valueLBR, tangentMode));
							curveLBG.AddKey (KeyframeUtil.GetNew (time, valueLBG, tangentMode));
							curveLBB.AddKey (KeyframeUtil.GetNew (time, valueLBB, tangentMode));
							curveLBA.AddKey (KeyframeUtil.GetNew (time, valueLBA, tangentMode));
							curveRBR.AddKey (KeyframeUtil.GetNew (time, valueRBR, tangentMode));
							curveRBG.AddKey (KeyframeUtil.GetNew (time, valueRBG, tangentMode));
							curveRBB.AddKey (KeyframeUtil.GetNew (time, valueRBB, tangentMode));
							curveRBA.AddKey (KeyframeUtil.GetNew (time, valueRBA, tangentMode));
							curveLTR.AddKey (KeyframeUtil.GetNew (time, valueLTR, tangentMode));
							curveLTG.AddKey (KeyframeUtil.GetNew (time, valueLTG, tangentMode));
							curveLTB.AddKey (KeyframeUtil.GetNew (time, valueLTB, tangentMode));
							curveLTA.AddKey (KeyframeUtil.GetNew (time, valueLTA, tangentMode));
							curveRTR.AddKey (KeyframeUtil.GetNew (time, valueRTR, tangentMode));
							curveRTG.AddKey (KeyframeUtil.GetNew (time, valueRTG, tangentMode));
							curveRTB.AddKey (KeyframeUtil.GetNew (time, valueRTB, tangentMode));
							curveRTA.AddKey (KeyframeUtil.GetNew (time, valueRTA, tangentMode));

						}
						clip.SetCurve (part.path, typeof(SpriteStudioPart), "colorBlendValue", curveBlend);
						clip.SetCurve (part.path, typeof(SpriteStudioPart), "colorLB.r", curveLBR);
						clip.SetCurve (part.path, typeof(SpriteStudioPart), "colorLB.g", curveLBG);
						clip.SetCurve (part.path, typeof(SpriteStudioPart), "colorLB.b", curveLBB);
						clip.SetCurve (part.path, typeof(SpriteStudioPart), "colorLB.a", curveLBA);
						clip.SetCurve (part.path, typeof(SpriteStudioPart), "colorRB.r", curveRBR);
						clip.SetCurve (part.path, typeof(SpriteStudioPart), "colorRB.g", curveRBG);
						clip.SetCurve (part.path, typeof(SpriteStudioPart), "colorRB.b", curveRBB);
						clip.SetCurve (part.path, typeof(SpriteStudioPart), "colorRB.a", curveRBA);
						clip.SetCurve (part.path, typeof(SpriteStudioPart), "colorLT.r", curveLTR);
						clip.SetCurve (part.path, typeof(SpriteStudioPart), "colorLT.g", curveLTG);
						clip.SetCurve (part.path, typeof(SpriteStudioPart), "colorLT.b", curveLTB);
						clip.SetCurve (part.path, typeof(SpriteStudioPart), "colorLT.a", curveLTA);
						clip.SetCurve (part.path, typeof(SpriteStudioPart), "colorRT.r", curveRTR);
						clip.SetCurve (part.path, typeof(SpriteStudioPart), "colorRT.g", curveRTG);
						clip.SetCurve (part.path, typeof(SpriteStudioPart), "colorRT.b", curveRTB);
						clip.SetCurve (part.path, typeof(SpriteStudioPart), "colorRT.a", curveRTA);
					}
					attribute = partAnime.attributes.SingleOrDefault (v => v.tag == "VERT");
					if (attribute != null) {
						AnimationCurve curveLBX = new AnimationCurve ();
						AnimationCurve curveLBY = new AnimationCurve ();
						AnimationCurve curveRBX = new AnimationCurve ();
						AnimationCurve curveRBY = new AnimationCurve ();
						AnimationCurve curveLTX = new AnimationCurve ();
						AnimationCurve curveLTY = new AnimationCurve ();
						AnimationCurve curveRTX = new AnimationCurve ();
						AnimationCurve curveRTY = new AnimationCurve ();
						for (int i = 0; i < attribute.key.Length; i++) {
							SpriteStudioAnimePackAnimePartAnimeAttributeKey key = attribute.key [i];
							float time = GetTime (key, clip.frameRate);
							Vector2 vertexLB = GetVector2 (key.value.LB.Text [0]);
							Vector2 vertexRB = GetVector2 (key.value.RB.Text [0]);
							Vector2 vertexLT = GetVector2 (key.value.LT.Text [0]);
							Vector2 vertexRT = GetVector2 (key.value.RT.Text [0]);
							curveLBX.AddKey (KeyframeUtil.GetNew (time, vertexLB.x, TangentMode.Stepped));
							curveLBY.AddKey (KeyframeUtil.GetNew (time, vertexLB.y, TangentMode.Stepped));
							curveRBX.AddKey (KeyframeUtil.GetNew (time, vertexRB.x, TangentMode.Stepped));
							curveRBY.AddKey (KeyframeUtil.GetNew (time, vertexRB.y, TangentMode.Stepped));
							curveLTX.AddKey (KeyframeUtil.GetNew (time, vertexLT.x, TangentMode.Stepped));
							curveLTY.AddKey (KeyframeUtil.GetNew (time, vertexLT.y, TangentMode.Stepped));
							curveRTX.AddKey (KeyframeUtil.GetNew (time, vertexRT.x, TangentMode.Stepped));
							curveRTY.AddKey (KeyframeUtil.GetNew (time, vertexRT.y, TangentMode.Stepped));
						}
						clip.SetCurve (part.path, typeof(SpriteStudioPart), "vertexLB.x", curveLBX);
						clip.SetCurve (part.path, typeof(SpriteStudioPart), "vertexLB.y", curveLBY);
						clip.SetCurve (part.path, typeof(SpriteStudioPart), "vertexRB.x", curveRBX);
						clip.SetCurve (part.path, typeof(SpriteStudioPart), "vertexRB.y", curveRBY);
						clip.SetCurve (part.path, typeof(SpriteStudioPart), "vertexLT.x", curveLTX);
						clip.SetCurve (part.path, typeof(SpriteStudioPart), "vertexLT.y", curveLTY);
						clip.SetCurve (part.path, typeof(SpriteStudioPart), "vertexRT.x", curveRTX);
						clip.SetCurve (part.path, typeof(SpriteStudioPart), "vertexRT.y", curveRTY);
					}
					attribute = partAnime.attributes.SingleOrDefault (v => v.tag == "PVTX");
					if (attribute != null) {
						AnimationCurve curve = new AnimationCurve ();
						for (int i = 0; i < attribute.key.Length; i++) {
							SpriteStudioAnimePackAnimePartAnimeAttributeKey key = attribute.key [i];
							float time = GetTime (key, clip.frameRate);
							float value = GetValue (key);
							TangentMode tangentMode = key.ipType.ToTangentMode ();
							curve.AddKey (KeyframeUtil.GetNew (time, value, tangentMode));
						}
						curve.UpdateAllLinearTangents ();
						clip.SetCurve (part.path, typeof(SpriteStudioPart), "offsetX", curve);
					}
					attribute = partAnime.attributes.SingleOrDefault (v => v.tag == "PVTY");
					if (attribute != null) {
						AnimationCurve curve = new AnimationCurve ();
						for (int i = 0; i < attribute.key.Length; i++) {
							SpriteStudioAnimePackAnimePartAnimeAttributeKey key = attribute.key [i];
							float time = GetTime (key, clip.frameRate);
							float value = GetValue (key);
							TangentMode tangentMode = key.ipType.ToTangentMode ();
							curve.AddKey (KeyframeUtil.GetNew (time, value, tangentMode));
						}
						curve.UpdateAllLinearTangents ();
						clip.SetCurve (part.path, typeof(SpriteStudioPart), "offsetY", curve);
					}
					attribute = partAnime.attributes.SingleOrDefault (v => v.tag == "ANCX");
					if (attribute != null) {
						AnimationCurve curve = new AnimationCurve ();
						for (int i = 0; i < attribute.key.Length; i++) {
							SpriteStudioAnimePackAnimePartAnimeAttributeKey key = attribute.key [i];
							float time = GetTime (key, clip.frameRate);
							float value = GetValue (key);
							TangentMode tangentMode = key.ipType.ToTangentMode ();
							curve.AddKey (KeyframeUtil.GetNew (time, value, tangentMode));
						}
						curve.UpdateAllLinearTangents ();
						clip.SetCurve (part.path, typeof(SpriteStudioPart), "anchorX", curve);
					}
					attribute = partAnime.attributes.SingleOrDefault (v => v.tag == "ANCY");
					if (attribute != null) {
						AnimationCurve curve = new AnimationCurve ();
						for (int i = 0; i < attribute.key.Length; i++) {
							SpriteStudioAnimePackAnimePartAnimeAttributeKey key = attribute.key [i];
							float time = GetTime (key, clip.frameRate);
							float value = GetValue (key);
							TangentMode tangentMode = key.ipType.ToTangentMode ();
							curve.AddKey (KeyframeUtil.GetNew (time, value, tangentMode));
						}
						curve.UpdateAllLinearTangents ();
						clip.SetCurve (part.path, typeof(SpriteStudioPart), "anchorY", curve);
					}
					attribute = partAnime.attributes.SingleOrDefault (v => v.tag == "SIZX");
					if (attribute != null) {
						AnimationCurve curve = new AnimationCurve ();
						for (int i = 0; i < attribute.key.Length; i++) {
							SpriteStudioAnimePackAnimePartAnimeAttributeKey key = attribute.key [i];
							float time = GetTime (key, clip.frameRate);
							float value = GetValue (key);
							TangentMode tangentMode = key.ipType.ToTangentMode ();
							curve.AddKey (KeyframeUtil.GetNew (time, value, tangentMode));
						}
						curve.UpdateAllLinearTangents ();
						clip.SetCurve (part.path, typeof(SpriteStudioPart), "sizeX", curve);
					}
					attribute = partAnime.attributes.SingleOrDefault (v => v.tag == "SIZY");
					if (attribute != null) {
						AnimationCurve curve = new AnimationCurve ();
						for (int i = 0; i < attribute.key.Length; i++) {
							SpriteStudioAnimePackAnimePartAnimeAttributeKey key = attribute.key [i];
							float time = GetTime (key, clip.frameRate);
							float value = GetValue (key);
							TangentMode tangentMode = key.ipType.ToTangentMode ();
							curve.AddKey (KeyframeUtil.GetNew (time, value, tangentMode));
						}
						curve.UpdateAllLinearTangents ();
						clip.SetCurve (part.path, typeof(SpriteStudioPart), "sizeY", curve);
					}
					attribute = partAnime.attributes.SingleOrDefault (v => v.tag == "BNDR");
					if (attribute != null) {
						AnimationCurve curve = new AnimationCurve ();
						for (int i = 0; i < attribute.key.Length; i++) {
							SpriteStudioAnimePackAnimePartAnimeAttributeKey key = attribute.key [i];
							float time = GetTime (key, clip.frameRate);
							float value = GetValue (key);
							TangentMode tangentMode = key.ipType.ToTangentMode ();
							curve.AddKey (KeyframeUtil.GetNew (time, value, tangentMode));
						}
						curve.UpdateAllLinearTangents ();
						CircleCollider2D collider = part.GetComponent<CircleCollider2D> ();
						if (collider == null) {
							collider = part.gameObject.AddComponent<CircleCollider2D> ();
							collider.enabled = false;
						}
						clip.SetCurve (part.path, typeof(SphereCollider), "radius", curve);
					}

					attribute = partAnime.attributes.SingleOrDefault (v => v.tag == "USER");
					if (attribute != null) {
						List<AnimationEvent> eventList = new List<AnimationEvent> ();
						for (int i = 0; i < attribute.key.Length; i++) {
							SpriteStudioAnimePackAnimePartAnimeAttributeKey key = attribute.key [i];
							float time = GetTime (key, clip.frameRate);

							if (key.value.integerSpecified) {
								AnimationEvent animationEvent = new AnimationEvent ();
								animationEvent.time = time;
								animationEvent.functionName = "IntegerEvent";
								animationEvent.intParameter = key.value.integer;
								eventList.Add (animationEvent);
							} 
							if (key.value.rect != null) {
								AnimationEvent animationEvent = new AnimationEvent ();
								animationEvent.time = time;
								animationEvent.functionName = "RectEvent";
								animationEvent.stringParameter = key.value.rect;
								eventList.Add (animationEvent);
							} 
							if (key.value.point != null) {
								AnimationEvent animationEvent = new AnimationEvent ();
								animationEvent.time = time;
								animationEvent.functionName = "PointEvent";
								animationEvent.stringParameter = key.value.point;
								eventList.Add (animationEvent);
							} 
							if (key.value.@string != null) {
								AnimationEvent animationEvent = new AnimationEvent ();
								animationEvent.time = time;
								animationEvent.functionName = "StringEvent";
								animationEvent.stringParameter = key.value.@string;
								eventList.Add (animationEvent);
							}
						}
						AnimationUtility.SetAnimationEvents (clip, eventList.ToArray ());
					}
				}
			}
				
			string prefabPath = prefabsDirectory + "/" + controllerObj.name + ".prefab";
			PrefabUtility.CreatePrefab (prefabPath, controllerObj);
				
			UnityEngine.GameObject.DestroyImmediate (controllerObj);
			AssetDatabase.SaveAssets ();
			AssetDatabase.Refresh ();
		}

		float GetTime (SpriteStudioAnimePackAnimePartAnimeAttributeKey key, float frameRate)
		{
			float time = 0;
			if (key.time != 0)
				time = key.time / frameRate;
			return time;
		}

		float GetValue (SpriteStudioAnimePackAnimePartAnimeAttributeKey key)
		{
			float value = 0;
			if (key.value.Text.Length == 1)
				value = float.Parse (key.value.Text [0]);
			return value;
		}

		float GetBoolValue (SpriteStudioAnimePackAnimePartAnimeAttributeKey key)
		{
			float value = 0;
			if (key.value.Text.Length == 1)
				value = float.Parse (key.value.Text [0]) == 0 ? 1 : 0;
			return value;
		}

		Vector2 GetVector2 (string str)
		{
			string[] split = str.Split (' ');
			Vector2 value = new Vector2 (float.Parse (split [0]), float.Parse (split [1]));
			return value;
		}
	}
}

