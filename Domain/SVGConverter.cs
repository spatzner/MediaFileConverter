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
using Infrastructure;
using Svg;


namespace Domain
{
    public class SVGConverter : ISVGConverter
    {
        private readonly ISVGProvider _svgProvider;

        public SVGConverter()
        {
            _svgProvider = new SVGProvider();
        }

        public SVGConverter(ISVGProvider svgProvider)
        {
            _svgProvider = svgProvider;
        }

        public void ConvertToPNG(string file, Size size, string saveLocation)
        {
            SvgDocument svgDocument = GetDocument(file);
            Size intSize = DetermineSize(size, svgDocument);
            Bitmap bitmap = new Bitmap(intSize.Width, intSize.Height);

            svgDocument.Draw(bitmap);

            bitmap.Save(saveLocation, ImageFormat.Png);
        }

        private static Size DetermineSize(Size size, SvgDocument svgDocument)
        {
            Size intSize = new Size(size.Width, size.Height);
            if (svgDocument.Width > svgDocument.Height != size.Width > size.Height)
                intSize = new Size(size.Height, size.Width);
            return intSize;
        }

        private SvgDocument GetDocument(string file)
        {
            SvgDocument svgDocument = _svgProvider.GetDocument(file);
            svgDocument.AspectRatio = new SvgAspectRatio(SvgPreserveAspectRatio.none, false);
            return svgDocument;
        }
    }
}
