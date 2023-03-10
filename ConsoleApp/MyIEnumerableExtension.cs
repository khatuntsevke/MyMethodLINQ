/*
Напишите свой метод расширения с названием "Top" для коллекции IEnumerable, принимающий значение Х от 1 до 100 и
возвращающий заданное количество процентов от выборки с округлением количества элементов в большую сторону.
То есть для списка var list = new List{1,2,3,4,5,6,7,8,9};
list.Top(30) должно вернуть 30% элементов от выборки по убыванию значений, то есть [9,8,7] (33%), а не [9,8] (22%).
Если переданное значение больше 100 или меньше 1, то выбрасывать ArgumentException.
Напишите перегрузку для метода "Top", которая принимает ещё и поле, по которому будут отбираться топ Х элементов.
Например, для var list = new List{...}, вызов list.Top(30, person => person.Age) должен вернуть 30% пользователей
с наибольшим возрастом в порядке убывания оного.

1) Создайте дженерик метод расширения для IEnumerable, возвращающий коллекцию, на которой был вызван;
2) Ограничьте количество элементов выходной коллекции;
3) Создайте дженерик перегрузку метода Top, добавив для этого одним из параметров функцию, принимающую T и возвращающую int;
 */
namespace ConsoleApp
{
    internal static class MyIEnumerableExtension
    {
        internal static IEnumerable<T> Top<T>(this IEnumerable<T> collection, uint percentages)
        {
            if (percentages > 100 || percentages < 1)
                throw new ArgumentException($"percentages={percentages} не может быть меньше 1 или больше 100");

            uint reducedCollectionSize = (uint)Math.Round(collection.Count() * percentages / 100.0);

            return collection.OrderByDescending(item => item).Where( (_, i) => i < reducedCollectionSize );
        }

        internal static IEnumerable<T> Top<T>(this IEnumerable<T> collection, uint percentages, Func<T, int> keySelector)
        {
            if (percentages > 100 || percentages < 1)
                throw new ArgumentException($"percentages={percentages} не может быть меньше 1 или больше 100");

            uint reducedCollectionSize = (uint)Math.Round(collection.Count() * percentages / 100.0);

            return collection.OrderByDescending(item => keySelector(item)).Where((_, i) => i < reducedCollectionSize);
        }
    }
}
