//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace ConsoleApp1
//{
//    internal class DemoException
//    {
//        static void Main(string[] args)

//        {
            
//            //    int num = 10;
//            //    int square;
//            //    GetSquare(num,out square);
//            //    Console.WriteLine($"Number= {num} and Square= {square}");
//            //Console.WriteLine("Enter your age: ");
//            //    bool isValidAge;
//            //    do
//            //    {
//            //        isValidAge = int.TryParse(Console.ReadLine(), out int age);

//            //        if (isValidAge)
//            //        {
//            //            Console.WriteLine($"Valid age entered: {age}");
//            //        }
//            //        else
//            //        {
//            //            Console.WriteLine("Invalid age entered.");
//            //        }
//            //    } while (!isValidAge);
//            //Console.WriteLine("Enter any service you want to opt for (Treadmill, Weights, Zumba): ");
//            //bool tread = false, weight = false, zumba = false;
//            //string input = Console.ReadLine().ToLower();
//            //string[] services = input.Split(new char[] { ',', ' ' }, StringSplitOptions.RemoveEmptyEntries);
//            //foreach (string service in services)
//            //{
//            //    if (service == "treadmill")
//            //    {
//            //        tread = true;
//            //    }
//            //    else if (service == "weights")
//            //    {
//            //        weight = true;
//            //    }
//            //    else if (service == "zumba")
//            //    {
//            //        zumba = true;
//            //    }
//            //}
//            //double totalBill = GymMembership(tread, weight, zumba);
//            //Console.WriteLine($"Total bill including tax: {totalBill}");
//            //anything(value: 2.12, z: 'c');
//            int y=10;
//            Parameters(y);

//        }static void Parameters(in int x)
//        {
//            Console.WriteLine(x);                                        //in means only read only value
//        }
//        static void GetSquare(int x,out int square) {

//            square=Convert.ToInt32(Math.Pow(x,2));          // convert.int32 is used to convert double to int
//        }               // we can also use int with out function but we have to return another value
//        //Refactoring means to optimize code
//        //DRY-> Don't repeat yourself

//        static double GymMembership(bool tread,bool weight,bool zumba)
//        {
//            double bill = 1000.0;
            

//            if(tread|| weight || zumba)
//            {
//                if (tread) bill += 300.0;
                
//                if (weight)bill += 500.0;

//                if (zumba) bill += 250.0;
                
         
//            }
//            else
//            {
//                bill += 200;    // if no add on is selected
//            }
//            bill += bill * 0.05; // tax calculation
//            return bill;
//        }

//        static void anything(int num=2, int x=3, char y='a', char z='b', double value=2.23) {
        
//        }
//        //printLine(ch:'$');  -> it allows us to pass arguments in any manner
//        //printLine(ch:'$',num:60) -> we can pass arguments at any place irrespective of its declaration

//        //static void Print(char ch, int num)
//        //{

//        //    if (ch == ' ' && num == null)
//        //    {
//        //        for (int i = 0; i < 40; i++)
//        //        {
//        //            Console.WriteLine("-");
//        //        }
//        //    }

//        //    else if (num == null)
//        //    {
//        //        char input = ch;
//        //        for (int i = 0; i <40; i++)

//        //        {
//        //            Console.WriteLine(input);
//        //        }

//        //    }
//        //    else
//        //    {
//        //        char input = ch;
//        //        int time = num;
//        //        for (int i = 0; i < num; i++)

//        //        {
//        //            Console.WriteLine(input);
//        //        }
//        //    }

//    }
//}
