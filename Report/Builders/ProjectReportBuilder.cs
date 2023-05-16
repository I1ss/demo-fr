namespace Report.Builders;

using BL.DTO;

using FastReport.Export.OoXML;

using System.Collections.Generic;

using Report.Services;
using Report.Models;

/// <summary>
/// Сервис для создания большого отчета "Сводный отчет по проекту", в карточке проекта.
/// </summary>
internal class ProjectReportBuilder : BaseFastReportService
{
    /// <summary>
    /// ДТО - с данными для построения отчета "Сводный отчет по проекту".
    /// </summary>
    private readonly ProjectReportBuildDto _projectReportBuildDto;

    /// <summary>
    /// Итоговая модель отчета "Сводный отчет по проекту", которая будет парсится FastReport-ом.
    /// </summary>
    private readonly ProjectReportModel _projectReportModelFastReportModel;

    /// <summary>
    /// Сервис для создания большого отчета "Сводный отчет по проекту", в карточке проекта.
    /// </summary>
    /// <param name="projectReportBuildDto"> ДТО - с данными для построения отчета "Сводный отчет по проекту". </param>
    public ProjectReportBuilder(ProjectReportBuildDto projectReportBuildDto)
    {
        _projectReportBuildDto = projectReportBuildDto;
        _projectReportModelFastReportModel = new ProjectReportModel();
    }

    /// <summary>
    /// Построить отчет.
    /// </summary>
    /// <returns> Контент с отчетом, и сообщения. </returns>
    public byte[] Build()
    {
        // Наполнение модели FastReport.
        _projectReportModelFastReportModel.ActivityTotals = _projectReportBuildDto.ActivityTotals;
        _projectReportModelFastReportModel.ActualWork = _projectReportBuildDto.ActualWork;
        _projectReportModelFastReportModel.ProjectManagerName = _projectReportBuildDto.ProjectManagerName;

        // Построение отчета.
        var projectReportFastReports = new List<ProjectReportModel> { _projectReportModelFastReportModel };
        using var excelProjectReportStream = CreateExcelReportStream(
            projectReportFastReports, "ProjectReport", new Excel2007Export());

        return excelProjectReportStream.ToArray();
    }
}