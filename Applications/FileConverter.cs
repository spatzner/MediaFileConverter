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

        public FileConverter(IFileProcessor fileProcessor, string defaultSaveLocation, List<Resolution> suppliedResolutions)
        {
            _fileProcessor = fileProcessor;
            _defaultSaveLocation = defaultSaveLocation;
            _suppliedResolutions = suppliedResolutions;

            CheckIfArgument.IsNull(nameof(_fileProcessor), _fileProcessor);
            CheckIfArgument.IsNullOrEmpty(nameof(_defaultSaveLocation), _defaultSaveLocation);
            CheckIfArgument.IsNullOrEmpty(nameof(_suppliedResolutions), _suppliedResolutions);
        }

        public void ConvertFiles(List<string> filesToConvert, List<Resolution> selectedResolutions, string saveLocation)
        {
            CheckIfArgument.IsNullOrEmpty(nameof(filesToConvert), filesToConvert);
            CheckIfArgument.IsNullOrEmpty(nameof(selectedResolutions), selectedResolutions);
            CheckIfArgument.IsNullOrEmpty(nameof(saveLocation), saveLocation);

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
