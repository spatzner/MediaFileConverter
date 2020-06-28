using System.Drawing;
using Svg;

namespace Infrastructure.Wrappers
{
    public interface IBitmapWrapper
    {
        void CreatePNG(string fileName, SvgDocument svgDocument, Size internSize);
    }
}