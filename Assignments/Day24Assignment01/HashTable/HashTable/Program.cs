using System.Collections;

namespace HashTable
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Hashtable employeeTable = new Hashtable();
            employeeTable.Add(101, "Alice");
            employeeTable.Add(102, "Bob");
            employeeTable.Add(103, "Charlie");
            employeeTable.Add(104, "Diana");


            if(employeeTable.ContainsKey(105))
            {
                Console.WriteLine("Id already Exists");
            }
            else
            {
                employeeTable.Add(105, "Edward");
                Console.WriteLine("New employee added with ID 105");
            }

            Console.WriteLine("--------------------");

            string name=employeeTable[102].ToString();
            Console.WriteLine($"The employee at the ID 102 is:{name}");

            Console.WriteLine("--------------------");

            foreach (DictionaryEntry entry in employeeTable)
            {
                Console.WriteLine($"ID: {entry.Key}, Name: {entry.Value}");
            }

            Console.WriteLine("--------------------");

            employeeTable.Remove(103);
            Console.WriteLine("The employee with id 103 is removed");

            Console.WriteLine("--------------------");


            Console.WriteLine($"The remaining employees are: {employeeTable.Count}");
        }
    }
}
