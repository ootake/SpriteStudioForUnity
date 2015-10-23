using UnityEngine;
using System.Collections;

namespace SpriteStudioForUnity
{
	[RequireComponent(typeof(MeshRenderer))]
	[RequireComponent(typeof(MeshFilter))]
	[ExecuteInEditMode]
	public class SpriteStudioPart : MonoBehaviour
	{
        [HideInInspector]
		public int arrayIndex;
        [HideInInspector]
        public int parentIndex;
        [HideInInspector]
        public SpriteStudioPart parent;
        public PartType partType;
		public PartBoundsType boundsType;
		public PartAlphaBlendType alphaBlendType;
		public PartInheritType inheritType;
		public bool inheritAlph;
		public bool inheritFlph;
		public bool inheritFlpv;
		public bool inheritHide;
		public bool inheritIflh;
		public bool inheritIflv;
		public string path;
		public float alpha = 1;
		float _alpha;
		public float sortingOrder;
		float _sortingOrder;
		public float rotationX;
		float _rotationX;
		public float rotationY;
		float _rotationY;
		public float rotationZ;
		float _rotationZ;
		public bool flipH;
		bool _flipH;
		public bool flipV;
		bool _flipV;
		public float colorBlendValue;
		float _colorBlendValue;
		public Color colorLB = new Color (1, 1, 1, 1);
		Color _colorLB = new Color (1, 1, 1, 1);
		public Color colorRB = new Color (1, 1, 1, 1);
		Color _colorRB = new Color (1, 1, 1, 1);
		public Color colorLT = new Color (1, 1, 1, 1);
		Color _colorLT = new Color (1, 1, 1, 1);
		public Color colorRT = new Color (1, 1, 1, 1);
		Color _colorRT = new Color (1, 1, 1, 1);
		public float rateLB = 1;
		float _rateLB = 1;
		public float rateRB = 1;
		float _rateRB = 1;
		public float rateLT = 1;
		float _rateLT = 1;
		public float rateRT = 1;
		float _rateRT = 1;
		public float cellId = -1;
		float _cellId = -1;
		public Vector2 vertexLB;
		public Vector2 vertexRB;
		public Vector2 vertexLT;
		public Vector2 vertexRT;
		public float offsetX;
		float _offsetX;
		public float offsetY;
		float _offsetY;
		public float anchorX;
		public float anchorY;
		public float sizeX;
		public float sizeY;	
		public SpriteStudioCell cell;
		[HideInInspector]
		public SpriteStudioController controller;
		MeshRenderer meshRenderer;
		MeshFilter meshFilter;
        Mesh mesh;
		float opacity = 1;
		float _opacity = 1;

		void Start ()
		{
			meshRenderer = GetComponent<MeshRenderer> ();
			meshRenderer.sortingOrder = arrayIndex;
			meshFilter = GetComponent<MeshFilter> ();
            mesh = new Mesh();
            mesh.MarkDynamic();
			meshFilter.sharedMesh = mesh;
			UpdateMesh ();
		}
		
		void Update ()
		{
			if (rotationX != _rotationX) {
				_rotationX = rotationX;
				Vector3 localEulerAngles = transform.localEulerAngles;
				localEulerAngles.x = rotationX;
				transform.localEulerAngles = localEulerAngles;
			}
			if (rotationY != _rotationY) {
				_rotationY = rotationY;
				Vector3 localEulerAngles = transform.localEulerAngles;
				localEulerAngles.y = rotationY;
				transform.localEulerAngles = localEulerAngles;
			}
			if (rotationZ != _rotationZ) {
				_rotationZ = rotationZ;
				Vector3 localEulerAngles = transform.localEulerAngles;
				localEulerAngles.z = rotationZ;
				transform.localEulerAngles = localEulerAngles;
			}

            if (partType == PartType.Null)
                return;

            if (cellId == -1) {
                meshRenderer.enabled = false;
                return;
            }            

            if (sortingOrder != _sortingOrder) {
                _sortingOrder = sortingOrder;
                meshRenderer.sortingOrder = (int)sortingOrder * 100 + arrayIndex;
            }

			if (inheritType == PartInheritType.Parent) {
				SpriteStudioPart current = parent;
				float a = alpha;
				while (current != null) {
					a *= current.alpha;
					current = current.parent;
				}
				opacity = a;
			}

			bool materialFlg = false;
			bool meshFlg = false;

			if (cellId != _cellId) {
				_cellId = cellId;

				if (cellId != -1) {
					cell = controller.cellList [(int)cellId];
				} else {
					cell = null;
				}
				materialFlg = true;
				meshFlg = true;
			}

			if (colorBlendValue != _colorBlendValue) {
				_colorBlendValue = colorBlendValue;
				meshFlg = true;
			}

			if (opacity != _opacity) {
				_opacity = opacity;
				meshFlg = true;
			}

			if (colorLB != _colorLB) {
				_colorLB = colorLB;
				meshFlg = true;
			}
			if (colorRB != _colorRB) {
				_colorRB = colorRB;
				meshFlg = true;
			}
			if (colorLT != _colorLT) {
				_colorLT = colorLT;
				meshFlg = true;
			}
			if (colorRT != _colorRT) {
				_colorRT = colorRT;
				meshFlg = true;
			}

			if (rateLB != _rateLB) {
				_rateLB = rateLB;
				meshFlg = true;
			}
			if (rateRB != _rateRB) {
				_rateRB = rateRB;
				meshFlg = true;
			}
			if (rateLT != _rateLT) {
				_rateLT = rateLT;
				meshFlg = true;
			}
			if (rateRT != _rateRT) {
				_rateRT = rateRT;
				meshFlg = true;
			}

			if (flipH != _flipH) {
				_flipH = flipH;
				meshFlg = true;
			}

			if (flipV != _flipV) {
				_flipV = flipV;
				meshFlg = true;
			}

			if (offsetX != _offsetX) {
				_offsetX = offsetX;
				meshFlg = true;
			}
			if (offsetY != _offsetY) {
				_offsetY = offsetY;
				meshFlg = true;
			}


			if (materialFlg) {
				UpdateMaterial ();
			}
			if (meshFlg) {
				UpdateMesh ();
			}
		}

		void UpdateMesh ()
		{
			mesh.Clear ();

			if (cell == null)
				return;

			mesh.name = cell.name;

			float vL = cell.size.x * (-0.5f - cell.pivot.x - offsetX) / cell.pixelPerUnit;
			float vR = cell.size.x * (0.5f - cell.pivot.x - offsetX) / cell.pixelPerUnit;
			float vB = cell.size.y * (-0.5f - cell.pivot.y - offsetY) / cell.pixelPerUnit;
			float vT = cell.size.y * (0.5f - cell.pivot.y - offsetY) / cell.pixelPerUnit;
            Vector3 vLT = new Vector3 (vL + vertexLT.x / cell.pixelPerUnit, vT + vertexLT.y / cell.pixelPerUnit, 0.0f);
            Vector3 vRT = new Vector3 (vR + vertexRT.x / cell.pixelPerUnit, vT + vertexRT.y / cell.pixelPerUnit, 0.0f);
            Vector3 vRB = new Vector3 (vR + vertexRB.x / cell.pixelPerUnit, vB + vertexRB.y / cell.pixelPerUnit, 0.0f);
            Vector3 vLB = new Vector3 (vL + vertexLB.x / cell.pixelPerUnit, vB + vertexLB.y / cell.pixelPerUnit, 0.0f);
			Vector3 vC = Vector3.Lerp (Vector3.Lerp (vLB, vRB, 0.5f), Vector3.Lerp (vLT, vRT, 0.5f), 0.5f);
			mesh.vertices = new Vector3[]
			{
                vLT,
                vRT,
                vRB,
                vLB,
                vC,
			};

            Vector2 uvLT = new Vector2 (cell.uvL, cell.uvT);
            Vector2 uvRT = new Vector2 (cell.uvR, cell.uvT);
            Vector2 uvRB = new Vector2 (cell.uvR, cell.uvB);
            Vector2 uvLB = new Vector2 (cell.uvL, cell.uvB);
            Vector2 uvC = Vector2.Lerp (uvLB, uvRT, 0.5f);
            if (flipH && flipV) {
                mesh.uv = new Vector2[]{ uvRB,uvLB,uvLT,uvRT,uvC,};
            } else if (flipH) {
                mesh.uv = new Vector2[]{ uvRT,uvLT,uvLB,uvRB,uvC,};
            } else if (flipV) {
                mesh.uv = new Vector2[]{ uvLB,uvRB,uvRT,uvLT,uvC,};
            } else {
                mesh.uv = new Vector2[]{ uvLT,uvRT,uvRB,uvLB,uvC,};
            }

            float uv2y = (float)colorBlendValue + 0.01f;
            mesh.uv2 = new Vector2[]
            {
				new Vector2 (opacity * rateLT, uv2y),
				new Vector2 (opacity * rateRT, uv2y),
				new Vector2 (opacity * rateRB, uv2y),
				new Vector2 (opacity * rateLB, uv2y),
				new Vector2 (opacity * (rateLT + rateRT + rateRB + rateLB) / 4, uv2y),
            };

			mesh.triangles = new int[]
			{
                0, 1, 4,
                1, 2, 4,
                2, 3, 4,
                3, 0, 4,
            };

            Color colorC = Color.Lerp (Color.Lerp (colorLB, colorRB, 0.5f), Color.Lerp (colorLT, colorRT, 0.5f), 0.5f);
            mesh.colors32 = new Color32[]
            {
                colorLT,
                colorRT,
                colorRB,
                colorLB,
                colorC,
            };

			mesh.RecalculateNormals ();
		}

		void UpdateMaterial ()
		{
			if (cell == null) {
				meshRenderer.sharedMaterial = null;
				return;
			}

			switch (alphaBlendType) {
			case PartAlphaBlendType.Mix:
				meshRenderer.sharedMaterial = cell.mixMaterial;
				break;
			case PartAlphaBlendType.Add:
				meshRenderer.sharedMaterial = cell.addMaterial;
				break;
			case PartAlphaBlendType.Sub:
				meshRenderer.sharedMaterial = cell.subMaterial;
				break;
			case PartAlphaBlendType.Mul:
				meshRenderer.sharedMaterial = cell.mulMaterial;
				break;
			default:
				break;
			}
		}

	}
}
