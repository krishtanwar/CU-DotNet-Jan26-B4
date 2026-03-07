using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tracing
{
    internal class Splitwise
    {
        public static void Split(params int[] arr)
        {

            int sum = 0;
            for (int i = 0; i < arr.Length; i++)
            {
                sum += arr[i];
            }
            int average = sum / arr.Length;

            for (int i = 0; i < arr.Length; i++)
            {

                int a = 0;
                int x = arr.Max();
                int index = Array.IndexOf(arr, x);
                if (arr[i] < average)
                {
                    a = average - arr[i];
                    arr[index] -= a;
                    arr[i] += a;
                    Console.WriteLine($"{a} amount is given to arr[{index}] by arr[{i}]");
                }

            }
        }
        static void Main(string[] args)
        {
            int[] arr = { 500, 600, 700, 800, 900, 1000, 2000 };
            Console.WriteLine("Given Array:");
            Console.Write(arr[0]);
            for (int i = 1; i < arr.Length; i++)
            {

                Console.Write("," + arr[i]);

            }
            Console.WriteLine();
            Array.Sort(arr);
            Console.WriteLine("Sorted Array:");
            Console.Write(arr[0]);
            for (int i = 1; i < arr.Length; i++)
            {

                Console.Write("," + arr[i]);

            }
            Console.WriteLine();
            Console.WriteLine(arr.Average());
            Console.WriteLine();
            Split(arr);

        }
    }
}
