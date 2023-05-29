namespace FrequencyAnalysis
{
    internal class Program
    {
        static void Main(string[] args)
        {
            {
                Console.WriteLine("Frequency Analysis application started");

                string? filePath = GetFilePath(args);

                if (filePath != null)
                {
                    Console.WriteLine($"File path: {filePath}");

                    List<string> textLines = new List<string>();

                    textLines = File.ReadAllLines(filePath).ToList();

                    foreach (string line in textLines)
                    {
                        Console.WriteLine($"{line}");
                    }
                }
                else
                {
                    Console.WriteLine("No valid file name provided");
                }
            }
        }

        public static string? GetFilePath(string[] args)
        {
            string fileName;
            string filePath;

            if (args.Length > 0)
            {
                fileName = args[0];
                filePath = @$"C:\Code\FrequencyAnalysis\text-files\{fileName}.txt";
                return filePath;
            }
            else
            {
                return null;
            }
        }
    }
}