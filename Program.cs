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
