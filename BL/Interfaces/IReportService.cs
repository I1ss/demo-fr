namespace BL.Interfaces
{
    using BL.DTO;

    /// <summary>
    /// Интерфейс для экспорта отчётов.
    /// </summary>
    public interface IReportService
    {
        /// <summary>
        /// Экспортировать отчет план факт.
        /// </summary>
        /// <param name="projectReportBuildDto"> ДТО - с данными для построения отчета "Сводный отчет по проекту". </param>
        /// <returns> Контент с отчетом, и сообщения. </returns>
        byte[] ExportPlanFact(ProjectReportBuildDto projectReportBuildDto);
    }
}
