using Core;
using Domain;

namespace Applications
{
    public class Resolution
    {
        public float Width { get; }
        public float Height { get; }
        public int DPI { get; }

        public Resolution(float widthInches, float heightInches, int dpi)
        {

            AssertArgument.IsPositive(nameof(widthInches), widthInches);
            AssertArgument.IsPositive(nameof(heightInches), heightInches);
            AssertArgument.IsPositive(nameof(dpi), dpi);

            Width = widthInches;
            Height = heightInches;
            DPI = dpi;
        }

        //TODO: use AutoMapper
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