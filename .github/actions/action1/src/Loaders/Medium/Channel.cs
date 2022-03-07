using System.Xml;
using System.Xml.Serialization;

public record Channel {
    [XmlElement("item")]
    public List<Story> Stories {get; init;}
}
