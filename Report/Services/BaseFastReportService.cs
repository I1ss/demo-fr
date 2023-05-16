namespace Report.Services;

using System.Collections.Generic;
using System.IO;
using System.Reflection;

using FastReport;
using FastReport.Export;

/// <summary>
/// Базовый сервис для FastReport.
/// </summary>
public class BaseFastReportService
{
    /// <summary>
    /// Путь к исполняемой сборки.
    /// </summary>
    private readonly string _rootPath;

    /// <summary>
    /// Объект отчета.
    /// </summary>
    private Report _report;

    /// <summary>
    /// Базовый сервис для FastReport.
    /// </summary>
    public BaseFastReportService()
    {
        _report = new Report();
        _rootPath = GetFolderExecutingAssembly();
    }

    /// <summary>
    /// Создать поток excel-документа.
    /// </summary>
    /// <param name="model"> Модель с данными. </param>
    /// <param name="templateName"> Наименование файла шаблона. </param>
    /// <param name="exportBase"> Настройки экспорта. </param>
    /// <returns> Поток excel-документа. </returns>
    public MemoryStream CreateExcelReportStream<T>(IEnumerable<T> model, string templateName,
        ExportBase exportBase)
    {
        LoadTemplate(templateName);
        _report.Dictionary.Connections.Clear();
        _report.RegisterData(model, "Data");
        _report.Prepare();

        var stream = new MemoryStream();
        _report.Export(exportBase, stream);
        stream.Position = 0;

        return stream;
    }

    /// <summary>
    /// Загружает файл шаблона.
    /// </summary>
    /// <param name="templateName"> Имя файла шаблона без расширения. </param>
    private void LoadTemplate(string templateName)
    {
        var filePath = Path.Combine(_rootPath, "Assets", $"{templateName}.frx");

        if (!File.Exists(filePath))
            throw new FileNotFoundException($"Файл {filePath} не найден.");

        _report.Load(filePath);
    }

    /// <summary>
    /// Получить папку исполняемой сборки.
    /// </summary>
    /// <returns> Путь к исполняемой сборки. </returns>
    private static string GetFolderExecutingAssembly()
    {
        return Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
    }
}