using System.Collections.Generic;
using System.Drawing;

namespace Domain
{
    public interface IFileProcessor
    {
        void ConvertAIToPNG(List<string> files, List<ImageSize> imageSizes, string saveLocation);
        void ConvertSVGToPNG(List<string> files, List<ImageSize> imageSizes, string saveLocation);
    }
}