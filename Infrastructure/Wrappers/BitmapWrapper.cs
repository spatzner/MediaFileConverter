using System.Drawing;
using System.Drawing.Imaging;
using Svg;

namespace Domain.Converters
{
    public class BitmapWrapper : IBitmapWrapper
    {
        public void CreatePNG(string saveLocation, Size internSize, SvgDocument svgDocument)
        {
            using (Bitmap bitmap = new Bitmap(internSize.Width, internSize.Height))
            {
                svgDocument.Draw(bitmap);
                bitmap.Save(saveLocation, ImageFormat.Png);
            }
        }
    }
}