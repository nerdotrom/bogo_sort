using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
namespace bogo_sort
{
    internal class Program
    {
        static void Main(string[] args)
        {
            void WriteArray(int[] arr)
            {
                foreach (int x in arr)
                {
                    Console.Write(x + " ");
                }
                Console.WriteLine();
            }
            bool CompareArray(int[] pole, int[] serazene_pole) 
            {
                for (int i = 0; i < pole.Length - 1; ++i)
                {
                    if (pole[i] != serazene_pole[i])
                    { 
                        return false;
                    }
                }
                return true;
            }
            //timer
            Stopwatch timer = new Stopwatch();
            timer.Start();
            //pole
            Console.Write("Zadejte delku pole: ");
            int delka = Convert.ToInt32(Console.ReadLine());
            Random random = new Random();
            int[] pole = new int[delka];
            for (int i = 0; i < pole.Count(); i++)
            {
                pole[i] = random.Next(1, 50);
            }

            int[] serazene_pole = new int[pole.Count()];
            pole.CopyTo(serazene_pole, 0);
            Array.Sort(serazene_pole);
            Console.Write("Puvodní pole");
            WriteArray(pole);
            Console.WriteLine();
            //loop
            int otocky = 0;
            while (true)
            {
                if (CompareArray(pole, serazene_pole)) { break; }
                for (int i = 0; i < pole.Length - 1; ++i)
                {
                    int r = random.Next(i, pole.Length);
                    (pole[r], pole[i]) = (pole[i], pole[r]);
                }
                otocky++;
                WriteArray(pole);

            }
            WriteArray(pole);
            Console.WriteLine("otocky: " + otocky);
            Console.WriteLine("cas: " + timer.Elapsed.ToString());
        }
    }
}