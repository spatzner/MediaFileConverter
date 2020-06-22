using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using UnitTests.TestUtilities;

namespace UnitTests.Core
{
    [TestClass]
    public class AssertArgumentTests
    {

        #region IsNotNull_Object Tests

        [TestMethod]
        [TestCategory(TestCategories.Unit)]
        public void IsNotNull_Object_WhenObjectIsNull_ThrowsException()
        {
            //Arrange
            object argument = null;
            string argumentName = "0AA69E84-F022-4B6A-AE13-4B69719E4C89";

            try
            {
                //Act
                AssertArgument.IsNotNull(argumentName, argument);
            }
            catch (Exception ex)
            {
                //Assert
                Assert.IsInstanceOfType(ex, typeof(ArgumentNullException));
                Assert.IsTrue(ex.Message.Contains(argumentName));
                return;
            }

            FailOnNoException();
        }

        [TestMethod]
        [TestCategory(TestCategories.Unit)]
        public void IsNotNull_Object_WhenObjectIsNotNull_DoesNothing()
        {
            //Arrange
            object argument = new object();

            //Act
            AssertArgument.IsNotNull(nameof(argument), argument);
        }

        #endregion IsNotNull_Object Tests

        #region IsNotNullOrEmpty_List Tests

        [TestMethod]
        [TestCategory(TestCategories.Unit)]
        public void IsNotNullOrEmpty_List_WhenListIsNull_ThrowsException()
        {
            //Arrange
            List<object> argument = null;
            string argumentName = "0AA69E84-F022-4B6A-AE13-4B69719E4C89";

            try
            {
                //Act
                AssertArgument.IsNotNullOrEmpty(argumentName, argument);
            }
            catch (Exception ex)
            {
                //Assert
                Assert.IsInstanceOfType(ex, typeof(ArgumentNullException));
                Assert.IsTrue(ex.Message.Contains(argumentName));
                return;
            }

            FailOnNoException();
        }

        [TestMethod]
        [TestCategory(TestCategories.Unit)]
        public void IsNotNullOrEmpty_List_WhenListIsEmpty_ThrowsException()
        {
            //Arrange
            var argument = new List<object>();
            string expectedMessage = GetArgumentIsEmptyExceptionMessage(nameof(argument));

            try
            {
                //Act
                AssertArgument.IsNotNullOrEmpty(nameof(argument), argument);
            }
            catch (Exception ex)
            {
                //Assert
                Assert.IsInstanceOfType(ex, typeof(ArgumentException));
                Assert.AreEqual(expectedMessage, ex.Message);
                return;
            }

            FailOnNoException();
        }

        [TestMethod]
        [TestCategory(TestCategories.Unit)]
        public void IsNotNullOrEmpty_List_WhenListHasEntries_DoesNothing()
        {
            //Arrange
            var argument = new List<object> {new object()};

            //Act
            AssertArgument.IsNotNullOrEmpty(nameof(argument), argument);
        }

        #endregion IsNotNullOrEmpty_List Tests

        #region IsNotNullOrEmpty_String Tests


        [TestMethod]
        [TestCategory(TestCategories.Unit)]
        public void IsNotNullOrEmpty_String_WhenListIsNull_ThrowsException()
        {
            //Arrange
            string argument = null;
            string argumentName = "0AA69E84-F022-4B6A-AE13-4B69719E4C89";

            try
            {
                //Act
                AssertArgument.IsNotNullOrEmpty(argumentName, argument);
            }
            catch (Exception ex)
            {
                //Assert
                Assert.IsInstanceOfType(ex, typeof(ArgumentNullException));
                Assert.IsTrue(ex.Message.Contains(argumentName));
                return;
            }

            FailOnNoException();
        }

        [TestMethod]
        [TestCategory(TestCategories.Unit)]
        public void IsNotNullOrEmpty_string_WhenListIsEmpty_ThrowsException()
        {
            //Arrange
            string argument = string.Empty;
            string expectedMessage = GetArgumentIsEmptyExceptionMessage(nameof(argument));

            try
            {
                //Act
                AssertArgument.IsNotNullOrEmpty(nameof(argument), argument);
            }
            catch (Exception ex)
            {
                //Assert
                Assert.IsInstanceOfType(ex, typeof(ArgumentException));
                Assert.AreEqual(expectedMessage, ex.Message);
                return;
            }

            FailOnNoException();
        }

        [TestMethod]
        [TestCategory(TestCategories.Unit)]
        public void IsNotNullOrEmpty_String_WhenListHasEntries_DoesNothing()
        {
            //Arrange
            string argument = "Non-empty string";

            //Act
            AssertArgument.IsNotNullOrEmpty(nameof(argument), argument);
        }

        #endregion IsNotNullOrEmpty_String Tests

        #region IsPositive_Float Tests

        [TestMethod]
        [TestCategory(TestCategories.Unit)]
        public void IsPositive_Float_WhenNegative_ThrowsException()
        {
            //Arrange
            float argument = -1f;
            string argumentName = "0AA69E84-F022-4B6A-AE13-4B69719E4C89";
            string expectedMessage = GetArgumentMustBePositiveExceptionMessage(argumentName);

            try
            {
                //Act
                AssertArgument.IsPositive(argumentName, argument);
            }
            catch (Exception ex)
            {
                //Assert
                Assert.IsInstanceOfType(ex, typeof(ArgumentException));
                Assert.AreEqual(expectedMessage, ex.Message);
                return;
            }

            FailOnNoException();
        }

        [TestMethod]
        [TestCategory(TestCategories.Unit)]
        public void IsPositive_Float_WhenZero_ThrowsException()
        {
            //Arrange
            float argument = 0f;
            string argumentName = "0AA69E84-F022-4B6A-AE13-4B69719E4C89";
            string expectedMessage = GetArgumentMustBePositiveExceptionMessage(argumentName);

            try
            {
                //Act
                AssertArgument.IsPositive(argumentName, argument);
            }
            catch (Exception ex)
            {
                //Assert
                Assert.IsInstanceOfType(ex, typeof(ArgumentException));
                Assert.AreEqual(expectedMessage, ex.Message);
                return;
            }

            FailOnNoException();
        }

        [TestMethod]
        [TestCategory(TestCategories.Unit)]
        public void IsPositive_Float_WhenPositive_DoesNothing()
        {
            //Arrange
            float argument = 1f;

            //Act
            AssertArgument.IsPositive(nameof(argument), argument);
        }


        #endregion IsPositive_Float Tests

        #region IsPositive_Int Tests

        [TestMethod]
        [TestCategory(TestCategories.Unit)]
        public void IsPositive_Int_WhenNegative_ThrowsException()
        {
            //Arrange
            int argument = -1;
            string argumentName = "0AA69E84-F022-4B6A-AE13-4B69719E4C89";
            string expectedMessage = GetArgumentMustBePositiveExceptionMessage(argumentName);

            try
            {
                //Act
                AssertArgument.IsPositive(argumentName, argument);
            }
            catch (Exception ex)
            {
                //Assert
                Assert.IsInstanceOfType(ex, typeof(ArgumentException));
                Assert.AreEqual(expectedMessage, ex.Message);
                return;
            }

            FailOnNoException();
        }

        [TestMethod]
        [TestCategory(TestCategories.Unit)]
        public void IsPositive_Int_WhenZero_ThrowsException()
        {
            //Arrange
            int argument = 0;
            string argumentName = "0AA69E84-F022-4B6A-AE13-4B69719E4C89";
            string expectedMessage = GetArgumentMustBePositiveExceptionMessage(argumentName);

            try
            {
                //Act
                AssertArgument.IsPositive(argumentName, argument);
            }
            catch (Exception ex)
            {
                //Assert
                Assert.IsInstanceOfType(ex, typeof(ArgumentException));
                Assert.AreEqual(expectedMessage, ex.Message);
                return;
            }

            FailOnNoException();
        }

        [TestMethod]
        [TestCategory(TestCategories.Unit)]
        public void IsPositive_Int_WhenPositive_DoesNothing()
        {
            //Arrange
            int argument = 1;

            //Act
            AssertArgument.IsPositive(nameof(argument), argument);
        }



        #endregion IsPositive_Int Tests

        #region Private Methods

        private void FailOnNoException()
        {
            Assert.Fail("expected exception to be thrown");
        }

        private string GetArgumentIsEmptyExceptionMessage(string argumentName)
        {
            return string.Format(FakeAssertArgument.GetArgumentIsEmptyExceptionMessageFormat(), argumentName);
        }

        private string GetArgumentMustBePositiveExceptionMessage(string argumentName)
        {
            return string.Format(FakeAssertArgument.GetArgumentMustBePositiveExceptionMessageFormat(), argumentName);
        }

        protected class FakeAssertArgument : AssertArgument
        {

            public static string GetArgumentIsEmptyExceptionMessageFormat()
            {
                return argumentIsEmptyExceptionMessageFormat;
            }
            public static string GetArgumentMustBePositiveExceptionMessageFormat()
            {
                return argumentMustBePositiveExceptionMessageFormat;
            }
        }

        #endregion Private Methods
    }

}
