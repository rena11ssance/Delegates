# Делегаты

Задача.  В приложении объявить тип делегата, который ссылается на метод. Требования к сигнатуре метода следующие:

-       метод получает входным параметром переменную типа double;
        метод возвращает значение типа double, которое является результатом вычисления.

 

Реализовать вызов методов с помощью делегата, которые получают радиус R и вычисляют:

-       длину окружности по формуле D = 2 * π * R;
        площадь круга по формуле S = π * R²;
        объем шара. Формула V = 4/3 * π * R³.



Методы должны быть объявлены как статические.

Решение: 

```
using System;
using System.Collections.Generic;

namespace Delegates
{
    internal class Program
    {
        delegate double MyDelegate(double radius);
        static void Main(string[] args)
        {
            Console.Write("Введите радиус: ");
            double radius = Convert.ToDouble(Console.ReadLine());

            MyDelegate delegateForAll = Circumference;
            delegateForAll += areaOfCircle;
            delegateForAll += volumeOfBall;
            
            List<double> resultsForDelegates = new List<double>();
            string[] namesBeforePrint = new string[3] {"Длина окружности равна = ", "Площадь круга равна = ", "Объем шара равен = "};

            foreach (MyDelegate results in delegateForAll.GetInvocationList())
            {
                resultsForDelegates.Add(results(radius));
            }

            for (int i = 0; i < resultsForDelegates.Count; i++)
            {
                Console.WriteLine($"{namesBeforePrint[i]}{resultsForDelegates[i]:F2}.");
            }
        }

        static double Circumference(double r) => 2 * Math.PI * r;
        static double areaOf​​Circle(double r) => Math.PI * Math.Pow(r, 2);
        static double volumeOfBall(double r) => 4.0 / 3.0 * Math.PI * Math.Pow(r, 3);
    }
}

```
