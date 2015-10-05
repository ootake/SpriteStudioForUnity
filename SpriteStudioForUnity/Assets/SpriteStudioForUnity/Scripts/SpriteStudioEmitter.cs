using UnityEngine;
using System.Collections;

namespace SpriteStudioForUnity
{
    public class SpriteStudioEmitterOverWriteSeed
    {
        public int seed;
    }

    public class SpriteStudioEmitterDelay
    {
        public int delayTime;
    }

    public class SpriteStudioEmitterGravity
    {
        public Vector2 gravity;
    }

    public class SpriteStudioEmitterInitPosition
    {
        public float startOffsetX;
        public float endOffsetX;
        public float startOffsetY;
        public float endOffsetY;
    }

    public class SpriteStudioEmitterTransSpeed
    {
        public float startSpeed;
        public float endSpeed;
    }

    public class SpriteStudioEmitterInitRotation
    {
    }

    public class SpriteStudioEmitterTransToration
    {
    }

    public class SpriteStudioEmitterAddTangentiala
    {
    }

    public class SpriteStudioEmitterAddPointGravity
    {
    }

    public class SpriteStudioEmitterInitVertexColor
    {
    }

    public class SpriteStudioEmitterTransVertexColor
    {
    }

    public class SpriteStudioEmitterInitSize
    {
    }

    public class SpriteStudioEmitterTransSize
    {
    }

    public class SpriteStudioEmitterTransColorFade
    {
    }


    public class SpriteStudioEmitter : MonoBehaviour
    {
        public int fps;
        public int priority;
        public int maximumParticle;
        public int attimeCreate;
        public int lifetime;
        public double minSpeed;
        public double maxSpeed;
        public double minLifespan;
        public double maxLifespan;
        public double angle;
        public double angleVariance;

        ParticleSystem particleSystem;

        void Start()
        {
            particleSystem = gameObject.AddComponent<ParticleSystem>();

        }

        void Update()
        {
            
        }
    }
}
