namespace TestApp.Controllers
{
    using Microsoft.AspNetCore.Mvc;

    using System.Threading.Tasks;

    using BL.Interfaces;
    using BL.DTO;
    using BL.Models;

    /// <summary>
    /// Контроллер работы с отчетами.
    /// </summary>
    [Route("api/report")]
    public class ReportController : ControllerBase
    {
        /// <summary>
        /// Интерфейс для экспорта отчётов.
        /// </summary>
        private readonly IReportService _reportService;

        /// <summary>
        /// Контроллер работы с отчетами.
        /// </summary>
        /// <param name="reportService"> Интерфейс для экспорта отчётов. </param>
        public ReportController(IReportService reportService)
        {
            _reportService = reportService;
        }

        /// <summary>
        /// Экспорт план-факта.
        /// </summary>
        [Route("plan-fact")]
        [HttpGet]
        public async Task<IActionResult> ExportPlanFact()
        {
            var operationSystem = Environment.OSVersion.VersionString;
            var activityTotals = new ActivityTotals();
            var projectReportBuildDto = new ProjectReportBuildDto
            {
                ActivityTotals = activityTotals,
                ActualWork = 111,
                ProjectManagerName = operationSystem,
            };
            var planFactReport = _reportService.ExportPlanFact(projectReportBuildDto);

            return Ok(planFactReport);
        }
    }
}