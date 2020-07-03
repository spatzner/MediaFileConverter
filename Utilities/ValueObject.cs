using System;
using System.Collections.Generic;
using System.Reflection;

namespace Core
{
    //this is modified from a class from Jimmy Bogard
    //http://grabbagoft.blogspot.com/2007/06/generic-value-object-equality.html

    public abstract class ValueObject<T> : IEquatable<T>
        where T : ValueObject<T>
    {
        public override bool Equals(object obj)
        {
            return Equals(obj as T);
        }

        public virtual bool Equals(T other)
        {
            if (other is null)
                return false;

            Type t = GetType();
            Type otherType = other.GetType();

            IEnumerable<FieldInfo> fields = GetFields(t);

            foreach (FieldInfo field in fields)
            {
                object value1 = field.GetValue(other);
                object value2 = field.GetValue(this);

                if (value1 is null)
                {
                    if (!(value2 is null))
                        return false;
                }
                else if (!value1.Equals(value2))
                    return false;
            }

            return true;
        }

        public override int GetHashCode()
        {
            IEnumerable<FieldInfo> fields = GetAllFields();

            int startValue = 17;
            int multiplier = 59;

            int hashCode = startValue;

            foreach (FieldInfo field in fields)
            {
                object value = field.GetValue(this);

                if (!(value is null))
                    hashCode = hashCode * multiplier + value.GetHashCode();
            }

            return hashCode;
        }

        public static bool operator ==(ValueObject<T> x, ValueObject<T> y)
        {
            if (!(x is null)) 
                return x.Equals(y);
            return y is null;
        }

        public static bool operator !=(ValueObject<T> x, ValueObject<T> y)
        {
            return !(x == y);
        }

        private IEnumerable<FieldInfo> GetAllFields()
        {
            Type t = GetType();

            List<FieldInfo> fields = new List<FieldInfo>();

            while (!(t is null) && t != typeof(object))
            {
                fields.AddRange(GetFields(t));
                t = t.BaseType;
            }

            return fields;
        }

        private IEnumerable<FieldInfo> GetFields(Type t)
        {
            return t is null
                ? new FieldInfo[0]
                : t.GetFields(BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public);
        }


    }
}