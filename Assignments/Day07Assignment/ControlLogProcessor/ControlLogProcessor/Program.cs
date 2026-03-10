namespace ControlLogProcessor
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter Input");
                string input = Console.ReadLine();
                string[] parts = input.Split('|');

                if (parts.Length != 5)
                {
                    Console.WriteLine("INVALID ACCESS LOG");
                    return;
                }

                // Validate GateCode
                string gateCode = parts[0];
                if (gateCode.Length != 2 || !char.IsLetter(gateCode[0]) || !char.IsDigit(gateCode[1]))
                {
                    Console.WriteLine("INVALID ACCESS LOG");
                    return;
                }

                // Validate UserInitial
                string userInitialStr = parts[1];
                if (userInitialStr.Length != 1 || !char.IsUpper(userInitialStr[0]))
                {
                    Console.WriteLine("INVALID ACCESS LOG");
                    return;
                }

                // Validate AccessLevel
                byte accessLevel;
                if (!byte.TryParse(parts[2], out accessLevel) || accessLevel < 1 || accessLevel > 7)
                {
                    Console.WriteLine("INVALID ACCESS LOG");
                    return;
                }

                // Validate IsActive
                bool isActive;
                if (!bool.TryParse(parts[3], out isActive))
                {
                    Console.WriteLine("INVALID ACCESS LOG");
                    return;
                }

                // Validate Attempts
                byte attempts;
                if (!byte.TryParse(parts[4], out attempts) || attempts > 200)
                {
                    Console.WriteLine("INVALID ACCESS LOG");
                    return;
                }

                // Business Logic
                string status;
                if (!isActive)
                {
                    status = "ACCESS DENIED – INACTIVE USER";
                }
                else if (attempts > 100)
                {
                    status = "ACCESS DENIED – TOO MANY ATTEMPTS";
                }
                else if (accessLevel >= 5)
                {
                    status = "ACCESS GRANTED – HIGH SECURITY";
                }
                else
                {
                    status = "ACCESS GRANTED – STANDARD";
                }

            
            Console.WriteLine($"{"Gate".PadRight(10)}: {gateCode}");
            Console.WriteLine($"{"User".PadRight(10)}: {userInitialStr}");
            Console.WriteLine($"{"Level".PadRight(10)}: {accessLevel}");
            Console.WriteLine($"{"Attempts".PadRight(10)}: {attempts}");
            Console.WriteLine($"{"Status".PadRight(10)}: {status}");
        }
        }
    }
   
