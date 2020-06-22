using System;
using System.Drawing;
using Core;


//this base class is adapted from from Jimmy Bogard
//http://grabbagoft.blogspot.com/2007/06/generic-value-object-equality.html

namespace Domain
{
    public class ImageSize : ValueObject<ImageSize>
    {
    public float Height { get; }
    public float Width { get; }
    public int DPI { get; }
    public int PixelHeight { get; }
    public int PixelWidth { get; }

    public ImageSize(float width, float height, int dpi)
    {
        AssertArgument.IsPositive(nameof(width), width);
        AssertArgument.IsPositive(nameof(height), height);
        AssertArgument.IsPositive(nameof(dpi), dpi);

        Width = width;
        Height = height;
        DPI = dpi;
        PixelHeight = ToPixels(height, dpi);
        PixelWidth = ToPixels(width, dpi);
    }

    public ImageSize(int pixelWidth, int pixelHeight, int dpi)
    {
        AssertArgument.IsPositive(nameof(pixelWidth), pixelWidth);
        AssertArgument.IsPositive(nameof(pixelHeight), pixelHeight);
        AssertArgument.IsPositive(nameof(dpi), dpi);

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
    }
}