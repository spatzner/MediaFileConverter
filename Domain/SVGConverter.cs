using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Hosting;
using Svg;


namespace Domain
{
    public class SVGConverter : ISVGConverter
    {
        public void ConvertToPNG(string file, Size size, string saveLocation)
        {
            SvgDocument svgDocument = SvgDocument.Open(file);
            svgDocument.AspectRatio = new SvgAspectRatio(SvgPreserveAspectRatio.none, false);

            Size intSize = new Size(size.Width, size.Height);
            if (svgDocument.Width > svgDocument.Height != size.Width > size.Height )
                intSize = new Size(size.Height, size.Width);

            Bitmap bitmap = new Bitmap(intSize.Width, intSize.Height);

            svgDocument.Draw(bitmap);

            bitmap.Save(saveLocation, ImageFormat.Png);
        }
    }
}
