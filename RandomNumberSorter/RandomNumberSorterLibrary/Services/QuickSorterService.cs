using RandomNumberSorterLibrary.Interfaces;

namespace RandomNumberSorterLibrary.Services
{
    /// <summary>
    /// Реализация быстрой сортировки.
    /// </summary>
    public class QuickSorterService : ISorter
    {
        public List<int> Sort(List<int> numbers)
        {
            if (numbers.Count <= 1) return numbers;

            int pivot = numbers[numbers.Count / 2];
            List<int> less = numbers.Where(x => x < pivot).ToList();
            List<int> equal = numbers.Where(x => x == pivot).ToList();
            List<int> greater = numbers.Where(x => x > pivot).ToList();

            return Sort(less).Concat(equal).Concat(Sort(greater)).ToList();
        }
    }
}
