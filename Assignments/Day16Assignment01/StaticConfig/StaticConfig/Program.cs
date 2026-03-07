namespace StaticConfig
{
    internal class Program
    {

        public static class ApplicationConfig
        {
            // Static Properties
            public static string ApplicationName { get; set; }
            public static string Environment { get; set; }
            public static int AccessCount { get; set; }
            public static bool IsInitialized { get; set; }

            static ApplicationConfig()
            {
                ApplicationName = "MyApp";
                Environment = "Development";
                AccessCount = 0;
                IsInitialized = false;

                Console.WriteLine("Static constructor executed");
            }

            public static void Initialize(string appName, string environment)
            {
                ApplicationName = appName;
                Environment = environment;
                IsInitialized = true;
                AccessCount++;
            }

            public static string GetConfigurationSummary()
            {
                AccessCount++;

                return $"Application Name : {ApplicationName}\n" +
                       $"Environment      : {Environment}\n" +
                       $"Access Count     : {AccessCount}\n" +
                       $"Is Initialized   : {IsInitialized}";
            }

            public static void ResetConfiguration()
            {
                ApplicationName = "MyApp";
                Environment = "Development";
                IsInitialized = false;
                AccessCount++;
            }
        }
        static void Main(string[] args)
        {
            Console.WriteLine(ApplicationConfig.ApplicationName);

            ApplicationConfig.Initialize("GymApp", "Production");

            string summary = ApplicationConfig.GetConfigurationSummary();
            Console.WriteLine("\nConfiguration Summary:");
            Console.WriteLine(summary);

            ApplicationConfig.ResetConfiguration();

            string summary2 = ApplicationConfig.GetConfigurationSummary();
            Console.WriteLine("\nAfter Reset:");
            Console.WriteLine(summary2);

            Console.ReadLine();
        }
    }
}

