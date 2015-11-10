using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

namespace SpriteStudioForUnity
{
	public class SSController : MonoBehaviour
	{
		public bool flipX;
		bool _flipX;
		public bool flipY;
		bool _flipY;

		public Action<int> OnIntegerEvent;
		public Action<Vector3> OnRectEvent;
		public Action<Vector2> OnPointEvent;
		public Action<string> OnStringEvent;
		public List<SSCell> cellList;
		[HideInInspector]
		public List<SSPart> partList;

		void Start ()
		{
		}

		void Update () 
		{
			if (flipX != _flipX) {
				_flipX = flipX;
				transform.Rotate(0, 180, 0);
				foreach(SSPart part in partList){
					part.flipX = flipX;
				}
			}

			if (flipY != _flipY) {
				_flipY = flipY;
				transform.Rotate(180, 0, 0);
				foreach(SSPart part in partList){
					part.flipY = flipY;
				}
			}

		}
	
	}
}
