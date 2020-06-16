using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows;
using System.Windows.Forms;
using Applications;

namespace UI.ViewModels
{
    public class FileConverterViewModel : IFileConverterViewModel
    {
        public List<string> FilesToConvert { get; }
        public IReadOnlyCollection<Resolution> SuppliedResolutions { get; }
        public string SaveLocation { get; set; }

        private readonly string _defaultSaveLocation;
        private readonly IFileConverter _fileConverter;

   
        public FileConverterViewModel(IFileConverter fileConverter)
        {
            _fileConverter = fileConverter;
            _defaultSaveLocation = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);

            FilesToConvert = new List<string>();
            SaveLocation = _defaultSaveLocation;
            SuppliedResolutions = _fileConverter.SuppliedResolutions;
        }


        public void ConvertFiles(List<Resolution> selectedResolutions)
        {
            var saveLocation = SaveLocation;
            if (SaveLocation == _defaultSaveLocation)
                saveLocation = Path.Combine(SaveLocation, $"MediaExporter{DateTime.Now:yyyyMMddhhmmss}");

            _fileConverter.ConvertFiles(FilesToConvert, selectedResolutions, saveLocation);
        }

        public void AddSuppliedResolution(float width, float height, int dpi)
        {
            _fileConverter.AddSuppliedResolution(new Resolution(width, height, dpi));
        }
    }
}
