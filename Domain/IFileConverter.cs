using System.Collections.Generic;
using System.Drawing;

namespace Domain
{
    public interface IFileConverter
    {
        void ConvertSVGToPNG(List<string> files, List<Size> sizes, string saveLocation);
    }
}