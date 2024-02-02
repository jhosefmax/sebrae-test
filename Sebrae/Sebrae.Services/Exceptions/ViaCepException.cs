using System.Runtime.Serialization;

namespace Sebrae.Services.Exceptions
{
    /// <summary>
    /// ViaCep exception
    /// </summary>
    [Serializable]
    public class ViaCepException : Exception
    {
        public ViaCepException()
        {
        }

        public ViaCepException(string? message)
            : base(message)
        {
        }

        public ViaCepException(string? message, Exception? innerException)
            : base(message, innerException)
        {
        }

        protected ViaCepException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }
    }
}
