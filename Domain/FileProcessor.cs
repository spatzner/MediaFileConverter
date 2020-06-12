using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Converters;
using Domain.Models;

namespace Domain
{
    public class FileProcessor : IFileProcessor
    {
        private readonly ISVGConverter _svgConverter;
        private readonly IAIConverter _aiConverter;

        public FileProcessor()
        {
            _svgConverter = new SVGConverter();
            _aiConverter = new AIConverter();
        }

        public FileProcessor(ISVGConverter svgConverter, IAIConverter aiConverter)
        {
            _svgConverter = svgConverter;
            _aiConverter = aiConverter;
        }

        public void ConvertAIToPNG(List<string> files, List<ImageSize> imageSizes, string saveLocation)
        {
            Directory.CreateDirectory(saveLocation);
            foreach (string file in files)
            {
                string fileName = Path.GetFileNameWithoutExtension(file);
                string outputSaveLocation = Path.Combine(saveLocation, fileName);

                string svgFile = _aiConverter.ConvertToSVG(file, outputSaveLocation);

                foreach (ImageSize imageSize in imageSizes)
                {
                    string fileSaveLocation =
                        Path.Combine(outputSaveLocation, $"{fileName}_{imageSize.Width}x{imageSize.Height}.png");

                    _svgConverter.ConvertToPNG(svgFile, imageSize.ToSize(), fileSaveLocation);
                }
            }
        }

        public void ConvertSVGToPNG(List<string> files, List<ImageSize> imageSizes, string saveLocation)
        {
            Directory.CreateDirectory(saveLocation);
            foreach (string file in files)
            {
                var fileName = Path.GetFileNameWithoutExtension(file);
                var outputSaveLocation = Path.Combine(saveLocation, fileName);
                Directory.CreateDirectory(outputSaveLocation);

                foreach (var imageSize in imageSizes)
                {
                    var fileSaveLocation =
                        Path.Combine(outputSaveLocation, $"{fileName}_{imageSize.Width}x{imageSize.Height}.png");

                    _svgConverter.ConvertToPNG(file, imageSize.ToSize(), fileSaveLocation);
                }
            }
        }
    }
}
