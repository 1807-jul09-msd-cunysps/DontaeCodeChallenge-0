using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Palindrome;

namespace Palindrome
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] array = {"a nut for a jar of tuna", "Borrow or rob", "343", "oppo"/*Testing a random word*/};

            for (int i = 0; i < 4; ++i)
            {
                //Console.WriteLine(array[i]);

                string inputr = "";

                string input = array[i];

                int iLen = input.Length;

                for (int j = iLen - 1; j >= 0; j--)
                {
                    inputr = inputr + input[j];
                }

                if (inputr == input)
                {
                    Console.WriteLine(input + " is palindrome");
                }
                else
                {
                    Console.WriteLine(input + " is not a palindrome");
                }
            }
            Console.Write("Press any button to exit");
            Console.Read();
        }
    }
}
