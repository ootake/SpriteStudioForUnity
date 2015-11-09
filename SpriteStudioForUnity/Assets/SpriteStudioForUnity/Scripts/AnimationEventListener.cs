using UnityEngine;
using System.Collections;

namespace SpriteStudioForUnity {
	[RequireComponent(typeof(Animator))]
	public class AnimationEventListener : MonoBehaviour {
		[HideInInspector]
		public SSController controller;

		void Start ()
		{
		}
		
		void IntegerEvent (int val)
		{
			if (controller.OnIntegerEvent != null) {
				controller.OnIntegerEvent (val);
			}
		}
		
		void RectEvent (string val)
		{
			if (controller.OnRectEvent != null) {
				string[] split = val.Split (' ');
				float x = float.Parse (split [0]);
				float y = float.Parse (split [1]);
				float z = float.Parse (split [2]);
				Vector3 v = new Vector3 (x, y, z);
				controller.OnRectEvent (v);
			}
		}
		
		void PointEvent (string val)
		{
			if (controller.OnPointEvent != null) {
				string[] split = val.Split (' ');
				float x = float.Parse (split [0]);
				float y = float.Parse (split [1]);
				Vector2 v = new Vector2 (x, y);
				controller.OnPointEvent (v);
			}
		}
		
		void StringEvent (string val)
		{
			if (controller.OnStringEvent != null) {
				controller.OnStringEvent (val);
			}
		}
	}
}

