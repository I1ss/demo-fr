namespace Client.Rests.Implementations
{
    using System.Threading.Tasks;

    using Client.Rests.Interfaces;

    /// <summary>
    /// Rest отчетов.
    /// </summary>
    public class ReportRest : BaseApi<IReportRest>, IReportRest
    {
        /// <inheritdoc />
        public Task<byte[]> ExportPlanFact()
        {
            return MakeRequestAsync(it => RestService.ExportPlanFact());
        }
    }
}