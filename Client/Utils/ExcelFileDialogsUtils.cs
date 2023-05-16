namespace Client.Utils
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// Инструмент для работы с файловыми диалогами.
    /// </summary>
    public static class ExcelFileDialogsUtils
    {
        /// <summary>
        /// Строка фильтра excel-файлов.
        /// </summary>
        private const string EXCEL_FILTER = "xlsx";

        /// <summary>
        /// Открывает файловый диалог для сохранения excel-файла.
        /// </summary>
        /// <returns>Путь до файла.</returns>
        public static string SaveExcelFile(string dialogTitle = null, string fileName = "")
        {
            return FileDialogShower.GetFilePathViaSaveDialog(dialogTitle, fileName, EXCEL_FILTER);
        }
    }
}