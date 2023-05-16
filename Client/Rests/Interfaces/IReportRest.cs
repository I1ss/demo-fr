namespace Client.Rests.Interfaces
{
    using System.Threading.Tasks;

    using Refit;

    /// <summary>
    /// Rest отчетов.
    /// </summary>
    [Headers("Accept: application/json")]
    public interface IReportRest
    {
        /// <summary>
        /// Получение план-факта.
        /// </summary>
        /// <returns> План-факт. </returns>
        [Get("/report/plan-fact")]
        Task<byte[]> ExportPlanFact();
    }
}