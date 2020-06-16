using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using Infrastructure;
using Infrastructure.Providers;
using Infrastructure.Wrappers;
using Svg;
using Utilities;

namespace Domain.Converters
{
    public class SVGConverter : ISVGConverter
    {
        private readonly ISVGWrapper isvgDocumentWrapper;


        public SVGConverter(ISVGWrapper isvgDocumentWrapper)
        {
            this.isvgDocumentWrapper = isvgDocumentWrapper;

            CheckIfArgument.IsNull(nameof(this.isvgDocumentWrapper), this.isvgDocumentWrapper);
        }

        public void ConvertToPNG(string file, Size size, string saveLocation)
        {
            var dir = Path.GetDirectoryName(saveLocation);
            Directory.CreateDirectory(dir);

            SvgDocument svgDocument = GetDocument(file);
            Size internSize = OrientSize(size, svgDocument);

            using (Bitmap bitmap = new Bitmap(internSize.Width, internSize.Height))
            {
                svgDocument.Draw(bitmap);
                bitmap.Save(saveLocation, ImageFormat.Png);
            }
        }

        private static Size OrientSize(Size size, SvgDocument svgDocument)
        {
            return svgDocument.Width > svgDocument.Height != size.Width > size.Height
                ? new Size(size.Height, size.Width)
                : new Size(size.Width, size.Height);
        }

        private SvgDocument GetDocument(string file)
        {
            return isvgDocumentWrapper.GetDocument(file, new SvgAspectRatio(SvgPreserveAspectRatio.none, false));
        }
    }
}
