namespace Client.Commands
{
    using Client.Rests.Implementations;
    using Client.Rests.Interfaces;
    using System;
    using System.IO;
    using System.Net.Http;
    using System.Windows.Input;

    using Client.Utils;

    /// <summary>
    /// Открыть план-факт.
    /// </summary>
    public class CreatePlanFactCommand : ICommand
    {
        /// <summary>
        /// Rest отчетов.
        /// </summary>
        private readonly IReportRest _reportRest;

        /// <summary>
        /// Открыть план-факт.
        /// </summary>
        public CreatePlanFactCommand()
        {
            _reportRest = new ReportRest();
        }

        /// <inheritdoc />
        public bool CanExecute(object? parameter)
        {
            return true;
        }

        /// <summary>
        /// Осуществляет переход на вкладку с план-фактом.
        /// </summary>
        /// <param name="projectCardVM"> ВМ вкладки карточки проекта. </param>
        public async void Execute(object? projectCardVM)
        {
            var fact = await _reportRest.ExportPlanFact(); ;
            var path = ExcelFileDialogsUtils.SaveExcelFile("Сохранить файл план-факта.");

            using (var fileStream = File.Create(path))
            {
                await fileStream.WriteAsync(fact, 0, fact.Length);
            }
        }

        public event EventHandler? CanExecuteChanged;
    }
}
