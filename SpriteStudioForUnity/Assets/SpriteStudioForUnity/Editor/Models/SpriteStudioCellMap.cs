namespace SpriteStudioForUnity
{
    public partial class SpriteStudioCellMap
    {
        public string name;
        public object exportPath;
        public string generator;
        public byte packed;
        public string imagePath;
        public string pixelSize;
        public byte overrideTexSettings;
        public string wrapMode;
        public string filterMode;
        public string imagePathAtImport;
        public object packInfoFilePath;
        public SpriteStudioCellMapTexPackSettings texPackSettings;
        [System.Xml.Serialization.XmlArrayItemAttribute("cell", IsNullable = false)]
        public SpriteStudioCellMapCell[] cells;
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string version;
    }

    public partial class SpriteStudioCellMapTexPackSettings
    {
        public string maxSize;
        public byte forcePo2;
        public byte forceSquare;
        public byte margin;
        public byte padding;
    }

    public partial class SpriteStudioCellMapCell
    {
        public string name;
        public string pos;
        public string size;
        public string pivot;
        public byte rotated;
        public string orgImageName;
        public byte posStable;
    }
}
