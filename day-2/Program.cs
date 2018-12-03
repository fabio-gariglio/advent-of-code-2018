using common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace day_2
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = new InputProvider().Get().Result.ToArray();
            
            var countings = input.Select(CountLetters).ToArray();

            var doubles = countings.Count(x => x.Values.Contains(2));
            var triples = countings.Count(x => x.Values.Contains(3));
            
            Console.WriteLine($"What is the checksum for your list of box IDs? {doubles} * {triples} = {doubles * triples}");

            for (int i = 0; i < input.Length; i++)
            {
                for (int j = i + 1; j < input.Length; j++)
                {
                    var source = input[i];
                    var target = input[j];

                    var equalLetters = EqualLetters(source, target);

                    if (equalLetters.Length == (source.Length - 1))
                    {
                        Console.WriteLine($"What letters are common between the two correct box IDs? {equalLetters}");
                    }
                }                
            }
        }

        private static string EqualLetters(string source, string target)
        {
            var result = new StringBuilder(source.Length);
            
            for (var i = 0; i < source.Length; i++)
            {
                if (source[i] != target[i]) continue;
                
                result.Append(source[i]);
            }

            return result.ToString();
        }

        private static IDictionary<char, int> CountLetters(string input)
        {
            return input
                .GroupBy(c => c, (c, enumerable) => new KeyValuePair<char, int>(c, enumerable.Count()))
                .ToDictionary(x => x.Key, x => x.Value);
        }
    }
}