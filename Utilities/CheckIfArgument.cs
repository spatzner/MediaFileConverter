using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utilities
{

    public static class CheckIfArgument
    {
        public static void IsNull(string argumentName, object argumentValue)
        {
            if (argumentValue == null) 
                throw new ArgumentNullException($"{argumentName} cannot be null");
        }

        public static void IsNullOrEmpty<T>(string argumentName, List<T> argumentValue)
        {
            IsNull(argumentName, argumentValue);

            if(!argumentValue.Any())
                throw new ArgumentException($"{argumentName} must contain at least one element");
        }

        public static void IsNullOrEmpty(string argumentName, string argumentValue)
        {
            IsNull(argumentName, argumentValue);

            if(string.IsNullOrEmpty(argumentValue))
                throw new ArgumentException($"{argumentName} cannot be empty");
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
            throw new ArgumentException($"{argumentName} must be a positive number");
        }
    }
    }
