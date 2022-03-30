using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WordUnscrambler
{
    class Program
    {
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

                var continueUnscrambleDecision = string.Empty;
                do
                {
                    Console.WriteLine("Do you want to continue? Y/N");
                    continueUnscrambleDecision = (Console.ReadLine() ?? string.Empty);
                } while (!continueUnscrambleDecision.Equals("Y", StringComparison.OrdinalIgnoreCase) &&
                         !continueUnscrambleDecision.Equals("N", StringComparison.OrdinalIgnoreCase));

                continueUnscramble = continueUnscrambleDecision.Equals("Y", StringComparison.OrdinalIgnoreCase);

            } while (continueUnscramble);
        }

        private static void ExcecuteManualScenario()
        {
        }

        private static void ExecuteFileScenario()
        {
        }
    }
}
