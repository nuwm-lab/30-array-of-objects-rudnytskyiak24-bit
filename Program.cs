using System;

namespace SinFunctionApp
{
    // Клас "Функція sin(ax + b)"
    class SinFunction
    {
        public double a { get; set; }
        public double b { get; set; }

        public SinFunction(double a, double b)
        {
            this.a = a;
            this.b = b;
        }

        // Обчислює значення функції в точці x
        public double Evaluate(double x)
        {
            return Math.Sin(a * x + b);
        }

        // Амплітуда функції sin(ax + b) — дорівнює |a| (з математичної точки зору, множник перед sin не змінює амплітуду,
        // але якщо мається на увазі a * sin(x + b), то амплітуда буде |a| — уточни за потреби)
        public double GetAmplitude()
        {
            return Math.Abs(a);
        }

        // Введення коефіцієнтів функції
        public void InputFunctionData()
        {
            Console.WriteLine("Enter coefficient a:");
            a = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("Enter coefficient b:");
            b = Convert.ToDouble(Console.ReadLine());
        }

        // Виведення даних про функцію
        public void DisplayFunction()
        {
            Console.WriteLine($"Function: sin({a}x + {b})");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter the number of sin(ax + b) functions:");
            int n = Convert.ToInt32(Console.ReadLine());

            SinFunction[] functions = new SinFunction[n];

            // Введення x — точки, в якій обчислюється значення функції
            Console.WriteLine("Enter the point x at which to evaluate the functions:");
            double x = Convert.ToDouble(Console.ReadLine());

            // Введення даних для кожної функції
            for (int i = 0; i < n; i++)
            {
                Console.WriteLine($"\nFunction #{i + 1}:");
                functions[i] = new SinFunction(0, 0);
                functions[i].InputFunctionData();
            }

            // Знаходимо функцію з найбільшим значенням у точці x
            double maxValue = double.MinValue;
            int maxIndex = -1;

            for (int i = 0; i < n; i++)
            {
                double valueAtX = functions[i].Evaluate(x);
                Console.WriteLine($"Value of function #{i + 1} at x = {x}: {valueAtX}");

                if (valueAtX > maxValue)
                {
                    maxValue = valueAtX;
                    maxIndex = i;
                }
            }

            // Вивід результату
            Console.WriteLine($"\nFunction #{maxIndex + 1} has the maximum value at x = {x}.");
            functions[maxIndex].DisplayFunction();
            Console.WriteLine($"Its amplitude is: {functions[maxIndex].GetAmplitude()}");
        }
    }
}
