using System.Drawing;
using System.IO;
using Core;
using Infrastructure.Providers;
using Infrastructure.Wrappers;
using Svg;

namespace Domain
{
    public class SVGToPNGConverter : IImageConverter
    {
        private readonly ISVGWrapper svgDocumentWrapper;
        private readonly IBitmapWrapper bitmapWrapper;
        private readonly IFileSystemProvider fileSystemProvider;

        public SVGToPNGConverter(ISVGWrapper svgDocumentWrapper, IBitmapWrapper bitmapWrapper, IFileSystemProvider fileSystemProvider)
        {
            AssertArgument.IsNotNull(nameof(svgDocumentWrapper), svgDocumentWrapper);
            AssertArgument.IsNotNull(nameof(bitmapWrapper), bitmapWrapper);
            AssertArgument.IsNotNull(nameof(fileSystemProvider), fileSystemProvider);

            this.svgDocumentWrapper = svgDocumentWrapper;
            this.bitmapWrapper = bitmapWrapper;
            this.fileSystemProvider = fileSystemProvider;
        }

        public string Convert(string file, ImageSize imageSize, string saveLocation)
        {
            string outputSaveLocation = GetOutputLocation(file, saveLocation);
            fileSystemProvider.CreateDirectory(outputSaveLocation);

            string saveFile = GetFileSaveLocation(file, outputSaveLocation, imageSize);
            SvgDocument svgDocument = GetDocument(file);
            Size size = OrientSize(imageSize.ToSize(), svgDocument);


            bitmapWrapper.CreatePNG(saveFile, svgDocument, size);
            return saveFile;
        }

        private SvgDocument GetDocument(string file)
        {
            return svgDocumentWrapper.GetDocument(file, new SvgAspectRatio(SvgPreserveAspectRatio.none, false));
        }

        private static Size OrientSize(Size size, SvgDocument svgDocument)
        {
            return svgDocument.Width > svgDocument.Height != size.Width > size.Height
                ? new Size(size.Height, size.Width)
                : new Size(size.Width, size.Height);
        }

        //TODO: Move file naming to application layer
        private string GetOutputLocation(string file, string saveLocation)
        {
            string fileName = fileSystemProvider.GetFileNameWithoutExtension(file);
            return Path.Combine(saveLocation, fileName);
        }

        private string GetFileSaveLocation(string file, string saveLocation, ImageSize imageSize)
        {
            string fileName = fileSystemProvider.GetFileNameWithoutExtension(file);

            return
                Path.Combine(saveLocation, $"{fileName}_{imageSize.Width:F}x{imageSize.Height:F}.png");
        }
    }
}