namespace FrequencyAnalysis
{
    internal class Program
    {
        static void Main(string[] args)
        {
            {
                Console.WriteLine("### Frequency Analysis application started ###");

                string? filePath = GetFilePath(args);

                bool caseSensitivity = DetermineCaseSensitivity(args);

                try
                {
                    if (!String.IsNullOrEmpty(filePath))
                    {
                        string fileText = File.ReadAllText(filePath);

                        string noWhiteSpaceText = RemoveWhiteSpace(fileText);

                        List<char> lettersList = noWhiteSpaceText.ToList();

                        List<LetterCount> letterCountList = new List<LetterCount>();

                        List<char> uniqueLettersList = RemoveDuplicatesCharacters(lettersList); 

                        if (!caseSensitivity)
                        {
                            List<char> lettersListLowerCase = ConvertCharListToLowerCase(lettersList);

                            letterCountList = GenerateLetterCountList(uniqueLettersList, lettersListLowerCase);
                        }
                        else
                        {
                            letterCountList = GenerateLetterCountList(uniqueLettersList, lettersList);
                        }

                        List<LetterCount> sortedByCountList = letterCountList.OrderByDescending(letterCount => letterCount.Count).ToList();

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

        private static string? GetFilePath(string[] args)
        {
            string fileName;
            string projectFolder = Path.GetFullPath(Path.Combine(Directory.GetCurrentDirectory(), "..\\..\\..\\"));
            string filePath;

            if (args.Length > 0)
            {
                fileName = args[0];
                filePath = Path.Combine(projectFolder, "text-files", $"{fileName}.txt");
                return filePath;
            }
            else
            {
                return null;
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

        private static string RemoveWhiteSpace(string text)
        {
            return text.Replace(" ", "").Replace("\r", "").Replace("\n", "").Replace("\t", "");
        }

        private static List<char> RemoveDuplicatesCharacters(List<char> charactersList)
        {
            HashSet<char> uniqueCharacters = new HashSet<char>();
            List<char> result = new List<char>();

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

        private static List<char> ConvertCharListToLowerCase(List<char> lettersList)
        {
            List<char> lettersListLowerCase = new List<char>();

            foreach (char letter in lettersList)
            {
                lettersListLowerCase.Add(Char.ToLower(letter));
            }

            return lettersListLowerCase;
        }

        private static List<LetterCount> GenerateLetterCountList(List<char> uniqueLettersList, List<char> initialLettersList)
        {
            List<LetterCount> letterCountList = new List<LetterCount>();

            foreach (char letterX in uniqueLettersList)
            {
                int count = 0;
                foreach (char letterY in initialLettersList)
                {
                    if (letterX == letterY) count++;
                }

                letterCountList.Add(new LetterCount(letterX.ToString(), count));
            }
            return letterCountList;
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
    }
}