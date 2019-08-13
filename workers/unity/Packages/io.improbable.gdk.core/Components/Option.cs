using System;
using System.Collections.Generic;

namespace Improbable.Gdk.Core
{
    /// <summary>
    ///     An implementation of Option which is compatible with Unity's ECS.
    /// </summary>
    /// <remarks>
    ///     This is required because bool is not blittable by default.
    /// </remarks>
    /// <typeparam name="T">The contained type in the Option.</typeparam>
    public readonly struct Option<T> : IEquatable<Option<T>>
    {
        public static readonly Option<T> Empty = new Option<T>();

        /// <summary>
        ///     True if the Option contains a value, false if not.
        /// </summary>
        public readonly bool HasValue;

        private readonly T value;

        /// <summary>
        ///     Returns the value contained inside the Option.
        /// </summary>
        /// <exception cref="EmptyOptionException">
        ///    Thrown if the Option is empty.
        /// </exception>
        public T Value
        {
            get
            {
                if (!HasValue)
                {
                    throw new EmptyOptionException("Called Value on empty Option.");
                }

                return value;
            }
        }

        /// <summary>
        ///     Constructor for an option.
        /// </summary>
        /// <param name="value">
        ///    The value to be contained in the option
        /// </param>
        public Option(T value)
        {
            HasValue = true;
            this.value = value;
        }

        /// <summary>
        ///    Attempts to get the value contained within the Option.
        /// </summary>
        /// <param name="outValue">
        ///     When this method returns, contains the value contained within the Option if the Option is non-empty,
        ///     otherwise the default value for the type of the outValue parameter.
        /// </param>
        /// <returns>
        ///     A bool indicating success.
        /// </returns>
        public bool TryGetValue(out T outValue)
        {
            outValue = value;
            return HasValue;
        }

        /// <summary>
        ///     Gets the value within the Option or the provided default value if the Option is empty.
        /// </summary>
        /// <param name="defaultValue">
        ///    The default value to return if the Option is empty.
        /// </param>
        /// <returns>
        ///     The value contained within the Option or the provided value.
        /// </returns>
        public T GetValueOrDefault(T defaultValue)
        {
            return HasValue ? value : defaultValue;
        }

        public override bool Equals(object other)
        {
            return other is Option<T> option && Equals(option);
        }

        public bool Equals(Option<T> other)
        {
            if (!HasValue && !other.HasValue)
            {
                return true;
            }

            if (HasValue && other.HasValue)
            {
                return value.Equals(other.value);
            }

            return false;
        }

        public static bool operator ==(Option<T> a, Option<T> b)
        {
            return a.Equals(b);
        }

        public static bool operator !=(Option<T> a, Option<T> b)
        {
            return !a.Equals(b);
        }

        public override int GetHashCode()
        {
            return HasValue ? value.GetHashCode() : 0;
        }

        public override string ToString()
        {
            return HasValue ? $"Option[{value.ToString()}]" : "Option.Empty";
        }

        public static implicit operator Option<T>(T value)
        {
            return new Option<T>(value);
        }

        public static implicit operator T(Option<T> option)
        {
            return option.Value;
        }
    }

    /// <summary>
    ///     Represents an error when an Option's contained value is attempted to be accessed when the option is empty.
    /// </summary>
    public class EmptyOptionException : Exception
    {
        public EmptyOptionException(string message)
            : base(message)
        {
        }
    }

    public static class LinqExtensions
    {
        public static IEnumerable<T> FilterOption<T>(this IEnumerable<Option<T>> enumerable)
        {
            foreach (var e in enumerable)
            {
                if (e.HasValue)
                {
                    yield return e.Value;
                }
            }
        }
    }
}
