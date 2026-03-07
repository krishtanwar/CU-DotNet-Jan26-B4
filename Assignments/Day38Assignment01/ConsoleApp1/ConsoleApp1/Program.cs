namespace ConsoleApp1
{
    internal class Program
    {
        static string change(string input)
        {
            string result=string.Empty;
            string vowels = "aeioua";
            for(int i=0;i<input.Length;i++)
            {

                if (vowels.Contains(input[i]))
                {
                    int index = vowels.IndexOf(input[i]);

                    result += (vowels[index + 1]);
                }
                else if (input[i] == 'z') result += 'b';
                else
                {
                    result += (vowels.Contains((char)(input[i] + 1)) ? (char)(input[i] + 2) : (char)(input[i] + 1));
                }
                
            }


            return result;
        }
        static void Main(string[] args)
        {
            Console.WriteLine("Enter input: ");
            string input = Console.ReadLine();
            string result=change(input);
            Console.WriteLine(result);
        }
    }
}
