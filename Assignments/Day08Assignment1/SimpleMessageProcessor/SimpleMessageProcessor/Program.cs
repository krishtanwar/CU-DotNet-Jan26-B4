namespace SimpleMessageProcessor
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string input;
            string status = string.Empty;
            Console.WriteLine("Enter input in the form abc|xyz");
            input = Console.ReadLine();
            string[] parts = input.Split('|', StringSplitOptions.RemoveEmptyEntries |  StringSplitOptions.TrimEntries);
            string name = parts[0];
            string message = parts[1].ToLower();

            if (!message.Contains("successful"))
            {
                status = "LOGIN FAILED";
            }
            else if(message.Equals("login successful"))
            {
                status = "LOGIN SUCCESS";
            }
            else
            {
                status = "LOGIN SUCCESS (CUSTOM MESSAGE)";
            }

            Console.WriteLine($"User  :{ name}");
            Console.WriteLine($"Message  : { message}");
            Console.WriteLine($"Status  :{status}");

            Console.WriteLine(" ");

        }
    }
}
