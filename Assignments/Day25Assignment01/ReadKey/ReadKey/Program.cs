using System;
using System.ComponentModel.Design;

namespace ReadKey
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter Pin: ");
            int i = 0;
            ConsoleKeyInfo[] c = new ConsoleKeyInfo[4];
            char[] ch=new char[4];
            

            while (true)
            {
                ConsoleKeyInfo Key = Console.ReadKey(true);
                if (char.IsLetterOrDigit(Key.KeyChar)&&i<4)
                {
                    ch[i] = Key.KeyChar;
                    Console.Write("*");
                    i++;
                }
                else if (Key.Key == ConsoleKey.Backspace && i > 0)
                {
                    i--;
                    Console.Write("\b \b");
                }
                else if(Key.Key == ConsoleKey.Enter)
                {
                    if (i == 4) break;

                    else Console.Beep();
                }
                else
                {
                    Console.Beep();
                }
            }
            
                Console.WriteLine();
            Console.WriteLine("Your PIN is:");
            for (int j=0; j < ch.Length; j++)
            {
                Console.Write(ch[j]);
            }
        }
    }
}
