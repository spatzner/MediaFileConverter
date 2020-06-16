using Svg;

namespace Infrastructure
{
    public interface ISVGProvider
    {
        SvgDocument GetDocument(string fileLocation);
    }
}