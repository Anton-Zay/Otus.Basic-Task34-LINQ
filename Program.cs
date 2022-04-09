using System;
using System.Collections.Generic;
using System.Linq;

namespace TopMethod
{
    class Program
    {
        static void Main(string[] args)
        {
            A.A_Main();
        }
    }
    public static class A
    {
        public static void A_Main()
        {
            var list = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            foreach (int item in list.Top(30))
            {
                Console.WriteLine(item);
            }


            var person1 = new Person { Id = 1, Age = 25 };
            var person2 = new Person { Id = 5, Age = 5 };
            var person3 = new Person { Id = 3, Age = 40 };
            var person4 = new Person { Id = 8, Age = 80 };
            var person5 = new Person { Id = 10, Age = 12 };
            var person6 = new Person { Id = 56, Age = 96 };
            var person7 = new Person { Id = 4, Age = 51 };
            var person8 = new Person { Id = 0, Age = 36 };
            var person9 = new Person { Id = 35, Age = 75 };

            var listPerson = new List<Person> { person1, person2, person3, person4, person5, person6, person7, person8, person9 };

            foreach (Person item in listPerson.Top(30, person => person.Age))
            {
                Console.WriteLine($"ID = {item.Id};     Age = {item.Age}");
            }
        }

        public static IEnumerable<int> Top(this IEnumerable<int> collection, int percentToReturn)
        {
            if (percentToReturn < 1 || percentToReturn > 100)
            {
                throw new ArgumentException("Введите число от 1 до 100");
            }

            var sortList = collection.OrderByDescending(value => value);
            double range = Math.Ceiling((double)percentToReturn * Count(collection) / 100);
            return (sortList.Take((int)range));
        }
        public static IEnumerable<T> Top<T>(this IEnumerable<T> collection, int percentToReturn, Func<T, int> f)
        {
            if (percentToReturn < 1 || percentToReturn > 100)
            {
                throw new ArgumentException("Введите число от 1 до 100");
            }


            var sortList = collection.OrderByDescending(f);

            var result = new List<T>();
            double range = Math.Ceiling((double)percentToReturn * Count(collection) / 100);
            return (sortList.Take((int)range));
        }


        public static int Count<T>(IEnumerable<T> collection)
        {
            int count = 0;
            foreach (T item in collection)
            {
                count++;
            }
            return count;
        }
    }

    public class Person
    {
        public int Id { get; set; }
        public int Age { get; set; }
    }

}