using System.Drawing;
using Domain.Converters;
using Infrastructure.Providers;
using Infrastructure.Wrappers;
using Svg;
using Utilities;

namespace Domain
{
    public class SVGConverter : ISVGConverter
    {
        private readonly ISVGWrapper svgDocumentWrapper;
        private readonly IBitmapWrapper bitmapWrapper;
        private readonly IFileSystemProvider fileSystemProvider;

        public SVGConverter(ISVGWrapper svgDocumentWrapper, IBitmapWrapper bitmapWrapper, IFileSystemProvider fileSystemProvider)
        {
            CheckIfArgument.IsNull(nameof(svgDocumentWrapper), svgDocumentWrapper);
            CheckIfArgument.IsNull(nameof(bitmapWrapper), bitmapWrapper);
            CheckIfArgument.IsNull(nameof(fileSystemProvider), fileSystemProvider);

            this.svgDocumentWrapper = svgDocumentWrapper;
            this.bitmapWrapper = bitmapWrapper;
            this.fileSystemProvider = fileSystemProvider;
        }

        public void ConvertToPNG(string file, Size size, string saveLocation)
        {
            fileSystemProvider.CreateDirectory(saveLocation);

            SvgDocument svgDocument = GetDocument(file);
            Size internSize = OrientSize(size, svgDocument);

            bitmapWrapper.CreatePNG(saveLocation, internSize, svgDocument);
        }

        private static Size OrientSize(Size size, SvgDocument svgDocument)
        {
            return svgDocument.Width > svgDocument.Height != size.Width > size.Height
                ? new Size(size.Height, size.Width)
                : new Size(size.Width, size.Height);
        }

        private SvgDocument GetDocument(string file)
        {
            return svgDocumentWrapper.GetDocument(file, new SvgAspectRatio(SvgPreserveAspectRatio.none, false));
        }
    }
}
