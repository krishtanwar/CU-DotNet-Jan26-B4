//namespace ConsoleApp1
//{
//    internal class Program
//    {
//        static void Main(string[] args)
//        {
//            //SayHello();
//            //SayHello("Krish");
//            //int square = GetSquare(10);
//            //Console.WriteLine($"Square of {10} is : {square}");
//            //int[] result=GetOddNumbers(11);
//            //int x = 10;
//            //Console.WriteLine($" x= {x}");
//            //changeValue(ref x);
//            //Console.WriteLine($" x= {x}");
//            //Console.WriteLine(string.Join(',',result));

//             string[] names = {"s1","s2","s3","s4","s5"};
//            int[] marks = { 77, 88, 66, 55, 44 };
//            string topper = GetNameofTopper(names, marks);
//            Console.WriteLine($" The Topper of the class is: { topper}");
//        }

//        public static void SayHello()
//        {
//            Console.WriteLine("Hello, World!");
//        }
//        public static void SayHello(string name)
//        {
//            Console.WriteLine($"Hello, {name}!");
//        }
//        //static int[] GetOddNumbers(int num)
//        //{
//        //    int size = num % 2 == 0 ? num / 2 : num / 2 + 1;
//        //    Console.WriteLine(size);
//        //    int[] arr=new int[size];
//        //    int index = 0;
//        //    for (int i = 0; i < num; i++)
//        //    {
//        //        arr[index++] = i;
//        //    }

//        //    return arr;
//        //

//        static string GetNameofTopper(string[] names, int[] marks)
//        {
//            int max_value = marks.Max();
//            int index = Array.IndexOf(marks, max_value);
//            return names[index];
//        }
        
//        static void changeValue( ref int num)
//        {
//            num++;
//            Console.WriteLine($"num : {num}");

//        }
//        //Method with return types

//        static int GetSquare(int num)
//        {
//            return num * num;
//        }
        
//    }
//    class demoMethod
//    {

//        //static void Main(string[] args)
//        //{
//        //    callMethod();
//        //}
//        public static void callMethod()
//        {
//            Console.WriteLine(" krish");
//        }

//    }

//}