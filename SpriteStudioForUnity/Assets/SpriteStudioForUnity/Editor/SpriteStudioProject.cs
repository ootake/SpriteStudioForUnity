namespace SpriteStudioForUnity
{
	/// <remarks/>
	[System.SerializableAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	[System.Xml.Serialization.XmlRootAttribute(Namespace = "", IsNullable = false)]
	public partial class SpriteStudioProject
	{
		
		private string nameField;
		private object exportPathField;
		private SpriteStudioProjectSettings settingsField;
		private SpriteStudioProjectAnimeSettings animeSettingsField;
		private SpriteStudioProjectTexPackSettings texPackSettingsField;
		private string[] cellmapNamesField;
		private string[] animepackNamesField;
		private string[] effectFileNamesField;
		private string lastAnimeFileField;
		private string lastAnimeNameField;
		private string lastCellMapFileField;
		private string lastEffectFileField;
		private string lastCellField;
		private string lastPartField;
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
		public SpriteStudioProjectSettings settings {
			get {
				return this.settingsField;
			}
			set {
				this.settingsField = value;
			}
		}
		
		/// <remarks/>
		public SpriteStudioProjectAnimeSettings animeSettings {
			get {
				return this.animeSettingsField;
			}
			set {
				this.animeSettingsField = value;
			}
		}
		
		/// <remarks/>
		public SpriteStudioProjectTexPackSettings texPackSettings {
			get {
				return this.texPackSettingsField;
			}
			set {
				this.texPackSettingsField = value;
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
		[System.Xml.Serialization.XmlArrayItemAttribute("value", IsNullable = false)]
		public string[] animepackNames {
			get {
				return this.animepackNamesField;
			}
			set {
				this.animepackNamesField = value;
			}
		}
		
		/// <remarks/>
		[System.Xml.Serialization.XmlArrayItemAttribute("value", IsNullable = false)]
		public string[] effectFileNames {
			get {
				return this.effectFileNamesField;
			}
			set {
				this.effectFileNamesField = value;
			}
		}
		
		/// <remarks/>
		public string lastAnimeFile {
			get {
				return this.lastAnimeFileField;
			}
			set {
				this.lastAnimeFileField = value;
			}
		}
		
		/// <remarks/>
		public string lastAnimeName {
			get {
				return this.lastAnimeNameField;
			}
			set {
				this.lastAnimeNameField = value;
			}
		}
		
		/// <remarks/>
		public string lastCellMapFile {
			get {
				return this.lastCellMapFileField;
			}
			set {
				this.lastCellMapFileField = value;
			}
		}
		
		/// <remarks/>
		public string lastEffectFile {
			get {
				return this.lastEffectFileField;
			}
			set {
				this.lastEffectFileField = value;
			}
		}
		
		/// <remarks/>
		public string lastCell {
			get {
				return this.lastCellField;
			}
			set {
				this.lastCellField = value;
			}
		}
		
		/// <remarks/>
		public string lastPart {
			get {
				return this.lastPartField;
			}
			set {
				this.lastPartField = value;
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
	public partial class SpriteStudioProjectSettings
	{
		
		private object animeBaseDirectoryField;
		private object cellMapBaseDirectoryField;
		private object imageBaseDirectoryField;
		private object effectBaseDirectoryField;
		private string exportBaseDirectoryField;
		private byte queryExportBaseDirectoryField;
		private SpriteStudioProjectSettingsSsaxImport ssaxImportField;
		private byte copyWhenImportImageIsOutsideField;
		private string exportAnimeFileFormatField;
		private string exportCellMapFileFormatField;
		private byte exportCellMapField;
		private byte copyImageWhenExportCellmapField;
		private SpriteStudioProjectSettingsSsaxExport ssaxExportField;
		private string playerField;
		private byte strictVer4Field;
		private byte dontUseMatrixForTransformField;
		private byte rootPartFunctionAsVer4Field;
		private byte interpolateColorBlendAsVer4Field;
		private byte interpolateVertexOffsetAsVer4Field;
		private byte restrictXYAsIntegerField;
		private byte inheritRatesNoKeySaveField;
		private string[] availableAttributesField;
		private SpriteStudioProjectSettingsAvailableFeatures availableFeaturesField;
		private string[] defaultSetAttributesField;
		private string wrapModeField;
		private string filterModeField;
		private string interpolationTypeField;
		private SpriteStudioProjectSettingsRenderingSettings renderingSettingsField;
		
		/// <remarks/>
		public object animeBaseDirectory {
			get {
				return this.animeBaseDirectoryField;
			}
			set {
				this.animeBaseDirectoryField = value;
			}
		}
		
		/// <remarks/>
		public object cellMapBaseDirectory {
			get {
				return this.cellMapBaseDirectoryField;
			}
			set {
				this.cellMapBaseDirectoryField = value;
			}
		}
		
		/// <remarks/>
		public object imageBaseDirectory {
			get {
				return this.imageBaseDirectoryField;
			}
			set {
				this.imageBaseDirectoryField = value;
			}
		}
		
		/// <remarks/>
		public object effectBaseDirectory {
			get {
				return this.effectBaseDirectoryField;
			}
			set {
				this.effectBaseDirectoryField = value;
			}
		}
		
		/// <remarks/>
		public string exportBaseDirectory {
			get {
				return this.exportBaseDirectoryField;
			}
			set {
				this.exportBaseDirectoryField = value;
			}
		}
		
		/// <remarks/>
		public byte queryExportBaseDirectory {
			get {
				return this.queryExportBaseDirectoryField;
			}
			set {
				this.queryExportBaseDirectoryField = value;
			}
		}
		
		/// <remarks/>
		public SpriteStudioProjectSettingsSsaxImport ssaxImport {
			get {
				return this.ssaxImportField;
			}
			set {
				this.ssaxImportField = value;
			}
		}
		
		/// <remarks/>
		public byte copyWhenImportImageIsOutside {
			get {
				return this.copyWhenImportImageIsOutsideField;
			}
			set {
				this.copyWhenImportImageIsOutsideField = value;
			}
		}
		
		/// <remarks/>
		public string exportAnimeFileFormat {
			get {
				return this.exportAnimeFileFormatField;
			}
			set {
				this.exportAnimeFileFormatField = value;
			}
		}
		
		/// <remarks/>
		public string exportCellMapFileFormat {
			get {
				return this.exportCellMapFileFormatField;
			}
			set {
				this.exportCellMapFileFormatField = value;
			}
		}
		
		/// <remarks/>
		public byte exportCellMap {
			get {
				return this.exportCellMapField;
			}
			set {
				this.exportCellMapField = value;
			}
		}
		
		/// <remarks/>
		public byte copyImageWhenExportCellmap {
			get {
				return this.copyImageWhenExportCellmapField;
			}
			set {
				this.copyImageWhenExportCellmapField = value;
			}
		}
		
		/// <remarks/>
		public SpriteStudioProjectSettingsSsaxExport ssaxExport {
			get {
				return this.ssaxExportField;
			}
			set {
				this.ssaxExportField = value;
			}
		}
		
		/// <remarks/>
		public string player {
			get {
				return this.playerField;
			}
			set {
				this.playerField = value;
			}
		}
		
		/// <remarks/>
		public byte strictVer4 {
			get {
				return this.strictVer4Field;
			}
			set {
				this.strictVer4Field = value;
			}
		}
		
		/// <remarks/>
		public byte dontUseMatrixForTransform {
			get {
				return this.dontUseMatrixForTransformField;
			}
			set {
				this.dontUseMatrixForTransformField = value;
			}
		}
		
		/// <remarks/>
		public byte rootPartFunctionAsVer4 {
			get {
				return this.rootPartFunctionAsVer4Field;
			}
			set {
				this.rootPartFunctionAsVer4Field = value;
			}
		}
		
		/// <remarks/>
		public byte interpolateColorBlendAsVer4 {
			get {
				return this.interpolateColorBlendAsVer4Field;
			}
			set {
				this.interpolateColorBlendAsVer4Field = value;
			}
		}
		
		/// <remarks/>
		public byte interpolateVertexOffsetAsVer4 {
			get {
				return this.interpolateVertexOffsetAsVer4Field;
			}
			set {
				this.interpolateVertexOffsetAsVer4Field = value;
			}
		}
		
		/// <remarks/>
		public byte restrictXYAsInteger {
			get {
				return this.restrictXYAsIntegerField;
			}
			set {
				this.restrictXYAsIntegerField = value;
			}
		}
		
		/// <remarks/>
		public byte inheritRatesNoKeySave {
			get {
				return this.inheritRatesNoKeySaveField;
			}
			set {
				this.inheritRatesNoKeySaveField = value;
			}
		}
		
		/// <remarks/>
		[System.Xml.Serialization.XmlArrayItemAttribute("item", IsNullable = false)]
		public string[] availableAttributes {
			get {
				return this.availableAttributesField;
			}
			set {
				this.availableAttributesField = value;
			}
		}
		
		/// <remarks/>
		public SpriteStudioProjectSettingsAvailableFeatures availableFeatures {
			get {
				return this.availableFeaturesField;
			}
			set {
				this.availableFeaturesField = value;
			}
		}
		
		/// <remarks/>
		[System.Xml.Serialization.XmlArrayItemAttribute("item", IsNullable = false)]
		public string[] defaultSetAttributes {
			get {
				return this.defaultSetAttributesField;
			}
			set {
				this.defaultSetAttributesField = value;
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
		public string interpolationType {
			get {
				return this.interpolationTypeField;
			}
			set {
				this.interpolationTypeField = value;
			}
		}
		
		/// <remarks/>
		public SpriteStudioProjectSettingsRenderingSettings renderingSettings {
			get {
				return this.renderingSettingsField;
			}
			set {
				this.renderingSettingsField = value;
			}
		}
	}
	
	/// <remarks/>
	[System.SerializableAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class SpriteStudioProjectSettingsSsaxImport
	{
		
		private byte convertImageOffsetToCellAnimeField;
		private byte ignorePivotAsCellRegisterField;
		private byte keepAngleAsIsIfNegativeScaleField;
		
		/// <remarks/>
		public byte convertImageOffsetToCellAnime {
			get {
				return this.convertImageOffsetToCellAnimeField;
			}
			set {
				this.convertImageOffsetToCellAnimeField = value;
			}
		}
		
		/// <remarks/>
		public byte ignorePivotAsCellRegister {
			get {
				return this.ignorePivotAsCellRegisterField;
			}
			set {
				this.ignorePivotAsCellRegisterField = value;
			}
		}
		
		/// <remarks/>
		public byte keepAngleAsIsIfNegativeScale {
			get {
				return this.keepAngleAsIsIfNegativeScaleField;
			}
			set {
				this.keepAngleAsIsIfNegativeScaleField = value;
			}
		}
	}
	
	/// <remarks/>
	[System.SerializableAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class SpriteStudioProjectSettingsSsaxExport
	{
		
		private byte addAnimeNameEvenIfSingleField;
		private byte listAllCellMapsField;
		private byte connectAnimationsField;
		private byte zRotCurveParamAsRadianField;
		private byte reverseZRotSignForNegativeScaleField;
		private byte numberOfPivotDecimalsField;
		
		/// <remarks/>
		public byte addAnimeNameEvenIfSingle {
			get {
				return this.addAnimeNameEvenIfSingleField;
			}
			set {
				this.addAnimeNameEvenIfSingleField = value;
			}
		}
		
		/// <remarks/>
		public byte listAllCellMaps {
			get {
				return this.listAllCellMapsField;
			}
			set {
				this.listAllCellMapsField = value;
			}
		}
		
		/// <remarks/>
		public byte connectAnimations {
			get {
				return this.connectAnimationsField;
			}
			set {
				this.connectAnimationsField = value;
			}
		}
		
		/// <remarks/>
		public byte zRotCurveParamAsRadian {
			get {
				return this.zRotCurveParamAsRadianField;
			}
			set {
				this.zRotCurveParamAsRadianField = value;
			}
		}
		
		/// <remarks/>
		public byte reverseZRotSignForNegativeScale {
			get {
				return this.reverseZRotSignForNegativeScaleField;
			}
			set {
				this.reverseZRotSignForNegativeScaleField = value;
			}
		}
		
		/// <remarks/>
		public byte numberOfPivotDecimals {
			get {
				return this.numberOfPivotDecimalsField;
			}
			set {
				this.numberOfPivotDecimalsField = value;
			}
		}
	}
	
	/// <remarks/>
	[System.SerializableAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class SpriteStudioProjectSettingsAvailableFeatures
	{
		
		private string valueField;
		
		/// <remarks/>
		public string value {
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
	public partial class SpriteStudioProjectSettingsRenderingSettings
	{
		
		private string outputFolderField;
		private string outputTypeField;
		private string bgColorField;
		private byte addAnimeNameField;
		private byte addTimeStampField;
		private byte addAlphaChanelField;
		
		/// <remarks/>
		public string outputFolder {
			get {
				return this.outputFolderField;
			}
			set {
				this.outputFolderField = value;
			}
		}
		
		/// <remarks/>
		public string outputType {
			get {
				return this.outputTypeField;
			}
			set {
				this.outputTypeField = value;
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
		public byte addAnimeName {
			get {
				return this.addAnimeNameField;
			}
			set {
				this.addAnimeNameField = value;
			}
		}
		
		/// <remarks/>
		public byte addTimeStamp {
			get {
				return this.addTimeStampField;
			}
			set {
				this.addTimeStampField = value;
			}
		}
		
		/// <remarks/>
		public byte addAlphaChanel {
			get {
				return this.addAlphaChanelField;
			}
			set {
				this.addAlphaChanelField = value;
			}
		}
	}
	
	/// <remarks/>
	[System.SerializableAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public partial class SpriteStudioProjectAnimeSettings
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
	public partial class SpriteStudioProjectTexPackSettings
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
	

}

