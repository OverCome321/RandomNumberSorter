namespace RandomNumberSorterLibrary.Interfaces
{
    /// <summary>
    /// Интерфейс для алгоритмов сортировки.
    /// </summary>
    public interface ISorter
    {
        /// <summary>
        /// Сортировка списка чисел.
        /// </summary>
        /// <param name="numbers">Список чисел.</param>
        /// <returns>Отсортированный список чисел.</returns>
        List<int> Sort(List<int> numbers);
    }
}
