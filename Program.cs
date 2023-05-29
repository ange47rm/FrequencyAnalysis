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

                        // create array with all letters
                        List<char> lettersArray = noWhiteSpaceText.ToList();

                        // create array of unique letters
                        List<char> uniqueLettersArray = RemoveDuplicatesCharacters(lettersArray);

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

                        List<LetterCount> sortedByCountList = letterCountList.OrderByDescending(letterCount => letterCount.Count).ToList();

                        // then loop over FINAL array each letter count object, and for each one, log letter and count
                        ShowFinalOutput(sortedByCountList, noWhiteSpaceText.Length, 10);
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

        private static void ShowFinalOutput(List<LetterCount> letterCountList, int totalCharacters, int? noOfValuesToShow = null)
        {
            Console.WriteLine("Total characters: " + totalCharacters);

            if (noOfValuesToShow != null)
            {
                for (int i = 0; i < noOfValuesToShow; i++)
                {
                    Console.WriteLine($"{letterCountList[i].Letter} ({letterCountList[i].Count})");
                }
            }
            else
            {
                foreach (LetterCount letterCount in letterCountList)
                {
                    Console.WriteLine($"{letterCount.Letter} ({letterCount.Count})");
                }
            }

        }

        private static string? GetFilePath(string[] args)
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

        private static string RemoveWhiteSpace(string text)
        {
            return text.Replace(" ", "").Replace("\r", "").Replace("\n", "").Replace("\t", "");
        }

        private static List<char> RemoveDuplicatesCharacters(List<char> characters)
        {
            // a HashSet contains unique values but does not see "X" and "x" as a duplicate
            HashSet<char> uniqueChars = new HashSet<char>();
            List<char> result = new List<char>();

            foreach (char letter in characters)
            {
                if (!uniqueChars.Contains(letter))
                {
                    uniqueChars.Add(letter);
                    result.Add(letter);
                }
            }

            return result;
        }
    }
}