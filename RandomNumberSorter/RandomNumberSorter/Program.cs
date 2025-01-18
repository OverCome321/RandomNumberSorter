using ApiService;
using RandomNumberSorterLibrary;

namespace RandomNumberSorter
{
    class Program
    {
        static async Task Main(string[] args)
        {
            // Генерация случайного списка чисел
            Random random = new Random();
            int count = random.Next(20, 101);
            List<int> numbers = Enumerable.Range(0, count).Select(_ => random.Next(-100, 101)).ToList();

            Console.WriteLine("Сгенерированная последовательность:");
            Console.WriteLine(string.Join(", ", numbers));

            // Выбор случайного алгоритма сортировки
            var sorter = SorterFactory.GetRandomSorter();
            List<int> sortedNumbers = sorter.Sort(numbers);

            Console.WriteLine($"\nОтсортированная последовательность ({sorter.GetType().Name}):");
            Console.WriteLine(string.Join(", ", sortedNumbers));

            // Получение API URL из конфигурации
            string apiUrl = ApiConfig.GetApiUrl();
            // Проверка URL перед отправкой
            if (string.IsNullOrEmpty(apiUrl))
            {
                Console.WriteLine("\nНе удалось получить URL API из конфигурации.");
                return;
            }
            Console.WriteLine($"\nОтправка данных на сервер по адресу: {apiUrl}");

            // Отправка данных на сервер
            await ApiHelper.SendDataToServer(apiUrl, sortedNumbers);
        }
    }
}