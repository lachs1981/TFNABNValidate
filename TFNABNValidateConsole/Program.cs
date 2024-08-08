using TFNABNValidate;

namespace TFNABNValidateConsole
{
    internal class Program
    {
        static void Main(string[] args)
        {
            if (args.Length != 2)
            {
                Console.WriteLine("please enter 2 arguments in the form tfnabn <tfn|abn> <8 or 9 digit number for TFNs or 11 digits for ABNs>");
                return;
            }

            string args0 = args[0];
            string args1 = args[1];
            if (args0.ToLower() == "tfn" && (args1.Length == 8 || args1.Length == 9))
            {
                if (args1.IsValidTFN())
                {
                    Console.WriteLine("Valid TFN");
                    return;
                }
                Console.WriteLine("Invalid TFN");
                return;
            }
            if (args0.ToLower() == "abn" && args1.Length == 11)
            {
                if (args1.IsValidABN())
                {
                    Console.WriteLine("Valid ABN");
                    return;
                }
                Console.WriteLine("Invalid ABN");
                return;
            }
            Console.WriteLine("Invalid input");
        }
    }
}
