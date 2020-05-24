﻿using System;
using System.Drawing;
using Domain;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            SVGConverter converter = new SVGConverter();

            string file = @"C:\Users\scott\Desktop\Artboard 1.svg";
            Size size = new Size(3000,240);
            string saveLocation = $@"C:\Users\scott\Desktop\Artboard 1_{size.Width}x{size.Height}.png";

            converter.ConvertToPNG(file, size, saveLocation);
        }
    }
}