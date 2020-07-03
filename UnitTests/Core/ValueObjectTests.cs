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
    public class ValueObjectTests
    {

        #region Equals Tests

        #region Null/Type Comparisons

        [TestMethod]
        [TestCategory(TestCategories.Unit)]
        public void Equals_WhenCompareObjectNull_ReturnsFalse()
        {
            //Arrange
            var sut = new FirstDescendantValueObject();

            //Act
            bool matches = sut.Equals(null);

            //Assert
            Assert.IsFalse(matches);
        }

        [TestMethod]
        [TestCategory(TestCategories.Unit)]
        public void Equals_WhenCompareObjectIsDifferentType_ReturnsFalse()
        {
            //Arrange
            var sut = new FirstDescendantValueObject();

            //Act
            bool matches = sut.Equals(new object());

            //Assert
            Assert.IsFalse(matches);
        }

        [TestMethod]
        [TestCategory(TestCategories.Unit)]
        public void Equals_WhenObjectsAreTheSameClass_ReturnsTrue()
        {
            //Arrange
            var sut = new FirstDescendantValueObject();

            //Act
            bool matches = sut.Equals(sut);

            //Assert
            Assert.IsTrue(matches);
        }

        #endregion Null/Type Comparisons

        #region First Descendant Tests

        [TestMethod]
        [TestCategory(TestCategories.Unit)]
        public void Equals_WhenFirstDescendantsHaveSameValues_ReturnsTrue()
        {
            //Arrange
            var sut = new FirstDescendantValueObject();

            var match = new FirstDescendantValueObject();


            //Act
            bool matches = sut.Equals(match);

            //Assert
            Assert.IsTrue(matches);
        }

        #region Public Struct Tests

        [TestMethod]
        [TestCategory(TestCategories.Unit)]
        public void Equals_WhenFirstDescendantsPublicStructSutIsNull_ReturnsFalse()
        {
            //Arrange
            var sut = new FirstDescendantValueObject
            {
                StructField = null
            };

            var match = new FirstDescendantValueObject();

            //Act
            bool matches = sut.Equals(match);

            //Assert
            Assert.IsFalse(matches);
        }

        [TestMethod]
        [TestCategory(TestCategories.Unit)]
        public void Equals_WhenFirstDescendantsPublicStructMatchIsNull_ReturnsFalse()
        {
            //Arrange
            var sut = new FirstDescendantValueObject();

            var match = new FirstDescendantValueObject
            {
                StructField = null
            };

            //Act
            bool matches = sut.Equals(match);

            //Assert
            Assert.IsFalse(matches);
        }

        [TestMethod]
        [TestCategory(TestCategories.Unit)]
        public void Equals_WhenFirstDescendantsPublicStructIsDifferent_ReturnsFalse()
        {
            //Arrange
            var sut = new FirstDescendantValueObject();

            var match = new FirstDescendantValueObject
            {
                StructField = "other string"
            };

            //Act
            bool matches = sut.Equals(match);

            //Assert
            Assert.IsFalse(matches);
        }

        #endregion Public Struct Tests

        #region Private Struct Tests

        [TestMethod]
        [TestCategory(TestCategories.Unit)]
        public void Equals_WhenFirstDescendantsPrivateStructSutIsNull_ReturnsFalse()
        {
            //Arrange
            var sut = new FirstDescendantValueObject();
            sut.SetPrivateStructFieldToNull();

            var match = new FirstDescendantValueObject();

            //Act
            bool matches = sut.Equals(match);

            //Assert
            Assert.IsFalse(matches);
        }

        [TestMethod]
        [TestCategory(TestCategories.Unit)]
        public void Equals_WhenFirstDescendantsPrivateStructMatchIsNull_ReturnsFalse()
        {
            //Arrange
            var sut = new FirstDescendantValueObject();

            var match = new FirstDescendantValueObject();
            match.SetPrivateStructFieldToNull();

            //Act
            bool matches = sut.Equals(match);

            //Assert
            Assert.IsFalse(matches);
        }

        [TestMethod]
        [TestCategory(TestCategories.Unit)]
        public void Equals_WhenFirstDescendantsPrivateStructIsDifferent_ReturnsFalse()
        {
            //Arrange
            var sut = new FirstDescendantValueObject();

            var match = new FirstDescendantValueObject();
            match.SetPrivateStructFieldToNotMatch();

            //Act
            bool matches = sut.Equals(match);

            //Assert
            Assert.IsFalse(matches);
        }

        #endregion Private Struct Tests

        #region Public Class Tests

        [TestMethod]
        [TestCategory(TestCategories.Unit)]
        public void Equals_WhenFirstDescendantPublicClassSutIsNull_ReturnsFalse()
        {
            //Arrange
            var sut = new FirstDescendantValueObject
            {
                StructField = null
            };

            var match = new FirstDescendantValueObject();

            //Act
            bool matches = sut.Equals(match);

            //Assert
            Assert.IsFalse(matches);
        }

        [TestMethod]
        [TestCategory(TestCategories.Unit)]
        public void Equals_WhenFirstDescendantPublicClassMatchIsNull_ReturnsFalse()
        {
            //Arrange
            var sut = new FirstDescendantValueObject();

            var match = new FirstDescendantValueObject
            {
                StructField = null
            };

            //Act
            bool matches = sut.Equals(match);

            //Assert
            Assert.IsFalse(matches);
        }

        [TestMethod]
        [TestCategory(TestCategories.Unit)]
        public void Equals_WhenFirstDescendantsPublicClassIsDifferent_ReturnsFalse()
        {
            //Arrange
            var sut = new FirstDescendantValueObject();

            var match = new FirstDescendantValueObject
            {
                ClassField = new Tuple<int>(2)
            };

            //Act
            bool matches = sut.Equals(match);

            //Assert
            Assert.IsFalse(matches);
        }

        #endregion Public Class Tests

        #region Private Class Tests

        [TestMethod]
        [TestCategory(TestCategories.Unit)]
        public void Equals_WhenFirstDescendantsPrivateClassSutIsNull_ReturnsFalse()
        {
            //Arrange
            var sut = new FirstDescendantValueObject();
            sut.SetPrivateClassFieldToNull();

            var match = new FirstDescendantValueObject();

            //Act
            bool matches = sut.Equals(match);

            //Assert
            Assert.IsFalse(matches);
        }

        [TestMethod]
        [TestCategory(TestCategories.Unit)]
        public void Equals_WhenFirstDescendantsPrivateClassMatchIsNull_ReturnsFalse()
        {
            //Arrange
            var sut = new FirstDescendantValueObject();

            var match = new FirstDescendantValueObject();
            match.SetPrivateClassFieldToNull();

            //Act
            bool matches = sut.Equals(match);

            //Assert
            Assert.IsFalse(matches);
        }

        [TestMethod]
        [TestCategory(TestCategories.Unit)]
        public void Equals_WhenFirstDescendantsPrivateClassIsDifferent_ReturnsFalse()
        {
            //Arrange
            var sut = new FirstDescendantValueObject();

            var match = new FirstDescendantValueObject();
            match.SetPrivateClassFieldToNotMatch();

            //Act
            bool matches = sut.Equals(match);

            //Assert
            Assert.IsFalse(matches);
        }

        #endregion Private Class Tests

        #endregion First Descendant Tests

        #region Second Descendant Tests

        [TestMethod]
        [TestCategory(TestCategories.Unit)]
        public void Equals_WhenSecondDescendantsHaveSameValues_ReturnsTrue()
        {
            //Arrange
            var sut = new SecondDescendentValueObject();

            var match = new SecondDescendentValueObject();

            //Act
            bool matches = sut.Equals(match);

            //Assert
            Assert.IsTrue(matches);
        }

        [TestMethod]
        [TestCategory(TestCategories.Unit)]
        public void Equals_WhenSecondDescendantsHasFirstDescendantMismatchValue_ReturnsFalse()
        {
            //Arrange
            var sut = new SecondDescendentValueObject();

            var match = new SecondDescendentValueObject();
            match.SetPrivateClassFieldToNotMatch();

            //Act
            bool matches = sut.Equals(match);

            //Assert
            Assert.IsTrue(matches);
        }

        [TestMethod]
        [TestCategory(TestCategories.Unit)]
        public void Equals_WhenSecondDescendantsHasMismatchValue_ReturnsFalse()
        {
            //Arrange
            var sut = new SecondDescendentValueObject();

            var match = new SecondDescendentValueObject
            {
                Field = !sut.Field
            };

            //Act
            bool matches = sut.Equals(match);

            //Assert
            Assert.IsFalse(matches);
        }

        #endregion Second Descendant Tests

        #endregion Equals Tests

        #region GetHashCode Tests

        [TestMethod]
        [TestCategory(TestCategories.Unit)]
        public void GetHasCode_ObjectsAreTheSameReference_HashMatches()
        {
            //Arrange
            var sut = new FirstDescendantValueObject();
            var sameObject = sut;

            //Act
            int value1 = sut.GetHashCode();
            int value2 = sameObject.GetHashCode();

            //Assert
            Assert.AreEqual(value1, value2);
        }

        [TestMethod]
        [TestCategory(TestCategories.Unit)]
        public void GetHasCode_ObjectsHaveSameValues_HashMatches()
        {
            //Arrange
            var sut = new FirstDescendantValueObject();
            var sameValues = new FirstDescendantValueObject();

            //Act
            int value1 = sut.GetHashCode();
            int value2 = sameValues.GetHashCode();

            //Assert
            Assert.AreEqual(value1, value2);
        }

        [TestMethod]
        [TestCategory(TestCategories.Unit)]
        public void GetHasCode_FirstDescendantPublicStructIsDifferent_HashAreNotEqual()
        {
            //Arrange
            var sut = new FirstDescendantValueObject();
            var nonMatch = new FirstDescendantValueObject
            {
                StructField = "other string"
            };

            //Act
            int value1 = sut.GetHashCode();
            int value2 = nonMatch.GetHashCode();

            //Assert
            Assert.AreNotEqual(value1, value2);
        }

        [TestMethod]
        [TestCategory(TestCategories.Unit)]
        public void GetHasCode_FirstDescendantPublicClassIsDifferent_HashAreNotEqual()
        {
            //Arrange
            var sut = new FirstDescendantValueObject();
            var nonMatch = new FirstDescendantValueObject
            {
                ClassField = new Tuple<int>(2)
            };

            //Act
            int value1 = sut.GetHashCode();
            int value2 = nonMatch.GetHashCode();

            //Assert
            Assert.AreNotEqual(value1, value2);
        }

        [TestMethod]
        [TestCategory(TestCategories.Unit)]
        public void GetHasCode_FirstDescendantPrivateStructIsDifferent_HashAreNotEqual()
        {
            //Arrange
            var sut = new FirstDescendantValueObject();
            var nonMatch = new FirstDescendantValueObject();
            nonMatch.SetPrivateStructFieldToNull();

            //Act
            int value1 = sut.GetHashCode();
            int value2 = nonMatch.GetHashCode();

            //Assert
            Assert.AreNotEqual(value1, value2);
        }

        [TestMethod]
        [TestCategory(TestCategories.Unit)]
        public void GetHasCode_FirstDescendantPrivateClassIsDifferent_HashAreNotEqual()
        {
            //Arrange
            var sut = new FirstDescendantValueObject();
            var nonMatch = new FirstDescendantValueObject();
            nonMatch.SetPrivateClassFieldToNull();

            //Act
            int value1 = sut.GetHashCode();
            int value2 = nonMatch.GetHashCode();

            //Assert
            Assert.AreNotEqual(value1, value2);
        }


        #endregion GetHashCode Tests

        private class FirstDescendantValueObject : ValueObject<FirstDescendantValueObject>
        {
            public string StructField { get; set; } = "string";
            public Tuple<int> ClassField { get; set; } = new Tuple<int>(1);
            private string PrivateStructField { get; set; } = "private string";
            private Tuple<int> PrivateClassField { get; set; } = new Tuple<int>(2);

            public void SetPrivateStructFieldToNotMatch()
            {
                PrivateStructField = "other private string";
            }
            public void SetPrivateStructFieldToNull()
            {
                PrivateStructField = null;
            }

            public void SetPrivateClassFieldToNotMatch()
            {
                PrivateClassField = new Tuple<int>(3);
            }

            public void SetPrivateClassFieldToNull()
            {
                PrivateClassField = null;
            }
        }

        private class SecondDescendentValueObject : FirstDescendantValueObject
        {
            public bool Field { get; set; } = true;
        }


    }

}
