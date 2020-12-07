using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace AddingStringNumber
{
    class Program
    {
        static void Main(string[] args)
        {
            while(true)
            {
                Console.WriteLine("Type number !");
                var str = Console.ReadLine();

                List<int> numberToAdd = new List<int>();

                if (string.IsNullOrWhiteSpace(str.Trim()) || str.Trim() == "\"\"")
                {
                    Console.WriteLine($"Sum of {str} is  : { ManageData.Add(numberToAdd) }");
                    if (Console.ReadLine() == "-1")
                    {
                        return;
                    }
                    continue;
                }

                if (ManageData.validateNumberFormat(str.Trim()))
                {

                        numberToAdd = ManageData.extractAddingNumber(str);

                        if (numberToAdd.Count == 0)
                        {
                            Console.WriteLine("Invalid delimiter");
                            continue;
                        }

                        List<int> negativeNumberList = new List<int>();
                        if (numberToAdd.Count > 0)
                        {
                            negativeNumberList = numberToAdd.Where(x => x < 0).ToList();
                        }

                        if (negativeNumberList.Count > 0)
                        {
                            var negativeValues = string.Join(",", negativeNumberList.Select(n => n.ToString()).ToArray());
                            Console.WriteLine($"Negatives not allowed : {negativeValues}");
                            continue;
                        }
                        Console.WriteLine($"Sum of {str} is  : { ManageData.Add(numberToAdd) }");
                }
                else
                {
                    Console.WriteLine("Invalid input!");
                }

                Console.ReadLine();
            }
        }

    }
}
