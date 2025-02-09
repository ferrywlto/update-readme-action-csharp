using System.Xml;
using System.Xml.Serialization;

namespace Loaders.Medium;
public record Story
{
    [XmlElement("title")]
    public string Title { get; init; }
    [XmlElement("link")]
    public string Link { get; init; }
    [XmlElement("pubDate")]
    public string PublishDate { get; init; }

    public Story()
    {
        Title = string.Empty;
        Link = string.Empty;
        PublishDate = string.Empty;
    }
}
