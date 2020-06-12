using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using Domain;
using Domain.Models;
using Utilities;

namespace Applications
{
    public class FileConverter : IFileConverter
    {
        public IReadOnlyCollection<Resolution> SuppliedResolutions => _suppliedResolutions.AsReadOnly();
  
        private readonly List<Resolution> _suppliedResolutions;
        private readonly string _defaultSaveLocation;
        private readonly IFileProcessor _fileProcessor;

        public FileConverter()
        {
            _suppliedResolutions = new List<Resolution>
            {
                new Resolution(4,6, 300),
                new Resolution(8,10, 300),
                new Resolution(11,14, 300)
            };

            _fileProcessor = new FileProcessor();
            _defaultSaveLocation = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);

        }


        public void ConvertFiles(List<string> filesToConvert, List<Resolution> selectedResolutions, string saveLocation)
        {
            CheckArgument.IsNullOrEmpty(nameof(filesToConvert), filesToConvert);
            CheckArgument.IsNullOrEmpty(nameof(selectedResolutions), selectedResolutions);
            CheckArgument.IsNullOrEmpty(nameof(saveLocation), saveLocation);

            if (saveLocation == _defaultSaveLocation)
                saveLocation = Path.Combine(saveLocation, $"FileConverter{DateTime.Now:yyyyMMddhhmmss}");

            List<ImageSize> sizes = selectedResolutions.Select(x => x.ConvertToImageSize()).ToList();
            
            _fileProcessor.ConvertSVGToPNG(filesToConvert, sizes, saveLocation);

            selectedResolutions.Clear();
            filesToConvert.Clear();
        }

        public void AddSuppliedResolution(Resolution resolution)
        {
            _suppliedResolutions.Add(resolution);
            //TODO: Save to config
        }

    }
}
