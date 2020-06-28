using System.Collections.Generic;
using System.Drawing;

namespace Domain
{
    public interface IFileProcessor
    {
        IEnumerable<string> ConvertAIToPNG(List<string> files, List<ImageSize> imageSizes, string saveLocation);
        IEnumerable<string> ConvertSVGToPNG(IEnumerable<string> files, List<ImageSize> imageSizes, string saveLocation);
    }
}