using RandomNumberSorterLibrary.Interfaces;
using RandomNumberSorterLibrary.Services;

namespace RandomNumberSorterLibrary
{
    /// <summary>
    /// Фабрика для выбора случайного алгоритма сортировки.
    /// </summary>
    public static class SorterFactory
    {
        private static readonly List<ISorter> Sorters = new List<ISorter> { new BubbleSorterService(), new QuickSorterService() };

        /// <summary>
        /// Возвращает случайный алгоритм сортировки.
        /// </summary>
        public static ISorter GetRandomSorter()
        {
            Random random = new Random();
            int index = random.Next(Sorters.Count);
            return Sorters[index];
        }
    }
}
