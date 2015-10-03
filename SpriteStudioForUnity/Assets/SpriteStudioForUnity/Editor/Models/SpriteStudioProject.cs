namespace SpriteStudioForUnity
{
	public partial class SpriteStudioProject
	{
        public string name;
        public object exportPath;
        public SpriteStudioProjectSettings settings;
        public SpriteStudioProjectAnimeSettings animeSettings;
        public SpriteStudioProjectTexPackSettings texPackSettings;
		[System.Xml.Serialization.XmlArrayItemAttribute("value", IsNullable = false)]
        public string[] cellmapNames;
		[System.Xml.Serialization.XmlArrayItemAttribute("value", IsNullable = false)]
        public string[] animepackNames;
		[System.Xml.Serialization.XmlArrayItemAttribute("value", IsNullable = false)]
        public string[] effectFileNames;
        public string lastAnimeFile;
        public string lastAnimeName;
        public string lastCellMapFile;
        public string lastEffectFile;
        public string lastCell;
        public string lastPart;
		[System.Xml.Serialization.XmlAttributeAttribute()]
        public string version;
	}
	
	public partial class SpriteStudioProjectSettings
	{
        public object animeBaseDirectory;
        public object cellMapBaseDirectory;
        public object imageBaseDirectory;
        public object effectBaseDirectory;
        public string exportBaseDirectory;
        public byte queryExportBaseDirectory;
        public SpriteStudioProjectSettingsSsaxImport ssaxImport;
        public byte copyWhenImportImageIsOutside;
        public string exportAnimeFileFormat;
        public string exportCellMapFileFormat;
        public byte exportCellMap;
        public byte copyImageWhenExportCellmap;
        public SpriteStudioProjectSettingsSsaxExport ssaxExport;
        public string player;
        public byte strictVer4;
        public byte dontUseMatrixForTransform;
        public byte rootPartFunctionAsVer4;
        public byte interpolateColorBlendAsVer4;
        public byte interpolateVertexOffsetAsVer4;
        public byte restrictXYAsInteger;
        public byte inheritRatesNoKeySave;
		[System.Xml.Serialization.XmlArrayItemAttribute("item", IsNullable = false)]
        public string[] availableAttributes;
        public SpriteStudioProjectSettingsAvailableFeatures availableFeatures;
		[System.Xml.Serialization.XmlArrayItemAttribute("item", IsNullable = false)]
        public string[] defaultSetAttributes;
        public string wrapMode;
        public string filterMode;
        public string interpolationType;
        public SpriteStudioProjectSettingsRenderingSettings renderingSettings;
	}
	
	public partial class SpriteStudioProjectSettingsSsaxImport
	{
        public byte convertImageOffsetToCellAnime;
        public byte ignorePivotAsCellRegister;
        public byte keepAngleAsIsIfNegativeScale;
	}
	
	public partial class SpriteStudioProjectSettingsSsaxExport
	{
        public byte addAnimeNameEvenIfSingle;
        public byte listAllCellMaps;
        public byte connectAnimations;
        public byte zRotCurveParamAsRadian;
        public byte reverseZRotSignForNegativeScale;
        public byte numberOfPivotDecimals;
	}
	
	public partial class SpriteStudioProjectSettingsAvailableFeatures
	{
        public string value;
	}
	
	public partial class SpriteStudioProjectSettingsRenderingSettings
	{
        public string outputFolder;
        public string outputType;
        public string bgColor;
        public byte addAnimeName;
        public byte addTimeStamp;
        public byte addAlphaChanel;
	}
	
	public partial class SpriteStudioProjectAnimeSettings
	{
        public byte fps;
        public byte frameCount;
        public string sortMode;
        public string canvasSize;
        public string pivot;
        public string bgColor;
        public byte gridSize;
        public string gridColor;
        public byte outStartNum;
	}
	
	public partial class SpriteStudioProjectTexPackSettings
	{
        public string maxSize;
        public byte forcePo2;
        public byte forceSquare;
        public byte margin;
        public byte padding;
	}
	

}

