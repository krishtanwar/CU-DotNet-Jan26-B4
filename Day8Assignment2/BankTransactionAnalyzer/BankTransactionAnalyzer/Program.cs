namespace BankTransactionAnalyzer
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter input in the form of id#name#cash deposit/withdrawal/transfer : ");
            string input=Console.ReadLine();
            string[] parts = input.Split('#',StringSplitOptions.RemoveEmptyEntries);
            string id=parts[0];
            string[] name=parts[1].Split(' ',StringSplitOptions.RemoveEmptyEntries);
            string name2=string.Join(" ",name);
            string[] narration1 = parts[2].Split(' ',StringSplitOptions.RemoveEmptyEntries);
            string narration = string.Join(' ', narration1);
            string transactionType=parts[2].ToLower();
            string category=string.Empty;

            if (transactionType.Contains("deposit") || transactionType.Contains("transfer") || transactionType.Contains("withdrawal"))
            {
                if (transactionType.Equals("cash deposit successful")|| transactionType.Equals("cash transfer successful")|| transactionType.Equals("cash withdrawal successful"))
                {
                    category = "STANDARD TRANSACTION";
                }
                else
                {
                    category = "CUSTOM TRANSACTION";
                }
            }
            else category = "NON-FINANCIAL TRANSACTION";




            Console.WriteLine($"Transaction ID : {id,4}");
            Console.WriteLine($"Account Holder : {name2,4}");
            Console.WriteLine($"Narration      : {narration,4}");
            Console.WriteLine($"Category       : {category,4}");

        }
    }
}
