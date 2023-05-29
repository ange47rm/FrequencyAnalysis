namespace FrequencyAnalysis
{
    internal class Program
    {
        static void Main(string[] args)
        {
            {
                Console.WriteLine("Frequency Analysis application started");

                string? filePath = GetFilePath(args);

                bool caseSensitivity = DetermineCaseSensitivity(args);

                try
                {
                    if (!String.IsNullOrEmpty(filePath))
                    {
                        // get text from text file
                        string fileText = File.ReadAllText(filePath);

                        // remove white spaces
                        string noWhiteSpaceText = RemoveWhiteSpace(fileText);

                        // create a List with all letters (characters)
                        List<char> lettersArray = noWhiteSpaceText.ToList();

                        // create list of LetterCount objects
                        List<LetterCount> letterCountList = new List<LetterCount>();

                        if (!caseSensitivity)
                        {
                            letterCountList = GenerateLetterCountList(lettersArray);
                        }
                        else
                        {
                            // create array of unique letters (case sensitive, meaning T and t will/may have different counts)
                            List<char> uniqueLettersArray = RemoveDuplicatesCharacters(lettersArray);

                            letterCountList = GenerateLetterCountList(uniqueLettersArray, lettersArray);
                        }

                        // sort LetterCount objects by Count property in a descending order
                        List<LetterCount> sortedByCountList = letterCountList.OrderByDescending(letterCount => letterCount.Count).ToList();

                        // generate final console output 
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

        private static bool DetermineCaseSensitivity(string[] args)
        {
            bool caseSensitivity = true;

            if (args.Length > 1 && args[1].ToLower() == "ci")
            {
                caseSensitivity = false;
            }

            Console.WriteLine("Case sensitive: " + caseSensitivity);
            return caseSensitivity;
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

        private static List<LetterCount> GenerateLetterCountList(List<char> lettersList)
        {
            List<LetterCount> letterCountList = new List<LetterCount>();

            // for each letter, loop over the array and count how many there are (case insensitive)
            foreach (char letterX in lettersList)
            {
                int count = lettersList.Count(letterY => char.ToLowerInvariant(letterX) == char.ToLowerInvariant(letterY));

                if (!letterCountList.Any(letterCountObj => letterCountObj.Letter.ToLower() == letterX.ToString().ToLower()))
                    {
                    letterCountList.Add(new LetterCount(letterX.ToString(), count)); 
                }
            }

            return letterCountList;
        }
    

        private static List<LetterCount> GenerateLetterCountList(List<char> uniqueLettersList, List<char> initialLettersList)
        {
            List<LetterCount> letterCountList = new List<LetterCount>();

            // for each unique letter, loop over the full/initial list of letters and count how many there are (case sensitive)
            foreach (char letterX in uniqueLettersList)
            {
                int count = 0;
                foreach (char letterY in initialLettersList)
                {
                    if (letterX == letterY) count++;
                }

                // create letter count object and add it to letterCountList
                letterCountList.Add(new LetterCount(letterX.ToString(), count));
            }
            return letterCountList;
        }

        private static void ShowFinalOutput(List<LetterCount> letterCountList, int totalCharacters, int? noOfValuesToShow = null)
        {
            Console.WriteLine("Total characters: " + totalCharacters);

            // loop over LetterCount object list and for each one, log letter and count
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

        private static string RemoveWhiteSpace(string text)
        {
            return text.Replace(" ", "").Replace("\r", "").Replace("\n", "").Replace("\t", "");
        }

        private static List<char> RemoveDuplicatesCharacters(List<char> charactersList)
        {
            HashSet<char> uniqueCharacters = new HashSet<char>();
            List<char> result = new List<char>();

            // a HashSet contains unique values but does not see "X" and "x" as a duplicate
            foreach (char letter in charactersList)
            {
                if (!uniqueCharacters.Contains(letter))
                {
                    uniqueCharacters.Add(letter);
                    result.Add(letter);
                }
            }

            return result;
        }
    }
}