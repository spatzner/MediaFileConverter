using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Converters;

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

        public void ConvertAIToPNG(List<string> files, List<Size> sizes, string saveLocation)
        {
            Directory.CreateDirectory(saveLocation);
            foreach (string file in files)
            {
                string fileName = Path.GetFileNameWithoutExtension(file);
                string outputSaveLocation = Path.Combine(saveLocation, fileName);

                string svgFile = _aiConverter.ConvertToSVG(file, outputSaveLocation);

                foreach (Size size in sizes)
                {
                    string fileSaveLocation =
                        Path.Combine(outputSaveLocation, $"{fileName}_{size.Width}x{size.Height}.png");

                    _svgConverter.ConvertToPNG(svgFile, size, fileSaveLocation);
                }
            }
        }
    }
}
