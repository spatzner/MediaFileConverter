using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using Infrastructure;
using Svg;

namespace Domain.Converters
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
            var dir = Path.GetDirectoryName(saveLocation);
            Directory.CreateDirectory(dir);

            SvgDocument svgDocument = GetDocument(file);
            Size intSize = DetermineSize(size, svgDocument);

            using (Bitmap bitmap = new Bitmap(intSize.Width, intSize.Height))
            {
                svgDocument.Draw(bitmap);
                bitmap.Save(saveLocation, ImageFormat.Png);
            }
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
