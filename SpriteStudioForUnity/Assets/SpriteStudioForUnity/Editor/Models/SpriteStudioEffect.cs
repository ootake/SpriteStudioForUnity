namespace SpriteStudioForUnity
{	
	public partial class SpriteStudioEffect
	{
        public string name;
        public object exportPath;
        public SpriteStudioEffectEffectData effectData;
		[System.Xml.Serialization.XmlAttributeAttribute()]
        public string version;
	}
	
	public partial class SpriteStudioEffectEffectData
	{
        public byte lockRandSeed;
        public byte isLockRandSeed;
        public byte fps;
        public string bgcolor;
		[System.Xml.Serialization.XmlArrayItemAttribute("node", IsNullable = false)]
        public SpriteStudioEffectEffectDataNode[] nodeList;
	}
	
	public partial class SpriteStudioEffectEffectDataNode
	{
        public string name;
        public string type;
        public byte arrayIndex;
        public sbyte parentIndex;
        public byte visible;
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
        public SpriteStudioEffectEffectDataNodeBehaviorValueDisprange disprange;
        public SpriteStudioEffectEffectDataNodeBehaviorValueSizeX SizeX;
        public SpriteStudioEffectEffectDataNodeBehaviorValueSizeY SizeY;
        public SpriteStudioEffectEffectDataNodeBehaviorValueScaleFactor ScaleFactor;
        public SpriteStudioEffectEffectDataNodeBehaviorValueRotation Rotation;
        public SpriteStudioEffectEffectDataNodeBehaviorValueRotationAdd RotationAdd;
        public byte DelayTime;
		[System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool DelayTimeSpecified;
        public byte priority;
		[System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool prioritySpecified;
        public byte maximumParticle;
		[System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool maximumParticleSpecified;
        public byte attimeCreate;
		[System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool attimeCreateSpecified;
        public byte interval;
		[System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool intervalSpecified;
        public byte lifetime;
		[System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool lifetimeSpecified;
        public SpriteStudioEffectEffectDataNodeBehaviorValueSpeed speed;
        public SpriteStudioEffectEffectDataNodeBehaviorValueLifespan lifespan;
        public byte angle;
		[System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool angleSpecified;
        public ushort angleVariance;
		[System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool angleVarianceSpecified;
		[System.Xml.Serialization.XmlAttributeAttribute("name")]
        public string name1;
	}
	
	public partial class SpriteStudioEffectEffectDataNodeBehaviorValueDisprange
	{
		[System.Xml.Serialization.XmlAttributeAttribute()]
        public decimal value;
		[System.Xml.Serialization.XmlAttributeAttribute()]
        public decimal subvalue;
	}
	
	public partial class SpriteStudioEffectEffectDataNodeBehaviorValueSizeX
	{
		[System.Xml.Serialization.XmlAttributeAttribute()]
        public decimal value;
		[System.Xml.Serialization.XmlAttributeAttribute()]
        public decimal subvalue;
	}
	
	public partial class SpriteStudioEffectEffectDataNodeBehaviorValueSizeY
	{
		[System.Xml.Serialization.XmlAttributeAttribute()]
        public byte value;
		[System.Xml.Serialization.XmlAttributeAttribute()]
        public decimal subvalue;
	}
	
	public partial class SpriteStudioEffectEffectDataNodeBehaviorValueScaleFactor
	{
		[System.Xml.Serialization.XmlAttributeAttribute()]
        public decimal value;
		[System.Xml.Serialization.XmlAttributeAttribute()]
        public decimal subvalue;
	}
	
	public partial class SpriteStudioEffectEffectDataNodeBehaviorValueRotation
	{
		[System.Xml.Serialization.XmlAttributeAttribute()]
        public decimal value;
		[System.Xml.Serialization.XmlAttributeAttribute()]
        public decimal subvalue;
	}
	
	public partial class SpriteStudioEffectEffectDataNodeBehaviorValueRotationAdd
	{
		[System.Xml.Serialization.XmlAttributeAttribute()]
        public byte value;
		[System.Xml.Serialization.XmlAttributeAttribute()]
        public decimal subvalue;
	}
	
	public partial class SpriteStudioEffectEffectDataNodeBehaviorValueSpeed
	{
		[System.Xml.Serialization.XmlAttributeAttribute()]
        public decimal value;
		[System.Xml.Serialization.XmlAttributeAttribute()]
        public decimal subvalue;
	}
	
	public partial class SpriteStudioEffectEffectDataNodeBehaviorValueLifespan
	{
		[System.Xml.Serialization.XmlAttributeAttribute()]
        public byte value;
		[System.Xml.Serialization.XmlAttributeAttribute()]
        public byte subvalue;
	}	
}
