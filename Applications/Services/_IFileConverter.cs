using System.Collections.Generic;

namespace Applications
{
    public interface IFileConverter
    {
        IReadOnlyCollection<Resolution> SuppliedResolutions { get; }
        void ConvertFiles(List<string> filesToConvert, List<Resolution> selectedResolutions, string saveLocation);
        void AddSuppliedResolution(Resolution resolution);
    }
}