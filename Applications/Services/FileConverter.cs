using System;
using System.Collections.Generic;
using System.Linq;
using Core;
using Domain;

namespace Applications
{
    public class FileConverter : IFileConverter
    {
        public IReadOnlyCollection<Resolution> SuppliedResolutions => suppliedResolutions.AsReadOnly();
  
        private readonly List<Resolution> suppliedResolutions;
        private readonly IFileProcessor fileProcessor;

        public FileConverter(IFileProcessor fileProcessor, 
            List<Resolution> suppliedResolutions)
        {
            AssertArgument.IsNotNull(nameof(fileProcessor), fileProcessor);
            AssertArgument.IsNotNullOrEmpty(nameof(suppliedResolutions), suppliedResolutions);

            this.fileProcessor = fileProcessor;
            this.suppliedResolutions = suppliedResolutions;
        }

        public void ConvertFiles(List<string> filesToConvert, List<Resolution> selectedResolutions, string saveLocation)
        {
            AssertArgument.IsNotNullOrEmpty(nameof(filesToConvert), filesToConvert);
            AssertArgument.IsNotNullOrEmpty(nameof(selectedResolutions), selectedResolutions);
            AssertArgument.IsNotNullOrEmpty(nameof(saveLocation), saveLocation);

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
