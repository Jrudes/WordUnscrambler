using System;
using System.Collections.Generic;
using System.Linq;
using WordUnscrambler.Data;
using WordUnscrambler.Workers;

namespace WordUnscrambler
{
    class Program
    {
        private static readonly FileReader _fileReader = new FileReader();
        private static readonly WordMatcher _wordMatcher = new WordMatcher();
        private const string wordListFileName = "wordlist.txt";
        static void Main(string[] args)
        {
            bool continueUnscramble = true;
            do
            {

                Console.WriteLine("Please choose an option: 'F' to read a File or 'M' for Manual entry.");
                var option = Console.ReadLine() ?? String.Empty;

                switch (option.ToUpper())
                {

                    case "F":
                        Console.Write("Enter file name: ");
                        ExecuteFileScenario();
                        break;
                    case "M":
                        ExcecuteManualScenario();
                        Console.Write("Enter words seperated with a comma: ");
                        break;
                    default:
                        Console.WriteLine("Chosen option was not recognized.");
                        break;

                }

                var continueDecision = string.Empty;
                do
                {
                    Console.WriteLine("Do you want to continue? Y/N");
                    continueDecision = (Console.ReadLine() ?? string.Empty);
                } while (
                    !continueDecision.Equals("Y", StringComparison.OrdinalIgnoreCase) &&
                    !continueDecision.Equals("N", StringComparison.OrdinalIgnoreCase));

                continueUnscramble = continueDecision.Equals("Y", StringComparison.OrdinalIgnoreCase);

            } while (continueUnscramble);
        }

        private static void ExcecuteManualScenario()
        {
            var manualInput = Console.ReadLine() ?? string.Empty;
            string[] scrambledWords = manualInput.Split(',');
            DisplayMatchedUnscrambled(scrambledWords);
        }
                
        private static void ExecuteFileScenario()
        {
            var fileName = Console.ReadLine() ?? string.Empty;
            string[] scrambledWords = _fileReader.Read(fileName);
            DisplayMatchedUnscrambled(scrambledWords);
        }

        private static void DisplayMatchedUnscrambled(string[] scrambledWords)
        {
            string[] wordList = _fileReader.Read(wordListFileName);

            List<MatchedWord> matchedWords = _wordMatcher.Match(scrambledWords, wordList);

            if(matchedWords.Any())
            {
                foreach(var matchedWord in matchedWords)
                {
                    Console.WriteLine("Match found for {0}: {1}", matchedWord.ScrambledWord, matchedWord.Word);
                }
            }
            else
            {
                Console.WriteLine("No matches found!");
            }
        }
    }
}
