using System.Drawing;
using System.Drawing.Imaging;
using Svg;

namespace Infrastructure.Wrappers
{
    public class BitmapWrapper : IBitmapWrapper
    {
        public void CreatePNG(string fileName, SvgDocument svgDocument, Size internSize)
        {
            using (Bitmap bitmap = new Bitmap(internSize.Width, internSize.Height))
            {
                svgDocument.Draw(bitmap);
                bitmap.Save(fileName, ImageFormat.Png);
            }
        }
    }
}