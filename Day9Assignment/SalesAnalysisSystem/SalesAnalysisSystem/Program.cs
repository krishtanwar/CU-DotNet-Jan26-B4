using System.Diagnostics.CodeAnalysis;
using System.Threading.Channels;

namespace SalesAnalysisSystem
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] arr = new int[7];
            for (int i = 0; i < arr.Length; i++)
            {
                int input;
                input = int.Parse(Console.ReadLine());
                if (input >= 0)
                    arr[i] = input;
                else return;

            }
            int sum = 0;
            for(int i=0;i< arr.Length; i++)
            {
                sum+=arr[i];
            }
            int avg=sum/ arr.Length;
            int highest = int.MaxValue(arr);

        }
    }
}
