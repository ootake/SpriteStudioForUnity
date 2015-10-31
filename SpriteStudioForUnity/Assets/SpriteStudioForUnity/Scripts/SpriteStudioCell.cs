using UnityEngine;
using System.Collections;

namespace SpriteStudioForUnity
{
	public class SpriteStudioCell : ScriptableObject
	{
		public int mapName;
		public int mapId;
		public int cellId;
		public Material mixMaterial;
		public Material addMaterial;
		public Material mulMaterial;
		public Material subMaterial;
		public Vector2 size;
		public Vector2 pos;
		public Vector2 pivot;
		public Vector2 pixelSize;
		public float uvL;
		public float uvR;
		public float uvB;
		public float uvT;

		public void Calculate()
		{
			uvL = (pos.x)/ pixelSize.x;
			uvR = (pos.x + size.x) / pixelSize.x;
			uvB = (pixelSize.y - pos.y - size.y) / pixelSize.y;
			uvT = (pixelSize.y - pos.y) / pixelSize.y;
		}


	}
}

