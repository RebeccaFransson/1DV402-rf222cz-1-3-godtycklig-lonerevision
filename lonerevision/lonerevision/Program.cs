using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lonerevision
{
    class Program
    {
        static void Main(string[] args)
        {
            int number = ReadInt("Skriv antal löner du vill mata in:");
             ReadSalaries(number);

            do
            {
                Console.Write(number);


            } while (IsCounting());

        }

        static bool IsCounting()
        {
            return Console.ReadKey(true).Key != ConsoleKey.Escape;
        }

        static int ReadInt(string prompt)
        {
            int value = 0;
            string input;
            while (true)
            {
                Console.Write(prompt);
                input = Console.ReadLine(); //Read int får ett värde från användaren
                try
                {
                    value = int.Parse(input);
                    if (value >= 2) //Om det användaren skrivit är lika emd eller mindre än två
                    {
                        break;
                    }
                    throw new Exception();
                }
                catch //if the for doesnt work, then the catch will come up
                {
                    Console.BackgroundColor = ConsoleColor.Red;
                    Console.WriteLine("FEL!! \nSkriv ett tal(med siffror) som är mer än två!");
                    Console.ResetColor();
                }
             }
            return value;
        }



        static int[] ReadSalaries(int count)
        {
            Console.Write("Skriv in lön nummer {i}:", count);
            int []salaries = new int [count]; //salaries en array med användarens amount
          
            for (int i = 0; i < salaries.GetLength(0); i++)
            {
                Console.Write("Skriv in lön nummer {0}:", i);
                salaries[i]= int.Parse(Console.ReadLine());

            }
            return salaries;
        }




        static int GetDispersion(int[] source)
        {
            throw new Exception();
        }

        static int GetMedian(int[] source)
        {
         throw new Exception();
        }

        


        static void ViewMessage(string message, bool isError)
        {
            throw new Exception();
        }

        static void ViewResult(int[] salaries)
        {
            throw new Exception();
        }
    }
}
