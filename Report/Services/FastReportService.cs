namespace Report.Services
{
    using BL.DTO;
    using BL.Interfaces;

    using Report.Builders;

    /// <summary>
    /// Сервис для работы с отчетами Fast Report.
    /// </summary>
    public class FastReportService : BaseFastReportService, IReportService
    {
        /// <inheritdoc />
        public byte[] ExportPlanFact(ProjectReportBuildDto projectReportBuildDto)
        {
            var planFactService = new ProjectReportBuilder(projectReportBuildDto);
            return planFactService.Build();
        }
    }
}