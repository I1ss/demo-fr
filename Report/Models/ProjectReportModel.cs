namespace Report.Models
{
    using BL.Models;

    /// <summary>
    /// Модель для отчёта.
    /// </summary>
    internal class ProjectReportModel
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
