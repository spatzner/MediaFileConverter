using System;
using System.Drawing;

namespace Application
{
    public class Resolution
    {
        
        public double Width { get; }
        public double Height { get; }
        public int DPI { get; }

        public Resolution(double widthInches, double heightInches, int dpi)
        {
            Width = widthInches;
            Height = heightInches;
            DPI = dpi;
        }

        public Size ConvertToSize()
        {
            int widthPx = Convert.ToInt32(Math.Floor(Width * DPI));
            int heightPx = Convert.ToInt32(Math.Floor(Height * DPI));

            return new Size(widthPx, heightPx);
        }
    }
}