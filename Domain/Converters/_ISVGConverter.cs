using System.Drawing;

namespace Domain.Converters
{
    public interface ISVGConverter
    {
        void ConvertToPNG(string file, Size size, string saveLocation);
    }
}