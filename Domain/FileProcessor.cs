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

        public FileProcessor()
        {
            _svgConverter = new SVGConverter();
        }

        public FileProcessor(ISVGConverter svgConverter)
        {
            _svgConverter = svgConverter;
        }

        public void ConvertSVGToPNG(List<string> files, List<Size> sizes, string saveLocation)
        {
            Directory.CreateDirectory(saveLocation);
            foreach (string file in files)
            {
                var fileName = Path.GetFileNameWithoutExtension(file);
                var outputSaveLocation = Path.Combine(saveLocation, fileName);
                Directory.CreateDirectory(outputSaveLocation);

                foreach (var size in sizes)
                {
                    var fileSaveLocation =
                        Path.Combine(outputSaveLocation, $"{fileName}_{size.Width}x{size.Height}.png");
                    
                        _svgConverter.ConvertToPNG(file, size, fileSaveLocation);
                }
            }
        }
    }
}
