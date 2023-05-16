namespace Client.Utils
{
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.IO;
    using System.Linq;
    using System.Text;

    using Microsoft.Win32;

    /// <summary>
    /// Отображает диалоговое окно
    /// </summary>
    public static class FileDialogShower
    {
        /// <summary>
        /// Выбор файла (вызывает OpenFileDialog).
        /// </summary>
        /// <param name="dialogTitle"> Название окна. </param>
        /// <param name="extensions"> Список доступных расширений. </param>
        /// <returns> Полное имя файла. </returns>
        public static string GetFilePathViaOpenDialog(string dialogTitle, params string[] extensions)
        {
            var openFileDialog = new OpenFileDialog
            {
                Filter = GetFilterStringForExtensions(extensions),
                CheckFileExists = true,
                Multiselect = false
            };

            if (!string.IsNullOrWhiteSpace(dialogTitle))
                openFileDialog.Title = dialogTitle;

            return openFileDialog.ShowDialog() == true
                ? openFileDialog.FileName
                : null;
        }

        /// <summary>
        /// Выбор файла (вызывает SaveFileDialog).
        /// </summary>
        /// <param name="dialogTitle"> Название окна. </param>
        /// <param name="fileName">Название файла.</param>
        /// <param name="extensions"> Список доступных расширений (первое из них устанавливается, как расширение по умолчанию). </param>
        /// <returns> Полное имя файла. </returns>
        public static string GetFilePathViaSaveDialog(string dialogTitle, string fileName, params string[] extensions)
        {
            var saveFileDialog = new SaveFileDialog
            {
                DefaultExt = extensions?.FirstOrDefault() ?? "",
                Filter = GetFilterStringForExtensions(extensions),
                FileName = fileName
            };

            if (!string.IsNullOrWhiteSpace(dialogTitle))
                saveFileDialog.Title = dialogTitle;

            return saveFileDialog.ShowDialog() == true
                ? saveFileDialog.FileName
                : null;
        }

        /// <summary>
        /// Выбор файлов (вызывает OpenFileDialog).
        /// </summary>
        /// <param name="dialogTitle"> Название окна. </param>
        /// <param name="extensions"> Список доступных расширений. </param>
        /// <returns> Список полных имен файлов. </returns>
        public static List<string> GetFilesPathViaOpenDialog(string dialogTitle, params string[] extensions)
        {
            var openFileDialog = new OpenFileDialog
            {
                CheckFileExists = true,
                Multiselect = true,
                Filter = GetFilterStringForExtensions(extensions)
            };

            if (!string.IsNullOrWhiteSpace(dialogTitle))
                openFileDialog.Title = dialogTitle;

            return openFileDialog.ShowDialog() == true
                ? openFileDialog.FileNames.ToList()
                : new List<string>();
        }

        /// <summary>
        /// Открыть папку.
        /// Если путь даже указан до файла, откроется папка и в данной папке будет выбран этот файл.
        /// </summary>
        /// <param name="filePath">Путь до файла/папки.</param>
        public static void OpenFolder(string filePath)
        {
            var argument = $"/select, \"{filePath}\"";
            // Если путь до файла не существует, изменить команду, на открытие папки без выбора.
            if (!File.Exists(filePath))
            {
                filePath = $@"{Path.GetDirectoryName(filePath)}\";
                argument = $"/n, {filePath}";
            }

            Process.Start("explorer.exe", argument);
        }

        /// <summary>
        /// Получает строку для фильтра из доступных расширений.
        /// </summary>
        /// <param name="extensions"> Допустимые расширения файлов. </param>
        /// <returns> Строку для фильтра доступных расширений. </returns>
        private static string GetFilterStringForExtensions(string[] extensions)
        {
            var filterBuilder = new StringBuilder();
            foreach (var extension in extensions)
            {
                filterBuilder.Append($"{extension.ToUpper()} файлы|*.{extension}|");
            }

            filterBuilder.Append("Все файлы|*");
            return filterBuilder.ToString();
        }
    }
}