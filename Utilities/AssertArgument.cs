using System;
using System.Collections.Generic;
using System.Linq;

namespace Core
{

    public class AssertArgument
    {

        public static void IsNotNull(string argumentName, object argumentValue)
        {
            if (argumentValue == null) 
                throw new ArgumentNullException(argumentName);
        }

        public static void IsNotNullOrEmpty<T>(string argumentName, List<T> argumentValue)
        {
            IsNotNull(argumentName, argumentValue);

            if(!argumentValue.Any())
                throw new ArgumentException(string.Format(argumentIsEmptyExceptionMessageFormat, argumentName));
        }

        public static void IsNotNullOrEmpty(string argumentName, string argumentValue)
        {
            IsNotNull(argumentName, argumentValue);

            if(string.IsNullOrEmpty(argumentValue))
                throw new ArgumentException(string.Format(argumentIsEmptyExceptionMessageFormat, argumentName));
        }

        public static void IsPositive(string argumentName, float argumentValue)
        {
            if(argumentValue <= 0)
                ThrowPositiveNumberException(argumentName);
        }

        public static void IsPositive(string argumentName, int argumentValue)
        {
            if (argumentValue <= 0)
                ThrowPositiveNumberException(argumentName);
        }

        private static void ThrowPositiveNumberException(string argumentName)
        {
            throw new ArgumentException(string.Format(argumentMustBePositiveExceptionMessageFormat, argumentName));
        }

        protected static readonly string argumentIsEmptyExceptionMessageFormat = "{0} cannot be empty";
        protected static readonly string argumentMustBePositiveExceptionMessageFormat = "{0} must be positive";
    }
    }
