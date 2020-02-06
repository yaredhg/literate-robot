using ArtimeticExpressionCaclulator;
using System;

namespace ArtimeticExpressionsCaclulator
{
    class Program
    {
        static void Main(string[] args)
        {

            string input;
            Console.WriteLine("Enter Arthimetic expresions line by line (press CTRL+Z to exit):");
            Console.WriteLine();
            do
            {
                Console.Write("   ");
                input = Console.ReadLine();
                if (input != null)
                {
                    try
                    {
                        ExpressionsProcessor processor = new ExpressionsProcessor(new Operands());
                        var fraction = processor.Process(input);
                        Console.WriteLine("=" + fraction);
                    }
                    catch(Exception ex)
                    {
                        //log
                        Console.WriteLine("Invalid input");
                    }
                    
                }
                   
            } while (input != null);

            
       
        }
    }
}
