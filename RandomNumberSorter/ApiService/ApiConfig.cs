namespace ApiService
{
    /// <summary>
    /// Класс для работы с конфигурацией.
    /// </summary>
    public static class ApiConfig
    {
        private const string ConfigFilePath = "apiconfig.txt";

        /// <summary>
        /// Получить URL API из конфигурационного файла.
        /// </summary>
        public static string GetApiUrl()
        {
            try
            {
                return System.IO.File.ReadAllText(ConfigFilePath).Trim();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка чтения конфигурации: {ex.Message}");
                return string.Empty;
            }
        }
    }
}
