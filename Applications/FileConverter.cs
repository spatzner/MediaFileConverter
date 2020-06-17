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
            CheckIfArgument.IsNull(nameof(fileProcessor), fileProcessor);
            CheckIfArgument.IsNull(nameof(dateTimeProvider), dateTimeProvider);
            CheckIfArgument.IsNullOrEmpty(nameof(defaultSaveLocation), defaultSaveLocation);
            CheckIfArgument.IsNullOrEmpty(nameof(suppliedResolutions), suppliedResolutions);

            this.fileProcessor = fileProcessor;
            this.dateTimeProvider = dateTimeProvider;
            this.defaultSaveLocation = defaultSaveLocation;
            this.suppliedResolutions = suppliedResolutions;
        }

        public void ConvertFiles(List<string> filesToConvert, List<Resolution> selectedResolutions, string saveLocation)
        {
            CheckIfArgument.IsNullOrEmpty(nameof(filesToConvert), filesToConvert);
            CheckIfArgument.IsNullOrEmpty(nameof(selectedResolutions), selectedResolutions);
            CheckIfArgument.IsNullOrEmpty(nameof(saveLocation), saveLocation);

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
