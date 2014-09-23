﻿using System;
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
            

            do
            {
                Console.Clear();
                int number = ReadInt("Skriv antal löner du vill mata in:");
                int[] salaries;
                salaries = ReadSalaries(number);

                ViewResult(salaries);


            } while (IsCounting());

        }

        static bool IsCounting()
        {
            //clera innan man börjar om
            ViewMessage(("Klicka på valfri tangent för att fortsätta. \nEsc avslutar programmet"), false);
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
                    if (value <= 2) //Om det användaren skrivit är lika med eller större än två
                    {
                        throw new OverflowException();
                    }
                    break;
                }
                catch (FormatException) //if the for doesnt work, then the catch will come up
                {
                    ViewMessage(("FEL!! \n kan inte tolkas som ett heltal!\n"), true); //Vill läga in input-fungerar ej
                    //view message ändrar färg om det är fel
                }
                catch (OverflowException)
                {
                    ViewMessage(("FEL!! \nSkriv ett tal(med siffror) som är mer än två!\n"), true);
                    //view message ändrar färg om det är fel
                }
             }
            return value;
        } //användaren skriver in hur många löner han vill jobba med

        static int[] ReadSalaries(int count) //Användaren fyller värden i lönerna. ANtal löner från ReadInt
        {
            
            int []salaries = new int [count]; //salaries en array med användarens amount
          
            for (int i = 0; i < count; i++)
            {
                Console.Write("Skriv in lön nummer {0}:       ", i+1);
                salaries[i]= int.Parse(Console.ReadLine());

            }
            return salaries;
        }

        static int GetDispersion(int[] source) //Räknar ut lönespridningen
        {
            return (source.Max() - source.Min());
        }

        static int GetMedian(int[] source)
        {
            Array.Sort(source);
            int arrayLength = source.GetLength(0);
            if (arrayLength % 2 != 0) //om det är udda tal
            {
                return (source[arrayLength / 2]);
            }
            else
            {
                return ((source[arrayLength / 2 - 1] + source[arrayLength / 2]) / 2); //Räknar ut första medelvärdet -1(för att den avrundar uppåt) och sedan det andra. för att sedan addera dessa och dela dem på två.
           
            }
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
            Console.WriteLine("\n{0}",message); //Felmeddelandet
            Console.ResetColor();
        }

        static void ViewResult(int[] salaries)
        {

            Console.WriteLine("---------------------------------");
            Console.WriteLine("{0,-15}{1,15:c0}", "Medianlönen:", GetMedian(salaries));
            Console.WriteLine("{0,-15}{1,15:c0}", "Medellönen:", salaries.Average());
            Console.WriteLine("{0,-15}{1,15:c0}", "Lönespridning:", GetDispersion(salaries));
            Console.WriteLine("---------------------------------");

            for (int i = 0; i < salaries.GetLength(0); i++) //skriver ut lönerna med en loop ich kallar på arrayn
            {
               switch(i % 3)
               {
                   case 0:
                       Console.Write("{0,10}", salaries[i]);
                       break;
                    case 1:
                       Console.Write("{0,10}", salaries[i]);
                       break;
                    case 2:
                       Console.WriteLine("{0,10}", salaries[i]);
                       break;

               }
        }

            
        }
    }
}
