using System.Drawing;
using Svg;

namespace Domain.Converters
{
    public interface IBitmapWrapper
    {
        void CreatePNG(string saveLocation, Size internSize, SvgDocument svgDocument);
    }
}