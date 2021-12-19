using System;

namespace PayboxHelper
{
    /// <summary>
    /// Paybox exception. Will be thrown when a config is missing or a verification failed.
    /// </summary>
    [Serializable]
    public class PayboxException : Exception
    {
#pragma warning disable CS1591
        public PayboxException() : base() { }
        public PayboxException(string message) : base(message) { }
        public PayboxException(string message, Exception inner) : base(message, inner) { }

        protected PayboxException(System.Runtime.Serialization.SerializationInfo info,
            System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
#pragma warning restore CS1591
    }
}