namespace Client.ViewModels
{
    using Client.Commands;

    /// <summary>
    /// Вью-модель отчёта.
    /// </summary>
    internal class ReportVM
    {
        /// <summary>
        /// Команда создания отчёта.
        /// </summary>
        public CreatePlanFactCommand CreatePlanFactCommand { get; set; }

        /// <summary>
        /// Вью-модель отчёта.
        /// </summary>
        public ReportVM()
        {
            CreatePlanFactCommand = new CreatePlanFactCommand();
        }
    }
}
