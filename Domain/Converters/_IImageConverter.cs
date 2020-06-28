using System;
using System.Collections.Generic;

namespace Domain
{
    public interface IImageConverter
    {
        string Convert(string file, ImageSize imageSize, string saveLocation);
    }
}