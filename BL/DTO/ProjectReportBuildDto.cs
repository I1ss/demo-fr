namespace BL.DTO
{
    using BL.Models;

    /// <summary>
    /// ДТО для отчёта.
    /// </summary>
    public class ProjectReportBuildDto
    {
        /// <summary>
        /// Деятельность.
        /// </summary>
        public ActivityTotals ActivityTotals { get; set; }

        /// <summary>
        /// Трудозатраты по проекту.
        /// </summary>
        public double ActualWork { get; set; }

        /// <summary>
        /// Тестовое имя.
        /// </summary>
        public string ProjectManagerName { get; set; }
    }
}
