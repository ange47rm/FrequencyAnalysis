namespace FrequencyAnalysis
{
    internal class Program
    {
        static void Main(string[] args)
        {
            {
                Console.WriteLine("Frequency Analysis application started");

                string? filePath = GetFilePath(args);

                try
                {
                    if (!String.IsNullOrEmpty(filePath))
                    {
                        List<string> textLines = new List<string>();

                        bool fileExists = File.Exists(filePath);

                        textLines = File.ReadAllLines(filePath).ToList();

                        foreach (string line in textLines)
                        {
                            Console.WriteLine($"{line}");
                        }
                    }
                    else
                    {
                        Console.WriteLine("No valid file name provided. Please provide a valid file name when running the application.");
                    }
                }
                catch (FileNotFoundException)
                {
                    Console.WriteLine($"The file \"{filePath}\" could not be found. Please make sure the file is present and that the input file name is correct.");
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());
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