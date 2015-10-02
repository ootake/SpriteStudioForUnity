namespace SpriteStudioForUnity
{
	/// <remarks/>
	[System.SerializableAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	[System.Xml.Serialization.XmlRootAttribute(Namespace = "", IsNullable = false)]
	public partial class SpriteStudioCellMap
	{
	
		private string nameField;
		private object exportPathField;
		private string generatorField;
		private byte packedField;
		private string imagePathField;
		private string pixelSizeField;
		private byte overrideTexSettingsField;
		private string wrapModeField;
		private string filterModeField;
		private string imagePathAtImportField;
		private object packInfoFilePathField;
		private SpriteStudioCellMapTexPackSettings texPackSettingsField;
		private SpriteStudioCellMapCell[] cellsField;
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
		public string generator {
			get {
				return this.generatorField;
			}
			set {
				this.generatorField = value;
			}
		}
	
		/// <remarks/>
		public byte packed {
			get {
				return this.packedField;
			}
			set {
				this.packedField = value;
			}
		}
	
		/// <remarks/>
		public string imagePath {
			get {
				return this.imagePathField;
			}
			set {
				this.imagePathField = value;
			}
		}
	
		/// <remarks/>
		public string pixelSize {
			get {
				return this.pixelSizeField;
			}
			set {
				this.pixelSizeField = value;
			}
		}
	
		/// <remarks/>
		public byte overrideTexSettings {
			get {
				return this.overrideTexSettingsField;
			}
			set {
				this.overrideTexSettingsField = value;
			}
		}
	
		/// <remarks/>
		public string wrapMode {
			get {
				return this.wrapModeField;
			}
			set {
				this.wrapModeField = value;
			}
		}
	
		/// <remarks/>
		public string filterMode {
			get {
				return this.filterModeField;
			}
			set {
				this.filterModeField = value;
			}
		}
	
		/// <remarks/>
		public string imagePathAtImport {
			get {
				return this.imagePathAtImportField;
			}
			set {
				this.imagePathAtImportField = value;
			}
		}
	
		/// <remarks/>
		public object packInfoFilePath {
			get {
				return this.packInfoFilePathField;
			}
			set {
				this.packInfoFilePathField = value;
			}
		}
	
		/// <remarks/>
		public SpriteStudioCellMapTexPackSettings texPackSettings {
			get {
				return this.texPackSettingsField;
			}
			set {
				this.texPackSettingsField = value;
			}
		}
	
		/// <remarks/>
		[System.Xml.Serialization.XmlArrayItemAttribute("cell", IsNullable = false)]
		public SpriteStudioCellMapCell[] cells {
			get {
				return this.cellsField;
			}
			set {
				this.cellsField = value;
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
	public partial class SpriteStudioCellMapTexPackSettings
	{
	
		private string maxSizeField;
		private byte forcePo2Field;
		private byte forceSquareField;
		private byte marginField;
		private byte paddingField;
	
		/// <remarks/>
		public string maxSize {
			get {
				return this.maxSizeField;
			}
			set {
				this.maxSizeField = value;
			}
		}
	
		/// <remarks/>
		public byte forcePo2 {
			get {
				return this.forcePo2Field;
			}
			set {
				this.forcePo2Field = value;
			}
		}
	
		/// <remarks/>
		public byte forceSquare {
			get {
				return this.forceSquareField;
			}
			set {
				this.forceSquareField = value;
			}
		}
	
		/// <remarks/>
		public byte margin {
			get {
				return this.marginField;
			}
			set {
				this.marginField = value;
			}
		}
	
		/// <remarks/>
		public byte padding {
			get {
				return this.paddingField;
			}
			set {
				this.paddingField = value;
			}
		}
	}

/// <remarks/>
	[System.SerializableAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class SpriteStudioCellMapCell
	{
	
		private string nameField;
		private string posField;
		private string sizeField;
		private string pivotField;
		private byte rotatedField;
		private string orgImageNameField;
		private byte posStableField;
	
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
		public string pos {
			get {
				return this.posField;
			}
			set {
				this.posField = value;
			}
		}
	
		/// <remarks/>
		public string size {
			get {
				return this.sizeField;
			}
			set {
				this.sizeField = value;
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
		public byte rotated {
			get {
				return this.rotatedField;
			}
			set {
				this.rotatedField = value;
			}
		}
	
		/// <remarks/>
		public string orgImageName {
			get {
				return this.orgImageNameField;
			}
			set {
				this.orgImageNameField = value;
			}
		}
	
		/// <remarks/>
		public byte posStable {
			get {
				return this.posStableField;
			}
			set {
				this.posStableField = value;
			}
		}
	}
}
