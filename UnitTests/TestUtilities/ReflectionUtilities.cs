using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTests.TestUtilities
{
    public static class ReflectionUtilities
    {

        public static T GetFieldValue<T>(object source, string fieldName)
        {
            return (T)GetFieldReference(source.GetType(), fieldName).GetValue(source);
        }

        public static void SetFieldValue<T>(object source, string fieldName, object value)
        {
            GetFieldReference(typeof(T), fieldName).SetValue(source, value);
        }

        public static T GetPropertyValue<T>(object source, string fieldName)
        {
            return (T)GetPropertyReference(source.GetType(), fieldName).GetValue(source);
        }

        public static void SetPropertyValue(object source, string fieldName, object newValue)
        {
            PropertyInfo property = GetPropertyReference(source.GetType(), fieldName);
            property.SetValue(source, newValue);
        }

        public static dynamic GetConstantFieldValue<T>(T source, string fieldName)
        {
            return GetFieldReference(source.GetType(), fieldName).GetValue(source);
        }

        public static T2 ExecutePrivateMethod<T1, T2>(T1 instance, string methodName, object[] parameters)
        {
            MethodInfo dynMethod = typeof(T1).GetMethod(methodName,
                BindingFlags.NonPublic |
                BindingFlags.Instance |
                BindingFlags.Static);

            if (dynMethod != null) 
                return (T2) dynMethod.Invoke(instance, parameters);

            List<object> paramList = parameters.ToList();
            string paramString = string.Join(Environment.NewLine, paramList.Select(x => $"Value:\"{x}\" Type: {x.GetType().FullName}"));

            throw new ArgumentException(
                $"Could not find a private, static or instance method named {methodName} in type {typeof(T1).FullName} with the following parameters: {paramString}");

        }

        public static void AssertObjectFieldsAreEqual<T>(T expected, T actual)
        {
            IEnumerable<string> classProperties = expected.GetType().GetProperties().Select(x => x.Name);

            foreach (string classProperty in classProperties)
            {
                // ReSharper disable PossibleNullReferenceException - we want a null reference exception to cause the test to fail if it cannot find an expected property
                var expectedValue = expected.GetType().GetProperty(classProperty).GetValue(expected, null);
                var actualValue = actual.GetType().GetProperty(classProperty).GetValue(actual, null);
                // ReSharper restore PossibleNullReferenceException

                Assert.AreEqual(expectedValue, actualValue);
            }
        }

        private static FieldInfo GetFieldReference(Type targetType, string fieldName)
        {
            FieldInfo field = targetType.GetField(fieldName,
                BindingFlags.Public |
                BindingFlags.NonPublic |
                BindingFlags.Instance |
                BindingFlags.Static);

            if (field == null && targetType.BaseType != null)
            {
                return GetFieldReference(targetType.BaseType, fieldName);
            }

            return field;
        }

        private static PropertyInfo GetPropertyReference(Type targetType, string fieldName)
        {
            PropertyInfo property = targetType.GetProperty(fieldName,
                BindingFlags.Public |
                BindingFlags.NonPublic |
                BindingFlags.Instance |
                BindingFlags.Static);

            if (property == null && targetType.BaseType != null)
            {
                return GetPropertyReference(targetType.BaseType, fieldName);
            }

            return property;
        }

    }
}
