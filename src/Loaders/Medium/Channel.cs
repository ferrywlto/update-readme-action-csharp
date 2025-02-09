using System.Xml;
using System.Xml.Serialization;

namespace Loaders.Medium;
public record Channel {
    [XmlElement("item")]
    public List<Story> Stories {get; init;}

    public Channel() {
        Stories = [];
    }
}
