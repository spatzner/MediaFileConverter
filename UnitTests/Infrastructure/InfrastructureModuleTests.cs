using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Applications;
using Domain;
using Infrastructure;
using Infrastructure.Providers;
using Infrastructure.Wrappers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Ninject;
using UnitTests.TestUtilities;

namespace UnitTests.Infrastructure
{
    [TestClass]
    public class InfrastructureModuleTests
    {
        private static IKernel _kernel;

        [ClassInitialize]
        public static void ClassInitialize(TestContext _)
        {
            _kernel = new StandardKernel
            (
                new InfrastructureModule()
            );
        }

        [TestMethod]
        [TestCategory(TestCategories.Integration)]
        public void Kernel_WhenCalled_ReturnsInstanceOfSVGWrapper()
        {
            var result = _kernel.Get<ISVGWrapper>();

            Assert.IsInstanceOfType(result, typeof(SVGWrapper));
        }

        [TestMethod]
        [TestCategory(TestCategories.Integration)]
        public void Kernel_WhenCalled_ReturnsInstanceOfDateTimeProvider()
        {
            var result = _kernel.Get<IDateTimeProvider>();

            Assert.IsInstanceOfType(result, typeof(DateTimeProvider));
        }

        [TestMethod]
        [TestCategory(TestCategories.Integration)]
        public void Kernel_WhenCalled_ReturnsInstanceOfFileSystemProvider()
        {
            var result = _kernel.Get<IFileSystemProvider>();

            Assert.IsInstanceOfType(result, typeof(FileSystemProvider));
        }

        [TestMethod]
        [TestCategory(TestCategories.Integration)]
        public void Kernel_WhenCalled_ReturnsInstanceOfBitmapWrapper()
        {
            var result = _kernel.Get<IBitmapWrapper>();

            Assert.IsInstanceOfType(result, typeof(BitmapWrapper));
        }
    }
}
