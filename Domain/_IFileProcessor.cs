using System.Collections.Generic;
using System.Drawing;
using Domain.Models;

namespace Domain
{
    public interface IFileProcessor
    {
        void ConvertAIToPNG(List<string> files, List<ImageSize> imageSizes, string saveLocation);
        void ConvertSVGToPNG(List<string> files, List<ImageSize> imageSizes, string saveLocation);
    }
}