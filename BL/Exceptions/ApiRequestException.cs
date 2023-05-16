namespace BL.Exceptions
{
    using System;
    using System.Runtime.Serialization;

    using BL.DTO;

    /// <summary>
    /// Исключения при получении ответа на запрос.
    /// </summary>
    [Serializable]
    public class ApiRequestException : Exception
    {
        /// <summary>
        /// Исключения при получении ответа на запрос.
        /// </summary>
        public ApiRequestException(string message, Exception innerException, ExceptionResponse exceptionResponse) :
            base(message, innerException)
        {
            ExceptionResponse = exceptionResponse;
        }

        /// <inheritdoc cref="ApiRequestException" />
        /// <param name="serializationInfo"> Информация о сериализации. </param>
        /// <param name="streamingContext"> Контекст сериализации. </param>
        protected ApiRequestException(SerializationInfo serializationInfo, StreamingContext streamingContext)
            : base(serializationInfo, streamingContext)
        {
        }

        /// <summary>
        /// Объект исключения полученного на запрос.
        /// </summary>
        public ExceptionResponse ExceptionResponse { get; }
    }
}