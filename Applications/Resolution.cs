using System;
using System.Drawing;
using Domain.Models;

namespace Applications
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

        public ImageSize ConvertToImageSize()
        {

            return new ImageSize(Width, Height, DPI);
        }

        public override string ToString()
        {
            return $"{Width}in x {Height}in";
        }
    }
}