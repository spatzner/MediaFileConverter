using Svg;

namespace Infrastructure.Wrappers
{
    public interface ISVGWrapper
    {
        SvgDocument GetDocument(string fileLocation);
        SvgDocument GetDocument(string fileLocation, SvgAspectRatio aspectRatio);
    }
}