using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

namespace SpriteStudioForUnity
{
	[RequireComponent(typeof(Animator))]
	public class SpriteStudioController : MonoBehaviour
	{
		public Animator animator;
		public Action<int> OnIntegerEvent;
		public Action<Vector3> OnRectEvent;
		public Action<Vector2> OnPointEvent;
		public Action<string> OnStringEvent;
		public List<SpriteStudioCell> cellList;

		void Start ()
		{
			animator = GetComponent<Animator> ();
		}

		void IntegerEvent (int val)
		{
			if (OnIntegerEvent != null) {
				OnIntegerEvent (val);
			}
		}

		void RectEvent (string val)
		{
			if (OnRectEvent != null) {
				string[] split = val.Split (' ');
				float x = float.Parse (split [0]);
				float y = float.Parse (split [1]);
				float z = float.Parse (split [2]);
				Vector3 v = new Vector3 (x, y, z);
				OnRectEvent (v);
			}
		}

		void PointEvent (string val)
		{
			if (OnPointEvent != null) {
				string[] split = val.Split (' ');
				float x = float.Parse (split [0]);
				float y = float.Parse (split [1]);
				Vector2 v = new Vector2 (x, y);
				OnPointEvent (v);
			}
		}
		
		void StringEvent (string val)
		{
			if (OnStringEvent != null) {
				OnStringEvent (val);
			}
		}		
	}
}
