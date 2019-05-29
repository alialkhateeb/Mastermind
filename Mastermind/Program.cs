using System;
using System.Collections.Generic;

namespace Mastermind
{
    class Program
    {
        static void Main(string[] args)
        {
            Master.generatesecret();
            List<int> lis = new List<int>();
            Console.WriteLine("Please Enter 4 digits from 1 to 6 inclusive: ");
            
            try
            {
                
                for (int i = 0; i < 10; i++)
                {
                    var entered = Console.ReadLine();
                    
                    char[] checker = Master.parseInput(entered);
                    Console.WriteLine(checker);
                    
                    if (Master.validateData(checker) == 4)
                    {
                        Console.WriteLine("You Won!!");
                        break;
                    }
                    else
                    {
                        if (i < 9)
                        {
                        Console.WriteLine("Not quite right, keep trying!");
                        }
                        else
                        {
                            Console.WriteLine("You have lost the game.");
                        }
                    }
                }

            }
            catch (LongerThanFourException e)
            {
                Console.WriteLine("Invalid value, " + e.Message);
                
            }
            catch(InvalidInputException e)
            {
                Console.WriteLine("Invalid value, " + e.Message);
            }
            
            
        }
    }
}
