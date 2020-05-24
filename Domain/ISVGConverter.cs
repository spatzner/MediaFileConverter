using System.Drawing;

namespace Domain
{
    public interface ISVGConverter
    {
        void ConvertToPNG(string file, Size size, string saveLocation);
    }
}