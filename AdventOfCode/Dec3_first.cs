using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace AdventOfCode
{
    internal class Dec3_first
    {

        public string Input { get; set; } = "467..114..\r\n...*......\r\n..35..633.\r\n......#...\r\n617*......\r\n.....+.58.\r\n..592.....\r\n......755.\r\n...$.*....\r\n.664.598..";

        // sum all numbers in the string where the number is adjacent to a symbol that are not dots. This means also that a number can be adjacent vertically, horizontally and diagonally. For example is 467 adjacent to * in the next line. 664 for is adjacent to $ and 58 is adjacent to +. The sum of these numbers is 467 + 664 + 58 = 1189

        public Dec3_first()
        {
            Console.WriteLine("Dec3_first");
            
            SumAdjacentNumbers();
            Console.ReadLine();
        }


        private void SumAdjacentNumbers()
        {
              // split the string into lines
            var lines = Input.Split(new string[] { "\r\n" }, StringSplitOptions.None).ToList();
            var j = 0;

            // loop through the lines
            foreach (string line in lines)
            {
                // Get the numbers from the line and put them in a list
                var numberList = line.Split(new char[] {'.'}, StringSplitOptions.RemoveEmptyEntries).ToList();

                // Remove the symbol characters that are not numbers.
                var cleanNumberList = numberList
                    .Select(x => GetNumbers(x))
                    .Where(x => x != "") 
                    .ToList();

                // Get a list of symbols and their location in the string
                var symbolList = lines
                    //.Select(x => x != "." || !Regex.IsMatch(x, @"^\d+$"))
                    .Select(x => Regex.Replace(x, "[0-9]", ""))
                    .Select(x => x.Replace(".", ""))
                    //.Select((c, index) => new SymbolLocation { LineNumber = index, Index = index, Symbol = c.ToString() })
                    .ToList();

                var symbolLocationsList = lines
                    .Select((c, index) => new SymbolLocation { LineNumber = index, Index = Array.IndexOf(c.ToCharArray(), symbolList[index]), Symbol = symbolList[index].ToString() })
                    .ToList();


                foreach (string number in cleanNumberList)
                {
                    Console.WriteLine(number);
                }   


                j++;
            }


        }

        private static string GetNumbers(string input)
        {
            return new string(input.Where(c => char.IsDigit(c)).ToArray());
        }

        private bool IsDigit(string input)
        {
            return input.Any(c => char.IsDigit(c));
        }


    }
}

internal class SymbolLocation
{
    public int LineNumber { get; set; }
    public int Index { get; set; }
    public string Symbol { get; set; }
}
