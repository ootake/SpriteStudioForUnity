namespace SpriteStudioForUnity
{   
    public partial class SpriteStudioAnimePack
    {
        public SpriteStudioAnimePackSettings settings;
        public string name;
        public SpriteStudioAnimePackModel Model;
        [System.Xml.Serialization.XmlArrayItemAttribute("value", IsNullable = false)]
        public string[] cellmapNames;
        [System.Xml.Serialization.XmlArrayItemAttribute("anime", IsNullable = false)]
        public SpriteStudioAnimePackAnime[] animeList;
    }
    
    public partial class SpriteStudioAnimePackSettings
    {
        public byte fps;
        public byte frameCount;
        public string sortMode;
    }
    
    public partial class SpriteStudioAnimePackModel
    {        
        [System.Xml.Serialization.XmlArrayItemAttribute("value", IsNullable = false)]
        public SpriteStudioAnimePackModelValue[] partList;
    }
    
    public partial class SpriteStudioAnimePackModelValue
    {
        public string name;
        public byte arrayIndex;
        public sbyte parentIndex;
        public string type;
        public string boundsType;
        public string inheritType;
        public SpriteStudioAnimePackModelValueIneheritRates ineheritRates;
        public string refEffectName;
        public string alphaBlendType;
        public byte show;
    }
    
    public partial class SpriteStudioAnimePackModelValueIneheritRates
    {        
        public byte ALPH;
        public byte FLPH;
        public byte FLPV;
        public byte HIDE;
        public byte IFLH;
        public byte IFLV;
    }
    
    public partial class SpriteStudioAnimePackAnime
    {
        public string name;
        public SpriteStudioAnimePackAnimeSettings settings;
        [System.Xml.Serialization.XmlArrayItemAttribute("partAnime", IsNullable = false)]
        public SpriteStudioAnimePackAnimePartAnime[] partAnimes;
    }
    
    public partial class SpriteStudioAnimePackAnimeSettings
    {
        public byte fps;
        public byte frameCount;
        public string sortMode;
        public string pivot;
    }
    
    public partial class SpriteStudioAnimePackAnimePartAnime
    {
        public string partName;
        [System.Xml.Serialization.XmlArrayItemAttribute("attribute", IsNullable = false)]
        public SpriteStudioAnimePackAnimePartAnimeAttribute[] attributes;
    }
    
    public partial class SpriteStudioAnimePackAnimePartAnimeAttribute
    {
        [System.Xml.Serialization.XmlElementAttribute("key")]
        public SpriteStudioAnimePackAnimePartAnimeAttributeKey[] key;
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string tag;
    }
    
    public partial class SpriteStudioAnimePackAnimePartAnimeAttributeKey
    {        
        public SpriteStudioAnimePackAnimePartAnimeAttributeKeyCurve curve;
        public SpriteStudioAnimePackAnimePartAnimeAttributeKeyValue value;
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public sbyte time;
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string ipType;
    }
    
    public partial class SpriteStudioAnimePackAnimePartAnimeAttributeKeyCurve
    {
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public byte syncStartEnd;
        [System.Xml.Serialization.XmlTextAttribute()]
        public string Value;
    }
    
    public partial class SpriteStudioAnimePackAnimePartAnimeAttributeKeyValue
    {
        public byte integer;
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool integerSpecified;
        public string point;
        public string rect;
        public string @string;
        public string target;
        public string blendType;
        public SpriteStudioAnimePackAnimePartAnimeAttributeKeyValueColor color;
        public SpriteStudioAnimePackAnimePartAnimeAttributeKeyValueLT LT;
        public SpriteStudioAnimePackAnimePartAnimeAttributeKeyValueRT RT;
        public SpriteStudioAnimePackAnimePartAnimeAttributeKeyValueLB LB;
        public SpriteStudioAnimePackAnimePartAnimeAttributeKeyValueRB RB;
        public byte mapId;
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool mapIdSpecified;
        public string name;
        [System.Xml.Serialization.XmlTextAttribute()]
        public string[] Text;
    }
    
    public partial class SpriteStudioAnimePackAnimePartAnimeAttributeKeyValueColor
    {
        public string rgba;
        public byte rate;
    }
    
    public partial class SpriteStudioAnimePackAnimePartAnimeAttributeKeyValueLT
    {
        public string rgba;
        public byte rate;
        [System.Xml.Serialization.XmlTextAttribute()]
        public string[] Text;
    }
    
    public partial class SpriteStudioAnimePackAnimePartAnimeAttributeKeyValueRT
    {
        public string rgba;
        public byte rate;
        [System.Xml.Serialization.XmlTextAttribute()]
        public string[] Text;
    }
    
    public partial class SpriteStudioAnimePackAnimePartAnimeAttributeKeyValueLB
    {
        public string rgba;
        public byte rate;
        [System.Xml.Serialization.XmlTextAttribute()]
        public string[] Text;
    }
    
    public partial class SpriteStudioAnimePackAnimePartAnimeAttributeKeyValueRB
    {
        public string rgba;
        public byte rate;
        [System.Xml.Serialization.XmlTextAttribute()]
        public string[] Text;
    }
}