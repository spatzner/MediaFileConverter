using System.Collections.Generic;
using Applications;

namespace UI.ViewModels
{
    public interface IFileConverterViewModel
    {
        List<string> FilesToConvert { get; }
        IReadOnlyCollection<Resolution> SuppliedResolutions { get; }
        string SaveLocation { get; set; }
        void ConvertFiles(List<Resolution> selectedResolutions);
        void AddSuppliedResolution(double width, double height, int dpi);
    }
}