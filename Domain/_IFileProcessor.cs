using System.Collections.Generic;
using System.Drawing;

namespace Domain
{
    public interface IFileProcessor
    {
        void ConvertAIToPNG(List<string> files, List<Size> sizes, string saveLocation);
    }
}