namespace BL.DTO
{
    /// <summary>
    /// ДТО ошибки.
    /// </summary>
    public class ErrorDto
    {
        /// <summary>
        /// Сообщение.
        /// </summary>
        public string Message { get; set; }

        /// <summary>
        /// Стэктрейс.
        /// </summary>
        public string Stacktrace { get; set; }
    }
}