using UnityEngine;
using System.Collections;

namespace SpriteStudioForUnity
{
	[RequireComponent(typeof(ParticleSystem))]
    public class SpriteStudioEmitter : MonoBehaviour
    {
        public ParticleSystem particleSystem;

        void Start()
        {
			particleSystem = GetComponent<ParticleSystem> ();
        }

        void Update()
        {
            
        }
    }
}
