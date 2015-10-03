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
        public int fps;
        public int frameCount;
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
        public int arrayIndex;
        public int parentIndex;
        public string type;
        public string boundsType;
        public string inheritType;
        public SpriteStudioAnimePackModelValueIneheritRates ineheritRates;
        public string refEffectName;
        public string alphaBlendType;
        public int show;
    }
    
    public partial class SpriteStudioAnimePackModelValueIneheritRates
    {        
        public int ALPH;
        public int FLPH;
        public int FLPV;
        public int HIDE;
        public int IFLH;
        public int IFLV;
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
        public int fps;
        public int frameCount;
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
        public int time;
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string ipType;
    }
    
    public partial class SpriteStudioAnimePackAnimePartAnimeAttributeKeyCurve
    {
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public int syncStartEnd;
        [System.Xml.Serialization.XmlTextAttribute()]
        public string Value;
    }
    
    public partial class SpriteStudioAnimePackAnimePartAnimeAttributeKeyValue
    {
        public int integer;
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool integerSpecified;
        public string point;
        public string rect;
        public string @string;
        public string target;
        public string blendType;
        public SpriteStudioAnimePackAnimePartAnimeAttributeKeyValueColor color;
        public SpriteStudioAnimePackAnimePartAnimeAttributeKeyValueColors LT;
        public SpriteStudioAnimePackAnimePartAnimeAttributeKeyValueColors RT;
        public SpriteStudioAnimePackAnimePartAnimeAttributeKeyValueColors LB;
        public SpriteStudioAnimePackAnimePartAnimeAttributeKeyValueColors RB;
        public int mapId;
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool mapIdSpecified;
        public string name;
        [System.Xml.Serialization.XmlTextAttribute()]
        public string[] Text;
    }
    
    public partial class SpriteStudioAnimePackAnimePartAnimeAttributeKeyValueColor
    {
        public string rgba;
        public float rate;
    }
    
    public partial class SpriteStudioAnimePackAnimePartAnimeAttributeKeyValueColors
    {
        public string rgba;
        public float rate;
        [System.Xml.Serialization.XmlTextAttribute()]
        public string[] Text;
    }
    
}