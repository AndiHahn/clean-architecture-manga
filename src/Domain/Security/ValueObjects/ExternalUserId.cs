// <copyright file="ExternalUserId.cs" company="Ivan Paulovich">
// Copyright © Ivan Paulovich. All rights reserved.
// </copyright>

namespace Domain.Security.ValueObjects
{
    /// <summary>
    /// ExternalUserId <see href="https://github.com/ivanpaulovich/clean-architecture-manga/wiki/Domain-Driven-Design-Patterns#entity">Entity Design Pattern</see>.
    /// </summary>
    public readonly struct ExternalUserId : System.IEquatable<ExternalUserId>
    {
        private readonly string text;

        /// <summary>
        /// Initializes a new instance of the <see cref="ExternalUserId"/> struct.
        /// </summary>
        /// <param name="text">External User Id.</param>
        public ExternalUserId(string text)
        {
            if (string.IsNullOrWhiteSpace(text))
            {
                throw new ExternalUserIdShouldNotBeEmptyException($"The '{nameof(text)}' field is required.");
            }

            this.text = text;
        }

        /// <summary>
        /// Converts into string.
        /// </summary>
        /// <returns>String.</returns>
        public override string ToString()
        {
            return this.text;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public override bool Equals(object obj)
        {
            if (obj is ExternalUserId externalUserIdObj)
            {
                return Equals(externalUserIdObj);
            }

            return false;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public override int GetHashCode()
        {
            return this.text.GetHashCode(System.StringComparison.OrdinalIgnoreCase);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        public static bool operator ==(ExternalUserId left, ExternalUserId right)
        {
            return left.Equals(right);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        public static bool operator !=(ExternalUserId left, ExternalUserId right)
        {
            return !(left == right);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="other"></param>
        /// <returns></returns>
        public bool Equals(ExternalUserId other)
        {
            return this.text == other.text;
        }
    }
}
