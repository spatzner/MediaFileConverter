using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Infrastructure.Providers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using UnitTests.TestUtilities;

namespace UnitTests.Infrastructure
{
    [TestClass]
    public class DateTimeProviderTests
    {
        private DateTimeProvider sut;

        [TestInitialize]
        public void TestInitialize()
        {
            sut = new DateTimeProvider();
        }

        [TestMethod]
        [TestCategory(TestCategories.Unit)]
        public void Now_WhenCalled_ReturnsDateTimeNow()
        {
            //Arrange
            DateTime expected = DateTime.Now;

            //Act
            DateTime result = sut.Now;

            Assert.IsTrue(result.Subtract(expected) < new TimeSpan(0,1,0));
        }

        [TestMethod]
        [TestCategory(TestCategories.Unit)]
        public void Today_WhenCalled_ReturnsDateTimeToday()
        {
            //Arrange
            DateTime expected = DateTime.Today;

            //Act
            DateTime result = sut.Today;

            Assert.IsTrue(result.Subtract(expected) < new TimeSpan(0, 1, 0));
        }
    }
}
