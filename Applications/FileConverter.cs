using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using Domain;
using Domain.Models;
using Infrastructure.Providers;
using Utilities;

namespace Applications
{
    public class FileConverter : IFileConverter
    {
        public IReadOnlyCollection<Resolution> SuppliedResolutions => suppliedResolutions.AsReadOnly();
  
        private readonly List<Resolution> suppliedResolutions;
        private readonly string defaultSaveLocation;
        private readonly IFileProcessor fileProcessor;
        private readonly IDateTimeProvider dateTimeProvider;

        public FileConverter(IFileProcessor fileProcessor, 
            IDateTimeProvider dateTimeProvider, 
            List<Resolution> suppliedResolutions, 
            string defaultSaveLocation)
        {
            this.fileProcessor = fileProcessor;
            this.dateTimeProvider = dateTimeProvider;
            this.defaultSaveLocation = defaultSaveLocation;
            this.suppliedResolutions = suppliedResolutions;

            CheckIfArgument.IsNull(nameof(this.fileProcessor), this.fileProcessor);
            CheckIfArgument.IsNull(nameof(this.dateTimeProvider),this.dateTimeProvider);
            CheckIfArgument.IsNullOrEmpty(nameof(this.defaultSaveLocation), this.defaultSaveLocation);
            CheckIfArgument.IsNullOrEmpty(nameof(this.suppliedResolutions), this.suppliedResolutions);
        }

        public void ConvertFiles(List<string> filesToConvert, List<Resolution> selectedResolutions, string saveLocation)
        {
            CheckIfArgument.IsNullOrEmpty(nameof(filesToConvert), filesToConvert);
            CheckIfArgument.IsNullOrEmpty(nameof(selectedResolutions), selectedResolutions);
            CheckIfArgument.IsNullOrEmpty(nameof(saveLocation), saveLocation);

            if (saveLocation == defaultSaveLocation)
                saveLocation = Path.Combine(saveLocation, $"FileConverter{dateTimeProvider.Now:yyyyMMddhhmmss}");

            List<ImageSize> sizes = selectedResolutions.Select(x => x.ConvertToImageSize()).ToList();
            
            fileProcessor.ConvertSVGToPNG(filesToConvert, sizes, saveLocation);
        }

        public void AddSuppliedResolution(Resolution resolution)
        {
            throw new NotImplementedException();
            //suppliedResolutions.Add(resolution);
            //TODO: Save to config
        }

    }
}
