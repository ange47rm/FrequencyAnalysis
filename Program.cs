namespace FrequencyAnalysis
{
    internal class Program
    {
        static void Main(string[] args)
        {
            {
                Console.WriteLine("Frequency Analysis application started");

                if (args.Length > 0)
                {
                    string arg = args[0];
                    Console.WriteLine("Args received: " + arg);
                }
                else
                {
                    Console.WriteLine("No arg received.");
                }
            }
        }
    }
}