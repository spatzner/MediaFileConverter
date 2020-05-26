using System.Collections.Generic;
using System.Drawing;

namespace Domain
{
    public interface IFileProcessor
    {
        void ConvertSVGToPNG(List<string> files, List<Size> sizes, string saveLocation);
    }
}