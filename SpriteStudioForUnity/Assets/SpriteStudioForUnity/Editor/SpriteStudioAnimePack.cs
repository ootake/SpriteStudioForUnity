namespace SpriteStudioForUnity
{
	
	/// <remarks/>
	[System.SerializableAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	[System.Xml.Serialization.XmlRootAttribute(Namespace = "", IsNullable = false)]
	public partial class SpriteStudioAnimePack
	{
		
		private SpriteStudioAnimePackSettings settingsField;
		private string nameField;
		private object exportPathField;
		private SpriteStudioAnimePackModel modelField;
		private string[] cellmapNamesField;
		private SpriteStudioAnimePackAnime[] animeListField;
		private string versionField;
		
		/// <remarks/>
		public SpriteStudioAnimePackSettings settings {
			get {
				return this.settingsField;
			}
			set {
				this.settingsField = value;
			}
		}
		
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
		public SpriteStudioAnimePackModel Model {
			get {
				return this.modelField;
			}
			set {
				this.modelField = value;
			}
		}
		
		/// <remarks/>
		[System.Xml.Serialization.XmlArrayItemAttribute("value", IsNullable = false)]
		public string[] cellmapNames {
			get {
				return this.cellmapNamesField;
			}
			set {
				this.cellmapNamesField = value;
			}
		}
		
		/// <remarks/>
		[System.Xml.Serialization.XmlArrayItemAttribute("anime", IsNullable = false)]
		public SpriteStudioAnimePackAnime[] animeList {
			get {
				return this.animeListField;
			}
			set {
				this.animeListField = value;
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
	public partial class SpriteStudioAnimePackSettings
	{
		
		private byte fpsField;
		private byte frameCountField;
		private string sortModeField;
		private string canvasSizeField;
		private string pivotField;
		private string bgColorField;
		private byte gridSizeField;
		private string gridColorField;
		private byte outStartNumField;
		
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
		public byte frameCount {
			get {
				return this.frameCountField;
			}
			set {
				this.frameCountField = value;
			}
		}
		
		/// <remarks/>
		public string sortMode {
			get {
				return this.sortModeField;
			}
			set {
				this.sortModeField = value;
			}
		}
		
		/// <remarks/>
		public string canvasSize {
			get {
				return this.canvasSizeField;
			}
			set {
				this.canvasSizeField = value;
			}
		}
		
		/// <remarks/>
		public string pivot {
			get {
				return this.pivotField;
			}
			set {
				this.pivotField = value;
			}
		}
		
		/// <remarks/>
		public string bgColor {
			get {
				return this.bgColorField;
			}
			set {
				this.bgColorField = value;
			}
		}
		
		/// <remarks/>
		public byte gridSize {
			get {
				return this.gridSizeField;
			}
			set {
				this.gridSizeField = value;
			}
		}
		
		/// <remarks/>
		public string gridColor {
			get {
				return this.gridColorField;
			}
			set {
				this.gridColorField = value;
			}
		}
		
		/// <remarks/>
		public byte outStartNum {
			get {
				return this.outStartNumField;
			}
			set {
				this.outStartNumField = value;
			}
		}
	}
	
	/// <remarks/>
	[System.SerializableAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class SpriteStudioAnimePackModel
	{
		
		private SpriteStudioAnimePackModelValue[] partListField;
		
		/// <remarks/>
		[System.Xml.Serialization.XmlArrayItemAttribute("value", IsNullable = false)]
		public SpriteStudioAnimePackModelValue[] partList {
			get {
				return this.partListField;
			}
			set {
				this.partListField = value;
			}
		}
	}
	
	/// <remarks/>
	[System.SerializableAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class SpriteStudioAnimePackModelValue
	{
		
		private string nameField;
		private byte arrayIndexField;
		private sbyte parentIndexField;
		private string typeField;
		private string boundsTypeField;
		private string inheritTypeField;
		private SpriteStudioAnimePackModelValueIneheritRates ineheritRatesField;
		private string refEffectNameField;
		private string alphaBlendTypeField;
		private byte showField;
		private byte lockedField;
		private byte expandAttributeField;
		private byte expandChildrenField;
		
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
		public string type {
			get {
				return this.typeField;
			}
			set {
				this.typeField = value;
			}
		}
		
		/// <remarks/>
		public string boundsType {
			get {
				return this.boundsTypeField;
			}
			set {
				this.boundsTypeField = value;
			}
		}
		
		/// <remarks/>
		public string inheritType {
			get {
				return this.inheritTypeField;
			}
			set {
				this.inheritTypeField = value;
			}
		}
		
		/// <remarks/>
		public SpriteStudioAnimePackModelValueIneheritRates ineheritRates {
			get {
				return this.ineheritRatesField;
			}
			set {
				this.ineheritRatesField = value;
			}
		}
		
		/// <remarks/>
		public string refEffectName {
			get {
				return this.refEffectNameField;
			}
			set {
				this.refEffectNameField = value;
			}
		}
		
		/// <remarks/>
		public string alphaBlendType {
			get {
				return this.alphaBlendTypeField;
			}
			set {
				this.alphaBlendTypeField = value;
			}
		}
		
		/// <remarks/>
		public byte show {
			get {
				return this.showField;
			}
			set {
				this.showField = value;
			}
		}
		
		/// <remarks/>
		public byte locked {
			get {
				return this.lockedField;
			}
			set {
				this.lockedField = value;
			}
		}
		
		/// <remarks/>
		public byte expandAttribute {
			get {
				return this.expandAttributeField;
			}
			set {
				this.expandAttributeField = value;
			}
		}
		
		/// <remarks/>
		public byte expandChildren {
			get {
				return this.expandChildrenField;
			}
			set {
				this.expandChildrenField = value;
			}
		}
	}
	
	/// <remarks/>
	[System.SerializableAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class SpriteStudioAnimePackModelValueIneheritRates
	{
		
		private byte aLPHField;
		private byte fLPHField;
		private byte fLPVField;
		private byte hIDEField;
		private byte iFLHField;
		private byte iFLVField;
		
		/// <remarks/>
		public byte ALPH {
			get {
				return this.aLPHField;
			}
			set {
				this.aLPHField = value;
			}
		}
		
		/// <remarks/>
		public byte FLPH {
			get {
				return this.fLPHField;
			}
			set {
				this.fLPHField = value;
			}
		}
		
		/// <remarks/>
		public byte FLPV {
			get {
				return this.fLPVField;
			}
			set {
				this.fLPVField = value;
			}
		}
		
		/// <remarks/>
		public byte HIDE {
			get {
				return this.hIDEField;
			}
			set {
				this.hIDEField = value;
			}
		}
		
		/// <remarks/>
		public byte IFLH {
			get {
				return this.iFLHField;
			}
			set {
				this.iFLHField = value;
			}
		}
		
		/// <remarks/>
		public byte IFLV {
			get {
				return this.iFLVField;
			}
			set {
				this.iFLVField = value;
			}
		}
	}
	
	/// <remarks/>
	[System.SerializableAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class SpriteStudioAnimePackAnime
	{
		
		private string nameField;
		private byte overrideSettingsField;
		private SpriteStudioAnimePackAnimeSettings settingsField;
		private object labelsField;
		private SpriteStudioAnimePackAnimePartAnime[] partAnimesField;
		
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
		public byte overrideSettings {
			get {
				return this.overrideSettingsField;
			}
			set {
				this.overrideSettingsField = value;
			}
		}
		
		/// <remarks/>
		public SpriteStudioAnimePackAnimeSettings settings {
			get {
				return this.settingsField;
			}
			set {
				this.settingsField = value;
			}
		}
		
		/// <remarks/>
		public object labels {
			get {
				return this.labelsField;
			}
			set {
				this.labelsField = value;
			}
		}
		
		/// <remarks/>
		[System.Xml.Serialization.XmlArrayItemAttribute("partAnime", IsNullable = false)]
		public SpriteStudioAnimePackAnimePartAnime[] partAnimes {
			get {
				return this.partAnimesField;
			}
			set {
				this.partAnimesField = value;
			}
		}
	}
	
	/// <remarks/>
	[System.SerializableAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class SpriteStudioAnimePackAnimeSettings
	{
		
		private byte fpsField;
		private byte frameCountField;
		private string sortModeField;
		private string canvasSizeField;
		private string pivotField;
		private string bgColorField;
		private byte gridSizeField;
		private string gridColorField;
		private byte outStartNumField;
		
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
		public byte frameCount {
			get {
				return this.frameCountField;
			}
			set {
				this.frameCountField = value;
			}
		}
		
		/// <remarks/>
		public string sortMode {
			get {
				return this.sortModeField;
			}
			set {
				this.sortModeField = value;
			}
		}
		
		/// <remarks/>
		public string canvasSize {
			get {
				return this.canvasSizeField;
			}
			set {
				this.canvasSizeField = value;
			}
		}
		
		/// <remarks/>
		public string pivot {
			get {
				return this.pivotField;
			}
			set {
				this.pivotField = value;
			}
		}
		
		/// <remarks/>
		public string bgColor {
			get {
				return this.bgColorField;
			}
			set {
				this.bgColorField = value;
			}
		}
		
		/// <remarks/>
		public byte gridSize {
			get {
				return this.gridSizeField;
			}
			set {
				this.gridSizeField = value;
			}
		}
		
		/// <remarks/>
		public string gridColor {
			get {
				return this.gridColorField;
			}
			set {
				this.gridColorField = value;
			}
		}
		
		/// <remarks/>
		public byte outStartNum {
			get {
				return this.outStartNumField;
			}
			set {
				this.outStartNumField = value;
			}
		}
	}
	
	/// <remarks/>
	[System.SerializableAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class SpriteStudioAnimePackAnimePartAnime
	{
		
		private string partNameField;
		private SpriteStudioAnimePackAnimePartAnimeAttribute[] attributesField;
		
		/// <remarks/>
		public string partName {
			get {
				return this.partNameField;
			}
			set {
				this.partNameField = value;
			}
		}
		
		/// <remarks/>
		[System.Xml.Serialization.XmlArrayItemAttribute("attribute", IsNullable = false)]
		public SpriteStudioAnimePackAnimePartAnimeAttribute[] attributes {
			get {
				return this.attributesField;
			}
			set {
				this.attributesField = value;
			}
		}
	}
	
	/// <remarks/>
	[System.SerializableAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class SpriteStudioAnimePackAnimePartAnimeAttribute
	{
		
		private SpriteStudioAnimePackAnimePartAnimeAttributeKey[] keyField;
		private string tagField;
		
		/// <remarks/>
		[System.Xml.Serialization.XmlElementAttribute("key")]
		public SpriteStudioAnimePackAnimePartAnimeAttributeKey[] key {
			get {
				return this.keyField;
			}
			set {
				this.keyField = value;
			}
		}
		
		/// <remarks/>
		[System.Xml.Serialization.XmlAttributeAttribute()]
		public string tag {
			get {
				return this.tagField;
			}
			set {
				this.tagField = value;
			}
		}
	}
	
	/// <remarks/>
	[System.SerializableAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class SpriteStudioAnimePackAnimePartAnimeAttributeKey
	{
		
		private SpriteStudioAnimePackAnimePartAnimeAttributeKeyCurve curveField;
		private SpriteStudioAnimePackAnimePartAnimeAttributeKeyValue valueField;
		private sbyte timeField;
		private string ipTypeField;
		
		/// <remarks/>
		public SpriteStudioAnimePackAnimePartAnimeAttributeKeyCurve curve {
			get {
				return this.curveField;
			}
			set {
				this.curveField = value;
			}
		}
		
		/// <remarks/>
		public SpriteStudioAnimePackAnimePartAnimeAttributeKeyValue value {
			get {
				return this.valueField;
			}
			set {
				this.valueField = value;
			}
		}
		
		/// <remarks/>
		[System.Xml.Serialization.XmlAttributeAttribute()]
		public sbyte time {
			get {
				return this.timeField;
			}
			set {
				this.timeField = value;
			}
		}
		
		/// <remarks/>
		[System.Xml.Serialization.XmlAttributeAttribute()]
		public string ipType {
			get {
				return this.ipTypeField;
			}
			set {
				this.ipTypeField = value;
			}
		}
	}
	
	/// <remarks/>
	[System.SerializableAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class SpriteStudioAnimePackAnimePartAnimeAttributeKeyCurve
	{
		
		private byte syncStartEndField;
		private string valueField;
		
		/// <remarks/>
		[System.Xml.Serialization.XmlAttributeAttribute()]
		public byte syncStartEnd {
			get {
				return this.syncStartEndField;
			}
			set {
				this.syncStartEndField = value;
			}
		}
		
		/// <remarks/>
		[System.Xml.Serialization.XmlTextAttribute()]
		public string Value {
			get {
				return this.valueField;
			}
			set {
				this.valueField = value;
			}
		}
	}
	
	/// <remarks/>
	[System.SerializableAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class SpriteStudioAnimePackAnimePartAnimeAttributeKeyValue
	{
		
		private byte integerField;
		private bool integerFieldSpecified;
		private string pointField;
		private string rectField;
		private string stringField;
		private string targetField;
		private string blendTypeField;
		private SpriteStudioAnimePackAnimePartAnimeAttributeKeyValueColor colorField;
		private SpriteStudioAnimePackAnimePartAnimeAttributeKeyValueLT ltField;
		private SpriteStudioAnimePackAnimePartAnimeAttributeKeyValueRT rtField;
		private SpriteStudioAnimePackAnimePartAnimeAttributeKeyValueLB lbField;
		private SpriteStudioAnimePackAnimePartAnimeAttributeKeyValueRB rbField;
		private byte mapIdField;
		private bool mapIdFieldSpecified;
		private string nameField;
		private string[] textField;
		
		/// <remarks/>
		public byte integer {
			get {
				return this.integerField;
			}
			set {
				this.integerField = value;
			}
		}
		
		/// <remarks/>
		[System.Xml.Serialization.XmlIgnoreAttribute()]
		public bool integerSpecified {
			get {
				return this.integerFieldSpecified;
			}
			set {
				this.integerFieldSpecified = value;
			}
		}
		
		/// <remarks/>
		public string point {
			get {
				return this.pointField;
			}
			set {
				this.pointField = value;
			}
		}
		
		/// <remarks/>
		public string rect {
			get {
				return this.rectField;
			}
			set {
				this.rectField = value;
			}
		}
		
		/// <remarks/>
		public string @string {
			get {
				return this.stringField;
			}
			set {
				this.stringField = value;
			}
		}
		
		/// <remarks/>
		public string target {
			get {
				return this.targetField;
			}
			set {
				this.targetField = value;
			}
		}
		
		/// <remarks/>
		public string blendType {
			get {
				return this.blendTypeField;
			}
			set {
				this.blendTypeField = value;
			}
		}
		
		/// <remarks/>
		public SpriteStudioAnimePackAnimePartAnimeAttributeKeyValueColor color {
			get {
				return this.colorField;
			}
			set {
				this.colorField = value;
			}
		}
		
		/// <remarks/>
		public SpriteStudioAnimePackAnimePartAnimeAttributeKeyValueLT LT {
			get {
				return this.ltField;
			}
			set {
				this.ltField = value;
			}
		}
		
		/// <remarks/>
		public SpriteStudioAnimePackAnimePartAnimeAttributeKeyValueRT RT {
			get {
				return this.rtField;
			}
			set {
				this.rtField = value;
			}
		}
		
		/// <remarks/>
		public SpriteStudioAnimePackAnimePartAnimeAttributeKeyValueLB LB {
			get {
				return this.lbField;
			}
			set {
				this.lbField = value;
			}
		}
		
		/// <remarks/>
		public SpriteStudioAnimePackAnimePartAnimeAttributeKeyValueRB RB {
			get {
				return this.rbField;
			}
			set {
				this.rbField = value;
			}
		}
		
		/// <remarks/>
		public byte mapId {
			get {
				return this.mapIdField;
			}
			set {
				this.mapIdField = value;
			}
		}
		
		/// <remarks/>
		[System.Xml.Serialization.XmlIgnoreAttribute()]
		public bool mapIdSpecified {
			get {
				return this.mapIdFieldSpecified;
			}
			set {
				this.mapIdFieldSpecified = value;
			}
		}
		
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
		[System.Xml.Serialization.XmlTextAttribute()]
		public string[] Text {
			get {
				return this.textField;
			}
			set {
				this.textField = value;
			}
		}
	}
	
	/// <remarks/>
	[System.SerializableAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class SpriteStudioAnimePackAnimePartAnimeAttributeKeyValueColor
	{
		
		private string rgbaField;
		private byte rateField;
		
		/// <remarks/>
		public string rgba {
			get {
				return this.rgbaField;
			}
			set {
				this.rgbaField = value;
			}
		}
		
		/// <remarks/>
		public byte rate {
			get {
				return this.rateField;
			}
			set {
				this.rateField = value;
			}
		}
	}
	
	/// <remarks/>
	[System.SerializableAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class SpriteStudioAnimePackAnimePartAnimeAttributeKeyValueLT
	{
		
		private string rgbaField;
		private byte rateField;
		private string[] textField;
		
		/// <remarks/>
		public string rgba {
			get {
				return this.rgbaField;
			}
			set {
				this.rgbaField = value;
			}
		}
		
		/// <remarks/>
		public byte rate {
			get {
				return this.rateField;
			}
			set {
				this.rateField = value;
			}
		}
		
		/// <remarks/>
		[System.Xml.Serialization.XmlTextAttribute()]
		public string[] Text {
			get {
				return this.textField;
			}
			set {
				this.textField = value;
			}
		}
	}
	
	/// <remarks/>
	[System.SerializableAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class SpriteStudioAnimePackAnimePartAnimeAttributeKeyValueRT
	{
		
		private string rgbaField;
		private byte rateField;
		private string[] textField;
		
		/// <remarks/>
		public string rgba {
			get {
				return this.rgbaField;
			}
			set {
				this.rgbaField = value;
			}
		}
		
		/// <remarks/>
		public byte rate {
			get {
				return this.rateField;
			}
			set {
				this.rateField = value;
			}
		}
		
		/// <remarks/>
		[System.Xml.Serialization.XmlTextAttribute()]
		public string[] Text {
			get {
				return this.textField;
			}
			set {
				this.textField = value;
			}
		}
	}
	
	/// <remarks/>
	[System.SerializableAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class SpriteStudioAnimePackAnimePartAnimeAttributeKeyValueLB
	{
		
		private string rgbaField;
		private byte rateField;
		private string[] textField;
		
		/// <remarks/>
		public string rgba {
			get {
				return this.rgbaField;
			}
			set {
				this.rgbaField = value;
			}
		}
		
		/// <remarks/>
		public byte rate {
			get {
				return this.rateField;
			}
			set {
				this.rateField = value;
			}
		}
		
		/// <remarks/>
		[System.Xml.Serialization.XmlTextAttribute()]
		public string[] Text {
			get {
				return this.textField;
			}
			set {
				this.textField = value;
			}
		}
	}
	
	/// <remarks/>
	[System.SerializableAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class SpriteStudioAnimePackAnimePartAnimeAttributeKeyValueRB
	{
		
		private string rgbaField;
		private byte rateField;
		private string[] textField;
		
		/// <remarks/>
		public string rgba {
			get {
				return this.rgbaField;
			}
			set {
				this.rgbaField = value;
			}
		}
		
		/// <remarks/>
		public byte rate {
			get {
				return this.rateField;
			}
			set {
				this.rateField = value;
			}
		}
		
		/// <remarks/>
		[System.Xml.Serialization.XmlTextAttribute()]
		public string[] Text {
			get {
				return this.textField;
			}
			set {
				this.textField = value;
			}
		}
	}
	

}