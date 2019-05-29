using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;


namespace Mastermind
{
    class Master
    {
        public static int[] secret;
        

        public static void generatesecret()
        {
            secret = new int[4];
            
            Random rand = new Random();
            for (int i = 0; i < secret.Length; i++)
            {
                secret[i] = rand.Next(6) + 1;
            }
        }
        public static int validateData(char[] checker)
        {
            int counter = 0;
            for (int i = 0; i < checker.Length; i++)
            {
                if (checker[i] == '+')
                {
                    counter++;
                }
            }
            return counter;
        }
        public static char[] parseInput(string value)
        {
            List<char> listChar = new List<char>();
            char[] checker = new char[4];
            listChar.AddRange(value.ToCharArray());
            
            if (value.Length != 4)
            {
                throw new LongerThanFourException("Please Enter 4 digits from 1 to 6 inclusive: ");
            }


            else if (listChar.Exists(z => z < '1' || z > '6'))
            {
                throw new InvalidInputException("the input string contain invalid character.");
            }
            else
            {
                for (int i = 0; i < listChar.Count; i++)
                {
                    if (Array.Exists(secret, s => s.Equals(Convert.ToInt32(listChar[i].ToString()))))
                    {
                        if (Convert.ToInt32(listChar[i].ToString()) == secret[i])
                        {
                            checker[i] = '+';
                        }
                        else
                        {
                            checker[i] = '-';
                        }

                    }else
                    {
                        checker[i] = 'x';
                    }
                    
                }
            }
            

            return checker;
        }

    }
    public class LongerThanFourException: Exception
    {
        public LongerThanFourException(string message): base(message)
        {

        }
    }
    public class InvalidInputException : Exception
    {
        public InvalidInputException(string message) : base(message)
        {

        }
    }
}
