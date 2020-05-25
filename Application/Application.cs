using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using Domain;

namespace Application
{
    public class Application
    {
        public List<string> FilesToConvert { get; }
        public List<Resolution> SelectedResolutions { get; }
        public IReadOnlyCollection<Resolution> SuppliedResolutions => _suppliedResolutions.AsReadOnly();
        public string SaveLocation { get; set; }

        private readonly List<Resolution> _suppliedResolutions;
        private readonly string _defaultSaveLocation;
        private readonly IFileConverter _fileConverter;

        public Application()
        {
            FilesToConvert = new List<string>();
            SelectedResolutions = new List<Resolution>();

            _suppliedResolutions = new List<Resolution>
            {
                new Resolution(4,6, 300),
                new Resolution(8,10, 300),
                new Resolution(11,14, 300)
            };

            _fileConverter = new FileConverter();
            _defaultSaveLocation = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            SaveLocation = _defaultSaveLocation;
        }


        public void ConvertFiles()
        {
            string saveLocation = SaveLocation;
            if (SaveLocation == _defaultSaveLocation)
                saveLocation = Path.Combine(saveLocation, $"FileConverter{DateTime.Now:yyyyMMddhhmmss}");

            List<Size> sizes = SelectedResolutions.Select(x => x.ConvertToSize()).ToList();
            _fileConverter.ConvertSVGToPNG(FilesToConvert, sizes, saveLocation);
        }

        public void AddSuppliedResolution(Resolution resolution)
        {
            _suppliedResolutions.Add(resolution);
            //TODO: Save to config
        }

    }
}
