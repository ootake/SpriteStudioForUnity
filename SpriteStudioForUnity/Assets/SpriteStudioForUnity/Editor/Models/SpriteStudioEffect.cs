namespace SpriteStudioForUnity
{	
	/// <remarks/>
	[System.SerializableAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	[System.Xml.Serialization.XmlRootAttribute(Namespace = "", IsNullable = false)]
	public partial class SpriteStudioEffect
	{
		
		private string nameField;
		private object exportPathField;
		private SpriteStudioEffectEffectData effectDataField;
		private string versionField;
		
		/// <remarks/>
		public string name {
			get {
				return this.nameField;
			}
			set {
				this.nameField = value;
			}
		}
		
		/// <remarks/>
		public object exportPath {
			get {
				return this.exportPathField;
			}
			set {
				this.exportPathField = value;
			}
		}
		
		/// <remarks/>
		public SpriteStudioEffectEffectData effectData {
			get {
				return this.effectDataField;
			}
			set {
				this.effectDataField = value;
			}
		}
		
		/// <remarks/>
		[System.Xml.Serialization.XmlAttributeAttribute()]
		public string version {
			get {
				return this.versionField;
			}
			set {
				this.versionField = value;
			}
		}
	}
	
	/// <remarks/>
	[System.SerializableAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class SpriteStudioEffectEffectData
	{
		
		private byte lockRandSeedField;
		private byte isLockRandSeedField;
		private byte fpsField;
		private string bgcolorField;
		private SpriteStudioEffectEffectDataNode[] nodeListField;
		
		/// <remarks/>
		public byte lockRandSeed {
			get {
				return this.lockRandSeedField;
			}
			set {
				this.lockRandSeedField = value;
			}
		}
		
		/// <remarks/>
		public byte isLockRandSeed {
			get {
				return this.isLockRandSeedField;
			}
			set {
				this.isLockRandSeedField = value;
			}
		}
		
		/// <remarks/>
		public byte fps {
			get {
				return this.fpsField;
			}
			set {
				this.fpsField = value;
			}
		}
		
		/// <remarks/>
		public string bgcolor {
			get {
				return this.bgcolorField;
			}
			set {
				this.bgcolorField = value;
			}
		}
		
		/// <remarks/>
		[System.Xml.Serialization.XmlArrayItemAttribute("node", IsNullable = false)]
		public SpriteStudioEffectEffectDataNode[] nodeList {
			get {
				return this.nodeListField;
			}
			set {
				this.nodeListField = value;
			}
		}
	}
	
	/// <remarks/>
	[System.SerializableAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class SpriteStudioEffectEffectDataNode
	{
		
		private string nameField;
		private string typeField;
		private byte arrayIndexField;
		private sbyte parentIndexField;
		private byte visibleField;
		private SpriteStudioEffectEffectDataNodeBehavior behaviorField;
		
		/// <remarks/>
		public string name {
			get {
				return this.nameField;
			}
			set {
				this.nameField = value;
			}
		}
		
		/// <remarks/>
		public string type {
			get {
				return this.typeField;
			}
			set {
				this.typeField = value;
			}
		}
		
		/// <remarks/>
		public byte arrayIndex {
			get {
				return this.arrayIndexField;
			}
			set {
				this.arrayIndexField = value;
			}
		}
		
		/// <remarks/>
		public sbyte parentIndex {
			get {
				return this.parentIndexField;
			}
			set {
				this.parentIndexField = value;
			}
		}
		
		/// <remarks/>
		public byte visible {
			get {
				return this.visibleField;
			}
			set {
				this.visibleField = value;
			}
		}
		
		/// <remarks/>
		public SpriteStudioEffectEffectDataNodeBehavior behavior {
			get {
				return this.behaviorField;
			}
			set {
				this.behaviorField = value;
			}
		}
	}
	
	/// <remarks/>
	[System.SerializableAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class SpriteStudioEffectEffectDataNodeBehavior
	{
		
		private string cellNameField;
		private string cellMapNameField;
		private string blendTypeField;
		private SpriteStudioEffectEffectDataNodeBehaviorValue[] listField;
		
		/// <remarks/>
		public string CellName {
			get {
				return this.cellNameField;
			}
			set {
				this.cellNameField = value;
			}
		}
		
		/// <remarks/>
		public string CellMapName {
			get {
				return this.cellMapNameField;
			}
			set {
				this.cellMapNameField = value;
			}
		}
		
		/// <remarks/>
		public string BlendType {
			get {
				return this.blendTypeField;
			}
			set {
				this.blendTypeField = value;
			}
		}
		
		/// <remarks/>
		[System.Xml.Serialization.XmlArrayItemAttribute("value", IsNullable = false)]
		public SpriteStudioEffectEffectDataNodeBehaviorValue[] list {
			get {
				return this.listField;
			}
			set {
				this.listField = value;
			}
		}
	}
	
	/// <remarks/>
	[System.SerializableAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class SpriteStudioEffectEffectDataNodeBehaviorValue
	{
		
		private string nameField;
		private SpriteStudioEffectEffectDataNodeBehaviorValueDisprange disprangeField;
		private SpriteStudioEffectEffectDataNodeBehaviorValueSizeX sizeXField;
		private SpriteStudioEffectEffectDataNodeBehaviorValueSizeY sizeYField;
		private SpriteStudioEffectEffectDataNodeBehaviorValueScaleFactor scaleFactorField;
		private SpriteStudioEffectEffectDataNodeBehaviorValueRotation rotationField;
		private SpriteStudioEffectEffectDataNodeBehaviorValueRotationAdd rotationAddField;
		private byte delayTimeField;
		private bool delayTimeFieldSpecified;
		private byte priorityField;
		private bool priorityFieldSpecified;
		private byte maximumParticleField;
		private bool maximumParticleFieldSpecified;
		private byte attimeCreateField;
		private bool attimeCreateFieldSpecified;
		private byte intervalField;
		private bool intervalFieldSpecified;
		private byte lifetimeField;
		private bool lifetimeFieldSpecified;
		private SpriteStudioEffectEffectDataNodeBehaviorValueSpeed speedField;
		private SpriteStudioEffectEffectDataNodeBehaviorValueLifespan lifespanField;
		private byte angleField;
		private bool angleFieldSpecified;
		private ushort angleVarianceField;
		private bool angleVarianceFieldSpecified;
		private string name1Field;
		
		/// <remarks/>
		public string name {
			get {
				return this.nameField;
			}
			set {
				this.nameField = value;
			}
		}
		
		/// <remarks/>
		public SpriteStudioEffectEffectDataNodeBehaviorValueDisprange disprange {
			get {
				return this.disprangeField;
			}
			set {
				this.disprangeField = value;
			}
		}
		
		/// <remarks/>
		public SpriteStudioEffectEffectDataNodeBehaviorValueSizeX SizeX {
			get {
				return this.sizeXField;
			}
			set {
				this.sizeXField = value;
			}
		}
		
		/// <remarks/>
		public SpriteStudioEffectEffectDataNodeBehaviorValueSizeY SizeY {
			get {
				return this.sizeYField;
			}
			set {
				this.sizeYField = value;
			}
		}
		
		/// <remarks/>
		public SpriteStudioEffectEffectDataNodeBehaviorValueScaleFactor ScaleFactor {
			get {
				return this.scaleFactorField;
			}
			set {
				this.scaleFactorField = value;
			}
		}
		
		/// <remarks/>
		public SpriteStudioEffectEffectDataNodeBehaviorValueRotation Rotation {
			get {
				return this.rotationField;
			}
			set {
				this.rotationField = value;
			}
		}
		
		/// <remarks/>
		public SpriteStudioEffectEffectDataNodeBehaviorValueRotationAdd RotationAdd {
			get {
				return this.rotationAddField;
			}
			set {
				this.rotationAddField = value;
			}
		}
		
		/// <remarks/>
		public byte DelayTime {
			get {
				return this.delayTimeField;
			}
			set {
				this.delayTimeField = value;
			}
		}
		
		/// <remarks/>
		[System.Xml.Serialization.XmlIgnoreAttribute()]
		public bool DelayTimeSpecified {
			get {
				return this.delayTimeFieldSpecified;
			}
			set {
				this.delayTimeFieldSpecified = value;
			}
		}
		
		/// <remarks/>
		public byte priority {
			get {
				return this.priorityField;
			}
			set {
				this.priorityField = value;
			}
		}
		
		/// <remarks/>
		[System.Xml.Serialization.XmlIgnoreAttribute()]
		public bool prioritySpecified {
			get {
				return this.priorityFieldSpecified;
			}
			set {
				this.priorityFieldSpecified = value;
			}
		}
		
		/// <remarks/>
		public byte maximumParticle {
			get {
				return this.maximumParticleField;
			}
			set {
				this.maximumParticleField = value;
			}
		}
		
		/// <remarks/>
		[System.Xml.Serialization.XmlIgnoreAttribute()]
		public bool maximumParticleSpecified {
			get {
				return this.maximumParticleFieldSpecified;
			}
			set {
				this.maximumParticleFieldSpecified = value;
			}
		}
		
		/// <remarks/>
		public byte attimeCreate {
			get {
				return this.attimeCreateField;
			}
			set {
				this.attimeCreateField = value;
			}
		}
		
		/// <remarks/>
		[System.Xml.Serialization.XmlIgnoreAttribute()]
		public bool attimeCreateSpecified {
			get {
				return this.attimeCreateFieldSpecified;
			}
			set {
				this.attimeCreateFieldSpecified = value;
			}
		}
		
		/// <remarks/>
		public byte interval {
			get {
				return this.intervalField;
			}
			set {
				this.intervalField = value;
			}
		}
		
		/// <remarks/>
		[System.Xml.Serialization.XmlIgnoreAttribute()]
		public bool intervalSpecified {
			get {
				return this.intervalFieldSpecified;
			}
			set {
				this.intervalFieldSpecified = value;
			}
		}
		
		/// <remarks/>
		public byte lifetime {
			get {
				return this.lifetimeField;
			}
			set {
				this.lifetimeField = value;
			}
		}
		
		/// <remarks/>
		[System.Xml.Serialization.XmlIgnoreAttribute()]
		public bool lifetimeSpecified {
			get {
				return this.lifetimeFieldSpecified;
			}
			set {
				this.lifetimeFieldSpecified = value;
			}
		}
		
		/// <remarks/>
		public SpriteStudioEffectEffectDataNodeBehaviorValueSpeed speed {
			get {
				return this.speedField;
			}
			set {
				this.speedField = value;
			}
		}
		
		/// <remarks/>
		public SpriteStudioEffectEffectDataNodeBehaviorValueLifespan lifespan {
			get {
				return this.lifespanField;
			}
			set {
				this.lifespanField = value;
			}
		}
		
		/// <remarks/>
		public byte angle {
			get {
				return this.angleField;
			}
			set {
				this.angleField = value;
			}
		}
		
		/// <remarks/>
		[System.Xml.Serialization.XmlIgnoreAttribute()]
		public bool angleSpecified {
			get {
				return this.angleFieldSpecified;
			}
			set {
				this.angleFieldSpecified = value;
			}
		}
		
		/// <remarks/>
		public ushort angleVariance {
			get {
				return this.angleVarianceField;
			}
			set {
				this.angleVarianceField = value;
			}
		}
		
		/// <remarks/>
		[System.Xml.Serialization.XmlIgnoreAttribute()]
		public bool angleVarianceSpecified {
			get {
				return this.angleVarianceFieldSpecified;
			}
			set {
				this.angleVarianceFieldSpecified = value;
			}
		}
		
		/// <remarks/>
		[System.Xml.Serialization.XmlAttributeAttribute("name")]
		public string name1 {
			get {
				return this.name1Field;
			}
			set {
				this.name1Field = value;
			}
		}
	}
	
	/// <remarks/>
	[System.SerializableAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class SpriteStudioEffectEffectDataNodeBehaviorValueDisprange
	{
		
		private decimal valueField;
		private decimal subvalueField;
		
		/// <remarks/>
		[System.Xml.Serialization.XmlAttributeAttribute()]
		public decimal value {
			get {
				return this.valueField;
			}
			set {
				this.valueField = value;
			}
		}
		
		/// <remarks/>
		[System.Xml.Serialization.XmlAttributeAttribute()]
		public decimal subvalue {
			get {
				return this.subvalueField;
			}
			set {
				this.subvalueField = value;
			}
		}
	}
	
	/// <remarks/>
	[System.SerializableAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class SpriteStudioEffectEffectDataNodeBehaviorValueSizeX
	{
		
		private decimal valueField;
		private decimal subvalueField;
		
		/// <remarks/>
		[System.Xml.Serialization.XmlAttributeAttribute()]
		public decimal value {
			get {
				return this.valueField;
			}
			set {
				this.valueField = value;
			}
		}
		
		/// <remarks/>
		[System.Xml.Serialization.XmlAttributeAttribute()]
		public decimal subvalue {
			get {
				return this.subvalueField;
			}
			set {
				this.subvalueField = value;
			}
		}
	}
	
	/// <remarks/>
	[System.SerializableAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class SpriteStudioEffectEffectDataNodeBehaviorValueSizeY
	{
		
		private byte valueField;
		private decimal subvalueField;
		
		/// <remarks/>
		[System.Xml.Serialization.XmlAttributeAttribute()]
		public byte value {
			get {
				return this.valueField;
			}
			set {
				this.valueField = value;
			}
		}
		
		/// <remarks/>
		[System.Xml.Serialization.XmlAttributeAttribute()]
		public decimal subvalue {
			get {
				return this.subvalueField;
			}
			set {
				this.subvalueField = value;
			}
		}
	}
	
	/// <remarks/>
	[System.SerializableAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class SpriteStudioEffectEffectDataNodeBehaviorValueScaleFactor
	{
		
		private decimal valueField;
		private decimal subvalueField;
		
		/// <remarks/>
		[System.Xml.Serialization.XmlAttributeAttribute()]
		public decimal value {
			get {
				return this.valueField;
			}
			set {
				this.valueField = value;
			}
		}
		
		/// <remarks/>
		[System.Xml.Serialization.XmlAttributeAttribute()]
		public decimal subvalue {
			get {
				return this.subvalueField;
			}
			set {
				this.subvalueField = value;
			}
		}
	}
	
	/// <remarks/>
	[System.SerializableAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class SpriteStudioEffectEffectDataNodeBehaviorValueRotation
	{
		
		private decimal valueField;
		private decimal subvalueField;
		
		/// <remarks/>
		[System.Xml.Serialization.XmlAttributeAttribute()]
		public decimal value {
			get {
				return this.valueField;
			}
			set {
				this.valueField = value;
			}
		}
		
		/// <remarks/>
		[System.Xml.Serialization.XmlAttributeAttribute()]
		public decimal subvalue {
			get {
				return this.subvalueField;
			}
			set {
				this.subvalueField = value;
			}
		}
	}
	
	/// <remarks/>
	[System.SerializableAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class SpriteStudioEffectEffectDataNodeBehaviorValueRotationAdd
	{
		
		private byte valueField;
		private decimal subvalueField;
		
		/// <remarks/>
		[System.Xml.Serialization.XmlAttributeAttribute()]
		public byte value {
			get {
				return this.valueField;
			}
			set {
				this.valueField = value;
			}
		}
		
		/// <remarks/>
		[System.Xml.Serialization.XmlAttributeAttribute()]
		public decimal subvalue {
			get {
				return this.subvalueField;
			}
			set {
				this.subvalueField = value;
			}
		}
	}
	
	/// <remarks/>
	[System.SerializableAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class SpriteStudioEffectEffectDataNodeBehaviorValueSpeed
	{
		
		private decimal valueField;
		private decimal subvalueField;
		
		/// <remarks/>
		[System.Xml.Serialization.XmlAttributeAttribute()]
		public decimal value {
			get {
				return this.valueField;
			}
			set {
				this.valueField = value;
			}
		}
		
		/// <remarks/>
		[System.Xml.Serialization.XmlAttributeAttribute()]
		public decimal subvalue {
			get {
				return this.subvalueField;
			}
			set {
				this.subvalueField = value;
			}
		}
	}
	
	/// <remarks/>
	[System.SerializableAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class SpriteStudioEffectEffectDataNodeBehaviorValueLifespan
	{
		
		private byte valueField;
		private byte subvalueField;
		
		/// <remarks/>
		[System.Xml.Serialization.XmlAttributeAttribute()]
		public byte value {
			get {
				return this.valueField;
			}
			set {
				this.valueField = value;
			}
		}
		
		/// <remarks/>
		[System.Xml.Serialization.XmlAttributeAttribute()]
		public byte subvalue {
			get {
				return this.subvalueField;
			}
			set {
				this.subvalueField = value;
			}
		}
	}
	
	
}
