namespace LineMethod
{
    internal class Program
    {
        public static void DisplayLine()
        {
            for (int i = 0; i < 40; i++)
            {
                Console.Write("-");
            }
            Console.WriteLine();
        }

        public static void DisplayLine(char ch)
        {
            for (int i = 0; i < 40; i++)
            {
                Console.Write(ch);
            }
            Console.WriteLine();
        }

      
        public static void DisplayLine(char ch, int count)
        {
            for (int i = 0; i < count; i++)
            {
                Console.Write(ch);
            }
            Console.WriteLine();
        }

        
        static void Main(string[] args)
        {
            DisplayLine();          
            DisplayLine('+');       
            DisplayLine('$', 60);
        }
    }
}
