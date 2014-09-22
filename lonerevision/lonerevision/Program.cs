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
            Console.Clear();
            int number = ReadInt("Skriv antal löner du vill mata in:");
             ReadSalaries(number);

            do
            {
                //ViewResult();


            } while (IsCounting());

        }

        static bool IsCounting()
        {
            //clera innan man börjar om
            ViewMessage(("Klicka på valfri tangent för att fortsätta. \nEsc avslutar programmet"), true);
            return Console.ReadKey(true).Key != ConsoleKey.Escape;
        } //avslutar genom ESC, tryck valfri tangent för att börja igen

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
                    if (value >= 2) //Om det användaren skrivit är lika med eller större än två
                    {
                        break;
                    }
                    throw new Exception();
                }
                catch (FormatException) //if the for doesnt work, then the catch will come up
                {
                    ViewMessage(("FEL!! \n kan inte tolkas som ett heltal!"), true); //Vill läga in input-fungerar ej
                    //view message ändrar färg om det är fel
                }
                catch (OverflowException)
                {
                    ViewMessage(("FEL!! \nSkriv ett tal(med siffror) som är mer än två!"), true);
                    //view message ändrar färg om det är fel
                }
             }
            return value;
        } //användaren skriver in hur många löner han vill jobba med



        static int[] ReadSalaries(int count) //Användaren fyller värden i lönerna. ANtal löner från ReadInt
        {
            
            int []salaries = new int [count]; //salaries en array med användarens amount
          
            for (int i = 1; i <= count; i++)
            {
                Console.Write("Skriv in lön nummer {0}:", i);
                salaries[i]= int.Parse(Console.ReadLine());

            }
            return salaries;
        }



        static int GetDispersion(int[] source)
        {
            return (source.Max() - source.Min());
        }

        static int GetMedian(int[] source)
        {
         throw new Exception();
        }

        static void ViewMessage(string message, bool isError)
        {
            if (isError)
            {
                Console.BackgroundColor = ConsoleColor.Red;
            }
            else
            {
                Console.BackgroundColor = ConsoleColor.Blue;
            }
            Console.Write(message); //Felmeddelandet
            Console.ResetColor();
        }

        static void ViewResult(int[] salaries)
        {
            
        }
    }
}
