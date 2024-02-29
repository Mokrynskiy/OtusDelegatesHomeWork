using System.Text.RegularExpressions;

namespace OtusDelegatesHomeWork
{
    public class FileSearcher
    {
        public delegate void FileFound(FileSearcher sender, FileFoundEventArgs e);
        public event FileFound? FileFoundEventHandler;
        public bool Cancel = false;
        /// <summary>
        /// Поиск файлов в указанной дирректории по имени файла
        /// </summary>
        /// <param name="directoryPath">Полны путь к дирректории</param>
        /// <param name="fileName">Имя файла (начальные символы имени)</param>
        public void Search(string directoryPath, string fileName)
        {
            try
            {
                if (Directory.Exists(directoryPath))
                {
                    foreach (string file in Directory.GetFiles(directoryPath,".", SearchOption.AllDirectories))
                    {
                        if (Cancel) return;
                        var regex = new Regex($"^{fileName.ToLower()}");
                        if (regex.IsMatch(Path.GetFileName(file).ToLower()))
                            FileFoundEventHandler?.Invoke(this, new FileFoundEventArgs { Message = file});                        
                    }
                }
                else
                {
                    FileFoundEventHandler?.Invoke(this, new FileFoundEventArgs { Message = $"Не удалось найти путь - {directoryPath}" });
                }
            }
            catch (Exception ex)
            {
                FileFoundEventHandler?.Invoke(this, new FileFoundEventArgs { Message = ex.Message });
            }
        }
    }

    // Event
    public class FileFoundEventArgs: EventArgs
    {
        public string Message;
    }
}
