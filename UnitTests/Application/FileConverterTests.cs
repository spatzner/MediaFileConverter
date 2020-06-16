﻿using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Globalization;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using Applications;
using Castle.Components.DictionaryAdapter;
using Domain;
using Domain.Models;
using Infrastructure.Providers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using UnitTests.TestUtilities;

namespace UnitTests.Application
{
    [TestClass]
    public class FileConverterTests
    {
        #region Initialization

        private Mock<IFileProcessor> mockFileProcessor;
        private Mock<IDateTimeProvider> mockDateTimeProvider;
        private string fakeSaveLocation;
        private List<Resolution> fakeResolutions;
        private List<string> fakeFilesToConvert;

        private FileConverter sut;

        [TestInitialize]
        public void TestInitialize()
        {
            mockFileProcessor = new Mock<IFileProcessor>();
            mockDateTimeProvider = new Mock<IDateTimeProvider>();
            fakeSaveLocation = "SaveLocation";
            fakeResolutions = new List<Resolution> {new Resolution(6, 4, 300)};
            fakeFilesToConvert = new List<string>{"FakeFileLocation"};
        }

        #endregion Initialization

        #region Constructor Tests

        [TestMethod]
        [TestCategory(TestCategories.Unit)]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Constructor_WhenFileProcessorIsNull_ThrowsException()
        {
            sut = new FileConverter(null, mockDateTimeProvider.Object, fakeResolutions, fakeSaveLocation);
        }

        [TestMethod]
        [TestCategory(TestCategories.Unit)]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Constructor_WhenDateTimeProviderIsNull_ThrowsException()
        {
            sut = new FileConverter(mockFileProcessor.Object, null, fakeResolutions, fakeSaveLocation);
        }

        [TestMethod]
        [TestCategory(TestCategories.Unit)]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Constructor_WhenSuppliedResolutionIsNull_ThrowsException()
        {
            sut = new FileConverter(mockFileProcessor.Object,
                mockDateTimeProvider.Object,
                null,
                fakeSaveLocation);
        }

        [TestMethod]
        [TestCategory(TestCategories.Unit)]
        [ExpectedException(typeof(ArgumentException))]
        public void Constructor_WhenSuppliedResolutionIsEmpty_ThrowsException()
        {
            sut = new FileConverter(mockFileProcessor.Object,
                mockDateTimeProvider.Object,
                new List<Resolution>(),
                fakeSaveLocation);
        }

        [TestMethod]
        [TestCategory(TestCategories.Unit)]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Constructor_WhenDefaultSaveLocationIsNull_ThrowsException()
        {
            sut = new FileConverter(mockFileProcessor.Object,
                mockDateTimeProvider.Object,
                fakeResolutions,
                null);
        }

        [TestMethod]
        [TestCategory(TestCategories.Unit)]
        [ExpectedException(typeof(ArgumentException))]
        public void Constructor_WhenDefaultSaveLocationIsEmpty_ThrowsException()
        {
            sut = new FileConverter(mockFileProcessor.Object,
                mockDateTimeProvider.Object,
                fakeResolutions,
                string.Empty);
        }

        #endregion Constructor Tests

        #region ConvertFiles Tests

        [TestMethod]
        [TestCategory(TestCategories.Unit)]
        [ExpectedException(typeof(ArgumentNullException))]
        public void ConvertFiles_WhenFilesToConvertIsNull_ThrowsException()
        {
            sut = CreateValidFileConverter();

            sut.ConvertFiles(null, fakeResolutions, fakeSaveLocation);
        }

        [TestMethod]
        [TestCategory(TestCategories.Unit)]
        [ExpectedException(typeof(ArgumentException))]
        public void ConvertFiles_WhenFilesToConvertIsEmpty_ThrowsException()
        {
            sut = CreateValidFileConverter();

            sut.ConvertFiles(new List<string>(), fakeResolutions, fakeSaveLocation);
        }

        [TestMethod]
        [TestCategory(TestCategories.Unit)]
        [ExpectedException(typeof(ArgumentNullException))]
        public void ConvertFiles_WhenSelectedResolutionsIsNull_ThrowsException()
        {
            sut = CreateValidFileConverter();

            sut.ConvertFiles(fakeFilesToConvert, null, fakeSaveLocation);
        }

        [TestMethod]
        [TestCategory(TestCategories.Unit)]
        [ExpectedException(typeof(ArgumentException))]
        public void ConvertFiles_WhenSelectedResolutionsIsEmpty_ThrowsException()
        {
            sut = CreateValidFileConverter();

            sut.ConvertFiles(fakeFilesToConvert, new List<Resolution>(), fakeSaveLocation);
        }

        [TestMethod]
        [TestCategory(TestCategories.Unit)]
        [ExpectedException(typeof(ArgumentNullException))]
        public void ConvertFiles_WhenSaveLocationIsNull_ThrowsException()
        {
            sut = CreateValidFileConverter();

            sut.ConvertFiles(fakeFilesToConvert, fakeResolutions, null);
        }

        [TestMethod]
        [TestCategory(TestCategories.Unit)]
        [ExpectedException(typeof(ArgumentException))]
        public void ConvertFiles_WhenSaveLocationIsEmpty_ThrowsException()
        {
            sut = CreateValidFileConverter();

            sut.ConvertFiles(fakeFilesToConvert, fakeResolutions, string.Empty);
        }

        [TestMethod]
        [TestCategory(TestCategories.Unit)]
        public void ConvertFiles_WhenSaveLocationIsDefault_AddsFileConverterDirectory()
        {
            //Arrange
            DateTime dateTimeNow = new DateTime(2020, 6, 14, 1, 2, 3);
            string expectedSaveLocation = fakeSaveLocation + $"\\FileConverter{dateTimeNow:yyyyMMddhhmmss}";

            mockDateTimeProvider.Setup(x => x.Now).Returns(dateTimeNow);

            sut = CreateValidFileConverter();

            //Act
            sut.ConvertFiles(fakeFilesToConvert, fakeResolutions, fakeSaveLocation);

            //Assert
            mockFileProcessor.Verify(x =>
                x.ConvertSVGToPNG(It.IsAny<List<string>>(), It.IsAny<List<ImageSize>>(), expectedSaveLocation));
        }

        [TestMethod]
        [TestCategory(TestCategories.Unit)]
        public void ConvertFiles_WhenSaveLocationIsNotDefault_UsesVerbatim()
        {
            //Arrange
            string expectedSaveLocation = "SomeOtherSaveLocation";

            sut = CreateValidFileConverter();

            //Act
            sut.ConvertFiles(fakeFilesToConvert, fakeResolutions, expectedSaveLocation);

            //Assert
            mockFileProcessor.Verify(x =>
                x.ConvertSVGToPNG(It.IsAny<List<string>>(), It.IsAny<List<ImageSize>>(), expectedSaveLocation));
        }

        [TestMethod]
        [TestCategory(TestCategories.Unit)]
        public void ConvertFiles_WhenResolutionTransformed_GetsImageSizeCorrectly()
        {
            //Arrange
            string expectedSaveLocation = "SomeOtherSaveLocation";

            sut = CreateValidFileConverter();

            //Act
            sut.ConvertFiles(fakeFilesToConvert, fakeResolutions, expectedSaveLocation);

            //Assert
            mockFileProcessor.Verify(x =>
                x.ConvertSVGToPNG(It.IsAny<List<string>>(),
                    It.Is<List<ImageSize>>(list => list.FirstOrDefault().Equals(fakeResolutions.FirstOrDefault().ConvertToImageSize())),
                    It.IsAny<string>()));
        }

        [TestMethod]
        [TestCategory(TestCategories.Unit)]
        public void ConvertFiles_WhenCalled_PassesInUnalteredFilesToConvert()
        {
            //Arrange
            sut = CreateValidFileConverter();

            //Act
            sut.ConvertFiles(fakeFilesToConvert, fakeResolutions, fakeSaveLocation);

            //Assert
            mockFileProcessor.Verify(x =>
                x.ConvertSVGToPNG(fakeFilesToConvert,
                    It.IsAny<List<ImageSize>>(),
                    It.IsAny<string>()));
        }








        #endregion ConvertFiles Tests

        #region AddSuppliedResolution Tests

        [TestMethod]
        [TestCategory(TestCategories.Unit)]
        [ExpectedException(typeof(NotImplementedException))]
        public void AddSuppliedResolution_WhenCalled_ThrowsException()
        {
            sut = CreateValidFileConverter();

            sut.AddSuppliedResolution(new Resolution(1,2,3));
        }

        #endregion AddSuppliedResolution Tests

        #region Private Members

        private FileConverter CreateValidFileConverter()
        {
            return new FileConverter(mockFileProcessor.Object, mockDateTimeProvider.Object, fakeResolutions, fakeSaveLocation);
        }

        #endregion Private Members
    }
}
