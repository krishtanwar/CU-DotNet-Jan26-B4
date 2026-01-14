using System;
using System.ComponentModel;
using System.Text;

namespace DotNetLearning
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //    for (int i = 15; i <= 51; i = i + 9)
            //    {
            //        string result = i.ToString();
            //        Console.Write(result[0] + " " + result[1] + " ");

            //    }

            //    for (int i = 5; i >= 1; i--)
            //    {
            //        for (int j = 1; j <= 5; j++)
            //        {
            //            Console.Write(j + " " + i);
            //            continue;
            //        }
            //        Console.WriteLine();
            //    }
            //string[] fruits = new string[10];
            //string[] cities = { "delhi", "Chd" };
            //fruits[0] = "orange";

            string cityNames = "delhi,   ,mumbai,    ,chd";
            //        string cities2 = cityNames.Split(',');

            //char[] separators = { ',', ';', ' ' };

            //string[] cities = cityNames.Split(separators);

            //for (int i = 0; i < cities.Length; i++)
            //{
            //    Console.WriteLine(cities[i]);
            //}
            //checked block is used to limit overflow

            //int to byte conversion
            //sbyte-> negative numbers of byte

            //string[] cityNames2 = cityNames.Split(',', StringSplitOptions.RemoveEmptyEntries|StringSplitOptions.TrimEntries);
            //for(int i=0; i<cityNames2.Length;i++)
            //{
            //    Console.WriteLine(cityNames2[i]);
            //}
            //int a = 65;
            //char c = (char)a;
            //Console.WriteLine(c); ;

            //for(int i = 0; i <= 5; i++)
            //{
            //    for(int spaces = 0; spaces < 5 - i; spaces++)
            //    {
            //        Console.Write($" ");
            //    }
            //    for(int j = 0; j <= i; j++)
            //    {
            //        Console.Write($"{(char)(j+65)}");
            //    }
            //    Console.WriteLine();
            //}

            //DateTime today = DateTime.Now;
            //DateTime today2 = DateTime.Today;
            //Console.WriteLine($"{today:dddd/MMMM/yyyy}");
            //Console.WriteLine(today);

            string name = "krish";
            Console.WriteLine(name.GetHashCode());

            name = name + "k";

            Console.WriteLine(name.GetHashCode());
            // IsnullorEmpty and IsnullorWhiteSpace

            Console.WriteLine(string.IsNullOrEmpty(name));
        }

    }
}

