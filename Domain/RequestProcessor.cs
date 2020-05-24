﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class RequestProcessor
    {
        private readonly ISVGConverter _svgConverter;

        public RequestProcessor(ISVGConverter svgConverter)
        {
            _svgConverter = svgConverter;
        }

        public void ConvertFiles(List<string> files, List<Size> sizes, string saveLocation)
        {
            foreach (string file in files)
            {
                var fileName = Path.GetFileNameWithoutExtension(file);
                var fileSaveLocation = Path.Combine(saveLocation, fileName);

                foreach (var size in sizes)
                {
                    _svgConverter.ConvertToPNG(file, size, fileSaveLocation);
                }
            }
        }
    }
}
