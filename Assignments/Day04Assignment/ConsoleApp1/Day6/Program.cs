using MyClassLibrary;

namespace Day6
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Console.WriteLine("Hello, World!");
            //int result=MyMath.GetDouble(23);
            //Console.WriteLine($"Double of 23 is {result}");
            //double result2 = MyMath.cube(5);
            //Console.WriteLine($"Cube of 5 is {result2}");

            for(int i=15;i<=51;i=i+9)
            {
                string result = i.ToString();
                Console.Write(result[0]+" " + result[1] + " ");

            }
        }
    }
}
