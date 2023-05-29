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
                        string fileText = File.ReadAllText(filePath);

                        string noWhiteSpaceText = RemoveWhiteSpace(fileText);

                        Console.WriteLine("Total characters: " + noWhiteSpaceText);

                        // create array with all letters
                        char[] lettersArray = noWhiteSpaceText.ToCharArray();

                        // create array of unique letters
                        char[] uniqueLettersArray = lettersArray.Distinct().ToArray();

                        // create final array of LetterCount objects
                        List<LetterCount> letterCountList = new List<LetterCount>();

                        // for each letter, loop over the array and count how many there are (add case sensitive toggle)
                        foreach (char letterX in uniqueLettersArray)
                        {
                            int count = 0;
                            foreach (char letterY in lettersArray)
                            {
                                if (letterX == letterY) count++;
                            }

                            // create letter count object and add it to FINAL array (of LetterCount objects)
                            letterCountList.Add(new LetterCount(letterX.ToString(), count));
                        }

                        // then loop over FINAL array each letter count object, and for each one, log letter and count
                        foreach (LetterCount letterCount in letterCountList)
                        {
                            Console.WriteLine($"{letterCount.Letter} ({letterCount.Count})");
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

        public static string RemoveWhiteSpace(string text)
        {
            return text.Replace(" ", "").Replace("\r", "").Replace("\n", "").Replace("\t", "");
        }
    }
}