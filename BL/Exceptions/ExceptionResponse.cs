namespace BL.DTO
{
    /// <summary>
    /// Модель для десериализации исключения, полученного от сервера.
    /// </summary>
    public class ExceptionResponse
    {
        /// <summary>
        /// Сообщение об ошибке.
        /// </summary>
        public string ExceptionMessage { get; set; }

        /// <summary>
        /// Тип исключения.
        /// </summary>
        public string ExceptionType { get; set; }

        /// <summary>
        /// Заголовок исключения.
        /// </summary>
        public string Message { get; set; }

        /// <summary>
        /// Трассировка стека.
        /// </summary>
        public string StackTrace { get; set; }
    }
}