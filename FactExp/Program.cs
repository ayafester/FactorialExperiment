using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace FactExp
{
    class Program
    {
        static double solve(int k, int q, int p) //функция для вычисления полного прогона
        {
            double N = p * Math.Pow(q, k);
            return N;
        }

        static void Main(string[] args)
        {
        Repeat:
            Console.WriteLine("Программа оценки трудоемкости выполнения Полного факторного эксперимента.");
            int k = 0;
            string str;
            bool success = false;

            while (!success)
            {
                Console.WriteLine("Введите количество факторов k: ");
                str = Console.ReadLine();
                success = Int32.TryParse(str, out k);
            }
    
            int q = 0;
            string strQ;
            bool successQ = false;
            while (!successQ)
            {
                Console.WriteLine("Введите количество уровней факторов q: ");
                strQ = Console.ReadLine();
                successQ = Int32.TryParse(strQ, out q);
            }
  
            int p = 0;
            string strP;
            bool successP = false;
            while (!successP)
            {
                Console.WriteLine("Введите количество прогонов модели в каждом наблюдении p: ");
                strP = Console.ReadLine();
                successP = Int32.TryParse(strP, out p);
            }

            double N = solve(k, q, p);
            Console.WriteLine($"Полное количество прогонов модели N: {N}");

            Console.WriteLine("Определим входящий параметр, который следует уменьшить для наибольшего сокращения числа общих прогонов N: ");

            double Nk = solve(k - 1, q, p);
            Console.WriteLine($"Полное количество прогонов модели N, при уменьшении числа количества факторов k - 1: {Nk}");

            double Nq = solve(k, q - 1, p);
            Console.WriteLine($"Полное количество прогонов модели N, при уменьшении числа количества уровней факторов q - 1: {Nq}");

            double Np = solve(k, q, p - 1);
            Console.WriteLine($"Полное количество прогонов модели N, при уменьшении количества прогонов p - 1: {Np}");

            //результат
            string answer = "";//строка для выведения в интерфейс
            int indexValue = 0;//временная переменная для помощи выведения результата
            double[] arr = { Nk, Nq, Np };
            double res = arr[0];

            for (int i = 0; i < arr.Length; i++) //выявление минимального числа из вычисленных чисел прогонов из изменных показателей
            {
                if (res > arr[i])
                {
                    res = arr[i];
                    indexValue = i;
                }
            }

            if (indexValue == 0) //запись параметра для интерфейса
            {
                answer = "k, значение количества факторов";
            }
            else if (indexValue == 1)
            {
                answer = "q, значение количества уровней факторов";
            }
            else if (indexValue == 2)
            {
                answer = "p, значение количества прогонов";
            }

            Console.WriteLine($"Для наибольшего сокращения числа общих прогонов следует уменьшить параметр {answer}");

            Console.WriteLine("Нажмите Enter для ввода новых данных, а для выхода нажмите Esc и закройте консоль");
            ConsoleKeyInfo rep = Console.ReadKey(true);
            if (rep.Key == ConsoleKey.Enter) goto Repeat;
            if (rep.Key == ConsoleKey.Escape) return;

        }


    }
}
