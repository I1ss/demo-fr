namespace Client.Rests.Interfaces
{
    using System;
    using System.Net;
    using System.Net.Http;
    using System.Threading;
    using System.Threading.Tasks;

    using BL.DTO;
    using BL.Exceptions;

    using Newtonsoft.Json;

    using Polly;
    using Polly.Retry;

    using Refit;

    /// <summary>
    /// Базовый класс для взаимодействия с апи.
    /// </summary>
    /// <typeparam name="T">Интерфейс апи-запросов.</typeparam>
    public abstract class BaseApi<T>
    {
        /// <summary>
        /// Rest сервис.
        /// </summary>
        protected readonly T RestService;

        /// <summary>
        /// Конструктор.
        /// </summary>
        protected BaseApi()
        {
            var client = new HttpClient
            {
                BaseAddress = new Uri("https://localhost:44363/api")
            };

            RestService = Refit.RestService.For<T>(client);
        }

        /// <summary>
        /// Произвести запрос.
        /// </summary>
        /// <typeparam name="TR">Тип ответа.</typeparam>
        /// <param name="loadingFunction">Функция для загрузки данных.</param>
        /// <param name="cancellationToken">Токен для отмены.</param>
        /// <returns>Объект типа Т.</returns>
        protected async Task<TR> MakeRequestAsync<TR>(Func<CancellationToken, Task<TR>> loadingFunction,
            CancellationToken cancellationToken = new CancellationToken())
        {
            try
            {
                var result = await WaitAndRetryAsync()
                    .ExecuteAsync(loadingFunction, cancellationToken)
                    .ConfigureAwait(false);
                return result;
            }
            catch (ApiException apiException)
            {
                var errorDto = JsonConvert.DeserializeObject<ErrorDto>(apiException.Content);
                throw new ApiRequestException(errorDto?.Message ?? apiException.Message, apiException, null);
            }
        }

        /// <summary>
        /// Получение настроенного объекта Policy.
        /// </summary>
        private static AsyncRetryPolicy WaitAndRetryAsync()
        {
            return Policy.Handle<WebException>().Or<HttpRequestException>()
                .WaitAndRetryAsync(3, i => TimeSpan.FromMilliseconds(3000),
                    (ex, span) =>
                        throw new Exception(
                            $"Неудачная попытка подключения: {ex.Message} {ex.InnerException?.Message}"));
        }
    }
}