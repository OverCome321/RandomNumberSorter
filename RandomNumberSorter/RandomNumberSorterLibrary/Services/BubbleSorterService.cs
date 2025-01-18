using RandomNumberSorterLibrary.Interfaces;

namespace RandomNumberSorterLibrary.Services
{
    /// <summary> 
    /// Реализация сортировки пузырьком.
    /// </summary>
    public class BubbleSorterService : ISorter
    {
        public List<int> Sort(List<int> numbers)
        {
            List<int> sortedNumbers = new List<int>(numbers);
            for (int i = 0; i < sortedNumbers.Count - 1; i++)
            {
                for (int j = 0; j < sortedNumbers.Count - i - 1; j++)
                {
                    if (sortedNumbers[j] > sortedNumbers[j + 1])
                    {
                        int temp = sortedNumbers[j];
                        sortedNumbers[j] = sortedNumbers[j + 1];
                        sortedNumbers[j + 1] = temp;
                    }
                }
            }
            return sortedNumbers;
        }
    }
}
