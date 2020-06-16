using Svg;

namespace Infrastructure.Wrappers
{
    public class SVGWrapper : ISVGWrapper
    {
        public SvgDocument GetDocument(string fileLocation)
        {
            return SvgDocument.Open(fileLocation);
        }

        public SvgDocument GetDocument(string fileLocation, SvgAspectRatio aspectRatio)
        {
            SvgDocument svgDocument = GetDocument(fileLocation);
            if (aspectRatio != null)
                svgDocument.AspectRatio = aspectRatio;
            return svgDocument;
        }
    }
}
