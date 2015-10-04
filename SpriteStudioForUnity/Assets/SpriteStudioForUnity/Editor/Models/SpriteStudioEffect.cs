namespace SpriteStudioForUnity
{	
	public partial class SpriteStudioEffect
	{
        public string name;
        public string exportPath;
        public SpriteStudioEffectEffectData effectData;
		[System.Xml.Serialization.XmlAttributeAttribute()]
        public string version;
	}
	
	public partial class SpriteStudioEffectEffectData
	{
        public int lockRandSeed;
        public int isLockRandSeed;
        public int fps;
        public string bgcolor;
		[System.Xml.Serialization.XmlArrayItemAttribute("node", IsNullable = false)]
        public SpriteStudioEffectEffectDataNode[] nodeList;
	}
	
	public partial class SpriteStudioEffectEffectDataNode
	{
        public string name;
        public string type;
        public int arrayIndex;
        public int parentIndex;
        public int visible;
        public SpriteStudioEffectEffectDataNodeBehavior behavior;
	}
	
	public partial class SpriteStudioEffectEffectDataNodeBehavior
	{
        public string CellName;
        public string CellMapName;
        public string BlendType;
		[System.Xml.Serialization.XmlArrayItemAttribute("value", IsNullable = false)]
        public SpriteStudioEffectEffectDataNodeBehaviorValue[] list;
	}
	
	public partial class SpriteStudioEffectEffectDataNodeBehaviorValue
	{
        public string name;
        public SpriteStudioEffectEffectDataNodeBehaviorValueDouble disprange;
        public SpriteStudioEffectEffectDataNodeBehaviorValueDouble SizeX;
        public SpriteStudioEffectEffectDataNodeBehaviorValueDouble SizeY;
        public SpriteStudioEffectEffectDataNodeBehaviorValueDouble ScaleFactor;
        public SpriteStudioEffectEffectDataNodeBehaviorValueDouble Rotation;
        public SpriteStudioEffectEffectDataNodeBehaviorValueDouble RotationAdd;
        public SpriteStudioEffectEffectDataNodeBehaviorValueDouble OffsetX;
        public SpriteStudioEffectEffectDataNodeBehaviorValueDouble OffsetY;
        public SpriteStudioEffectEffectDataNodeBehaviorValueString Color;
        public string Gravity;
        public double EndLifeTimePer;
        public int DelayTime;
		[System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool DelayTimeSpecified;
        public int priority;
		[System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool prioritySpecified;
        public int maximumParticle;
		[System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool maximumParticleSpecified;
        public int attimeCreate;
		[System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool attimeCreateSpecified;
        public int interval;
		[System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool intervalSpecified;
        public int lifetime;
		[System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool lifetimeSpecified;
        public SpriteStudioEffectEffectDataNodeBehaviorValueDouble speed;
        public SpriteStudioEffectEffectDataNodeBehaviorValueDouble lifespan;
        public double angle;
		[System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool angleSpecified;
        public double angleVariance;
		[System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool angleVarianceSpecified;
		[System.Xml.Serialization.XmlAttributeAttribute("name")]
        public string name1;
	}
	
	public partial class SpriteStudioEffectEffectDataNodeBehaviorValueDouble
	{
		[System.Xml.Serialization.XmlAttributeAttribute()]
        public double value;
		[System.Xml.Serialization.XmlAttributeAttribute()]
        public double subvalue;
	}

    public partial class SpriteStudioEffectEffectDataNodeBehaviorValueString
    {
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string value;
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string subvalue;
    }
}
