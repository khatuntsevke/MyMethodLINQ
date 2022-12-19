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

using ConsoleApp;

var collection = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
Console.WriteLine("==== Коллекция =====");
foreach (var item in collection)
    Console.WriteLine(item);

var collectionWithTop = collection.Top(30);

Console.WriteLine("==== Коллекция после метода Top(30) =====");
foreach (var item in collectionWithTop)
    Console.WriteLine(item);

var persons = new List<Person>();
for (int age = 1; age < 10; age++)
    persons.Add(new Person(age));

Console.WriteLine("==== Коллекция Persons =====");
foreach (var item in persons)
    Console.WriteLine(item);

var personsWithTop = persons.Top(30, person => person.Age);

Console.WriteLine("==== Коллекция Persons после метода Top(30, p=>p.Age) =====");
foreach (var item in personsWithTop)
    Console.WriteLine(item);