using System;
using System.Collections.Generic;
using System.Linq;
using Core;
using Ninject;

namespace Domain
{
    public class FileProcessor : IFileProcessor
    {
        private readonly IImageConverter aiToSVGConverter;
        private readonly IImageConverter svgToPNGConverter;

        private readonly List<ImageSize> SkipSizeIterator;

        public FileProcessor([Named(ConverterType.AIToSVG)] IImageConverter svgToPNGConverter,
                             [Named(ConverterType.SVGToPNG)] IImageConverter aiToSVGConverter)
        {
            AssertArgument.IsNotNull(nameof(svgToPNGConverter), svgToPNGConverter);
            AssertArgument.IsNotNull(nameof(aiToSVGConverter), aiToSVGConverter);

            this.aiToSVGConverter = aiToSVGConverter;
            this.svgToPNGConverter = svgToPNGConverter;

            SkipSizeIterator = new List<ImageSize> {new ImageSize(1, 1)};
        }

        public IEnumerable<string> ConvertAIToPNG(List<string> files, List<ImageSize> imageSizes, string saveLocation)
        {
            var svgFiles = Convert(files, SkipSizeIterator, saveLocation, aiToSVGConverter.Convert);

            return ConvertSVGToPNG(svgFiles, imageSizes, saveLocation);
        }

        public IEnumerable<string> ConvertSVGToPNG(IEnumerable<string> files, List<ImageSize> imageSizes,
            string saveLocation)
        {
           return Convert(files, imageSizes, saveLocation, svgToPNGConverter.Convert);
        }

        public IEnumerable<string> Convert(IEnumerable<string> files, List<ImageSize> imageSizes, string saveLocation,
            Func<string, ImageSize, string, string> converterFunc)
        {
            foreach (var file in files)
            foreach (var imageSize in imageSizes)
                yield return converterFunc(file, imageSize, saveLocation);
        }
    }
}
