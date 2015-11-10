using UnityEngine;
using System.Collections;

namespace SpriteStudioForUnity
{
	[RequireComponent(typeof(MeshRenderer))]
	[RequireComponent(typeof(MeshFilter))]
	[ExecuteInEditMode]
	public class SSPart : MonoBehaviour
	{
		[HideInInspector]
		public int arrayIndex;
		[HideInInspector]
		public int parentIndex;
		[HideInInspector]
		public SSPart parent;
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

		public float cellId = -1;
		float _cellId = -1;
		public float alpha = 1;
		float _alpha;
		public Vector3 pos;
		Vector3 _pos;
		public Vector3 rot;
		Vector3 _rot;
		public bool flpH;
		bool _flpH;
		public bool flpV;
		bool _flpV;
		public Vector2 pvt;
		Vector2 _pvt;
		public Vector2 anc;
		Vector2 _anc;
		public Vector2 siz;
		Vector2 _siz;
		public Vector2 uvt;
		Vector2 _uvt;
		public Color vcolLB = new Color (1, 1, 1, 1);
		Color _vcolLB = new Color (1, 1, 1, 1);
		public Color vcolRB = new Color (1, 1, 1, 1);
		Color _vcolRB = new Color (1, 1, 1, 1);
		public Color vcolLT = new Color (1, 1, 1, 1);
		Color _vcolLT = new Color (1, 1, 1, 1);
		public Color vcolRT = new Color (1, 1, 1, 1);
		Color _vcolRT = new Color (1, 1, 1, 1);
		public float uv2XLB = 1;
		float _uv2XLB = 1;
		public float uv2XRB = 1;
		float _uv2XRB = 1;
		public float uv2XLT = 1;
		float _uv2XLT = 1;
		public float uv2XRT = 1;
		float _uv2XRT = 1;
		public float uv2Y;
		float _uv2Y;
		public Vector2 vertLB = Vector2.zero;
		Vector2 _vertLB = Vector2.zero;
		public Vector2 vertRB = Vector2.zero;
		Vector2 _vertRB = Vector2.zero;
		public Vector2 vertLT = Vector2.zero;
		Vector2 _vertLT = Vector2.zero;
		public Vector2 vertRT = Vector2.zero;
		Vector2 _vertRT = Vector2.zero;

		public SSCell cell;
		[HideInInspector]
		public SSController controller;
		MeshRenderer meshRenderer;
		MeshFilter meshFilter;
		Mesh mesh;
		float opacity = 1;
		float _opacity = 1;
		bool isTriangle4 = false;
		public bool flipX;
		bool _flipX;
		public bool flipY;
		bool _flipY;

		void Start ()
		{
			meshRenderer = GetComponent<MeshRenderer> ();
			meshFilter = GetComponent<MeshFilter> ();
			mesh = new Mesh ();
			mesh.MarkDynamic ();
			meshFilter.sharedMesh = mesh;
			UpdateMesh ();
			Vector3 localPosition = transform.localPosition;
			localPosition.z = pos.z * -0.01f + arrayIndex * -0.0001f;
			transform.localPosition = localPosition;
		}
		
		void Update ()
		{
			if (pos.x != _pos.x) {
				_pos.x = pos.x;
				Vector3 localPosition = transform.localPosition;
				localPosition.x = pos.x;
				transform.localPosition = localPosition;
			}
			if (pos.y != _pos.y) {
				_pos.y = pos.y;
				Vector3 localPosition = transform.localPosition;
				localPosition.y = pos.y;
				transform.localPosition = localPosition;
			}	
			bool zFlg = false;
			if (pos.z != _pos.z) {
				_pos.z = pos.z;
				zFlg = true;
			}
			if (flipX != _flipX) {
				_flipX = flipX;
				zFlg = true;
			}
			if (flipY != _flipY) {
				_flipY = flipY;
				zFlg = true;
			}

			if (zFlg) {
				if((flipX && !flipY) || (!flipX && flipY)){
					Vector3 localPosition = transform.localPosition;
					localPosition.z = pos.z * 0.01f + arrayIndex * 0.0001f;
					transform.localPosition = localPosition;
				}else{
					Vector3 localPosition = transform.localPosition;
					localPosition.z = pos.z * -0.01f + arrayIndex * -0.0001f;
					transform.localPosition = localPosition;
				}
			}


			if (rot.x != _rot.x) {
				_rot.x = rot.x;
				Vector3 localEulerAngles = transform.localEulerAngles;
				localEulerAngles.x = rot.x;
				transform.localEulerAngles = localEulerAngles;
			}
			if (rot.y != _rot.y) {
				_rot.y = rot.y;
				Vector3 localEulerAngles = transform.localEulerAngles;
				localEulerAngles.y = rot.y;
				transform.localEulerAngles = localEulerAngles;
			}
			if (rot.z != _rot.z) {
				_rot.z = rot.z;
				Vector3 localEulerAngles = transform.localEulerAngles;
				localEulerAngles.z = rot.z;
				transform.localEulerAngles = localEulerAngles;
			}

			if (partType == PartType.Null)
				return;

			if (cellId == -1) {
				meshRenderer.enabled = false;
				return;
			}            

			if (inheritType == PartInheritType.Parent) {
				SSPart current = parent;
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

			if (uv2Y != _uv2Y) {
				_uv2Y = uv2Y;
				meshFlg = true;
			}

			if (opacity != _opacity) {
				_opacity = opacity;
				meshFlg = true;
			}

			if (vcolLB != _vcolLB) {
				_vcolLB = vcolLB;
				meshFlg = true;
			}
			if (vcolRB != _vcolRB) {
				_vcolRB = vcolRB;
				meshFlg = true;
			}
			if (vcolLT != _vcolLT) {
				_vcolLT = vcolLT;
				meshFlg = true;
			}
			if (vcolRT != _vcolRT) {
				_vcolRT = vcolRT;
				meshFlg = true;
			}

			if (uv2XLB != _uv2XLB) {
				_uv2XLB = uv2XLB;
				meshFlg = true;
			}
			if (uv2XRB != _uv2XRB) {
				_uv2XRB = uv2XRB;
				meshFlg = true;
			}
			if (uv2XLT != _uv2XLT) {
				_uv2XLT = uv2XLT;
				meshFlg = true;
			}
			if (uv2XRT != _uv2XRT) {
				_uv2XRT = uv2XRT;
				meshFlg = true;
			}

			if (flpH != _flpH) {
				_flpH = flpH;
				meshFlg = true;
			}

			if (flpV != _flpV) {
				_flpV = flpV;
				meshFlg = true;
			}

			if (pvt.x != _pvt.x) {
				_pvt.x = pvt.x;
				meshFlg = true;
			}
			if (pvt.y != _pvt.y) {
				_pvt.y = pvt.y;
				meshFlg = true;
			}

			if (vertRB != _vertRB) {
				_vertRB = vertRB;
				isTriangle4 = true;
				meshFlg = true;
			}
			
			if (vertLB != _vertLB) {
				_vertLB = vertLB;
				isTriangle4 = true;
				meshFlg = true;
			}

			if (vertLT != _vertLT) {
				_vertLT = vertLT;
				isTriangle4 = true;
				meshFlg = true;
			}

			if (vertRT != _vertRT) {
				_vertRT = vertRT;
				meshFlg = true;
				isTriangle4 = true;
			}

			if (uvt.x != _uvt.x) {
				_uvt.x = uvt.x;
				meshFlg = true;
			}

			if (uvt.y != _uvt.y) {
				_uvt.y = uvt.y;
				meshFlg = true;
			}

			if (siz.x != _siz.x) {
				_siz.x = siz.x;
				meshFlg = true;
			}

			if (siz.y != _siz.y) {
				_siz.y = siz.y;
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

			float vL, vR, vB, vT;
			Vector2 size = cell.size;
			if (siz.x != 0) {
				size.x = siz.x;
			}
			if (siz.y != 0) {
				size.y = siz.y;
			}
			if (flpH) {
				vL = size.x * (-0.5f + cell.pivot.x - pvt.x);
				vR = size.x * (0.5f + cell.pivot.x - pvt.x);
			} else {
				vL = size.x * (-0.5f - cell.pivot.x - pvt.x);
				vR = size.x * (0.5f - cell.pivot.x - pvt.x);
			}
			if (flpV) {
				vB = size.y * (-0.5f + cell.pivot.y - pvt.y);
				vT = size.y * (0.5f + cell.pivot.y - pvt.y);
			} else {
				vB = size.y * (-0.5f - cell.pivot.y - pvt.y);
				vT = size.y * (0.5f - cell.pivot.y - pvt.y);
			}            
			Vector3 vLT = new Vector3 (vL + vertLT.x, vT + vertLT.y, 0.0f);
			Vector3 vRT = new Vector3 (vR + vertRT.x, vT + vertRT.y, 0.0f);
			Vector3 vRB = new Vector3 (vR + vertRB.x, vB + vertRB.y, 0.0f);
			Vector3 vLB = new Vector3 (vL + vertLB.x, vB + vertLB.y, 0.0f);

			Vector2 uvLT = new Vector2 (cell.uvL + uvt.x, cell.uvT - uvt.y);
			Vector2 uvRT = new Vector2 (cell.uvR + uvt.x, cell.uvT - uvt.y);
			Vector2 uvRB = new Vector2 (cell.uvR + uvt.x, cell.uvB - uvt.y);
			Vector2 uvLB = new Vector2 (cell.uvL + uvt.x, cell.uvB - uvt.y);

			if (isTriangle4) {
				Vector3 vC = Vector3.Lerp (Vector3.Lerp (vLB, vRB, 0.5f), Vector3.Lerp (vLT, vRT, 0.5f), 0.5f);
				if (flpH && flpV) {
					mesh.vertices = new Vector3[]{ vRB,vLB,vLT,vRT,vC,};
				} else if (flpH) {
					mesh.vertices = new Vector3[]{ vRT,vLT,vLB,vRB,vC,};
				} else if (flpV) {
					mesh.vertices = new Vector3[]{ vLB,vRB,vRT,vLT,vC,};
				} else {
					mesh.vertices = new Vector3[]{ vLT,vRT,vRB,vLB,vC,};
				}

				Vector2 uvC = Vector2.Lerp (uvLB, uvRT, 0.5f);
				mesh.uv = new Vector2[]{ 
					uvLT,
					uvRT,
					uvRB,
					uvLB,
					uvC,
				};
				mesh.uv2 = new Vector2[]
				{
					new Vector2 (opacity * uv2XLT, uv2Y + 0.01f),
					new Vector2 (opacity * uv2XRT, uv2Y + 0.01f),
					new Vector2 (opacity * uv2XRB, uv2Y + 0.01f),
					new Vector2 (opacity * uv2XLB, uv2Y + 0.01f),
					new Vector2 (opacity * (uv2XLT + uv2XRT + uv2XRB + uv2XLB) / 4, uv2Y + 0.01f),
				};
				mesh.triangles = new int[]
				{
					0, 1, 4,
					1, 2, 4,
					2, 3, 4,
					3, 0, 4,
				};
				mesh.colors32 = new Color32[]
				{
					vcolLT,
					vcolRT,
					vcolRB,
					vcolLB,
					Color.Lerp (Color.Lerp (vcolLB, vcolRB, 0.5f), Color.Lerp (vcolLT, vcolRT, 0.5f), 0.5f),
				};
			} else {
				if (flpH && flpV) {
					mesh.vertices = new Vector3[]{ vRB,vLB,vLT,vRT,};
				} else if (flpH) {
					mesh.vertices = new Vector3[]{ vRT,vLT,vLB,vRB,};
				} else if (flpV) {
					mesh.vertices = new Vector3[]{ vLB,vRB,vRT,vLT,};
				} else {
					mesh.vertices = new Vector3[]{ vLT,vRT,vRB,vLB,};
				}
				mesh.uv = new Vector2[]{ 
					uvLT,
					uvRT,
					uvRB,
					uvLB,
				};
				mesh.uv2 = new Vector2[]
				{
					new Vector2 (opacity * uv2XLT, uv2Y + 0.01f),
					new Vector2 (opacity * uv2XRT, uv2Y + 0.01f),
					new Vector2 (opacity * uv2XRB, uv2Y + 0.01f),
					new Vector2 (opacity * uv2XLB, uv2Y + 0.01f),
				};
				mesh.triangles = new int[]
				{
					0, 1, 2,
					2, 3, 0,
				};
				mesh.colors32 = new Color32[]
				{
					vcolLT,
					vcolRT,
					vcolRB,
					vcolLB,
				};
			}

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
