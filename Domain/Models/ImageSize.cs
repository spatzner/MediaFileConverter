using System;
using System.Drawing;

namespace Domain.Models
{
    public class ImageSize
    {
        public double Height { get; }
        public double Width { get; }
        public int DPI { get; }
        public int PixelHeight { get; }
        public int PixelWidth { get; }

        public ImageSize(double width, double height, int dpi)
        {
            Height = height;
            Width = width;
            DPI = dpi;
            PixelHeight = ToPixels(height, dpi);
            PixelWidth = ToPixels(width, dpi);
        }

        public Size ToSize()
        {
            return new Size(PixelWidth, PixelHeight);
        }

        private static int ToPixels(double length, int dpi)
        {
            return Convert.ToInt32(Math.Floor(length * dpi));
        }
    }
}