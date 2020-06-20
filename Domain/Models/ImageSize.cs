using System;
using System.Drawing;
using Utilities;

namespace Domain
{
    public class ImageSize
    {
        public float Height { get; }
        public float Width { get; }
        public int DPI { get; }
        public int PixelHeight { get; }
        public int PixelWidth { get; }

        public ImageSize(float width, float height, int dpi)
        {
            CheckIfArgument.IsPositive(nameof(width), width);
            CheckIfArgument.IsPositive(nameof(height), height);
            CheckIfArgument.IsPositive(nameof(dpi), dpi);

            Width = width;
            Height = height;
            DPI = dpi;
            PixelHeight = ToPixels(height, dpi);
            PixelWidth = ToPixels(width, dpi);
        }

        public ImageSize(int pixelWidth, int pixelHeight, int dpi)
        {
            CheckIfArgument.IsPositive(nameof(pixelWidth), pixelWidth);
            CheckIfArgument.IsPositive(nameof(pixelHeight), pixelHeight);
            CheckIfArgument.IsPositive(nameof(dpi), dpi);

            PixelWidth = pixelWidth;
            PixelHeight = pixelHeight;
            DPI = dpi;
            Width = ToInches(PixelWidth, DPI);
            Height = ToInches(pixelHeight, dpi);
        }

        public ImageSize(int pixelWidth, int pixelHeight) 
            : this(pixelWidth, pixelHeight, 300)
        {
        }

        //TODO: Use AutoMapper
        public Size ToSize()
        {
            return new Size(PixelWidth, PixelHeight);
        }

        private static int ToPixels(float length, int dpi)
        {
            return Convert.ToInt32(Math.Floor(length * dpi));
        }

        private static float ToInches(int pixels, int dpi)
        {
            return (float) pixels / dpi;
        }

        public override bool Equals(object obj)
        {
            if (!(obj is ImageSize imageSize))
                return false;

            return Equals(imageSize);
        }

        protected bool Equals(ImageSize other)
        {
            return DPI == other.DPI &&
                   PixelHeight == other.PixelHeight &&
                   PixelWidth == other.PixelWidth;
        }

        public override int GetHashCode()
        {
            unchecked
            {
                var hashCode = DPI;
                hashCode = (hashCode * 397) ^ PixelHeight;
                hashCode = (hashCode * 397) ^ PixelWidth;
                return hashCode;
            }
        }
    }
}