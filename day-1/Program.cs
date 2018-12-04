using System;
using System.Collections.Generic;
using System.Linq;
using common;

namespace day_1
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = new InputProvider().Get(int.Parse).Result.ToArray();
            var frequencies = new HashSet<int>();

            var index = 0;
            var frequency = 0;
            
            do
            {
                frequencies.Add(frequency);
                frequency += input[index];
                
                if (frequencies.Contains(frequency))
                {
                    Console.WriteLine($"What is the first frequency your device reaches twice? {frequency}");
                    break;
                }
                
                
                index++;
                if (index >= input.Length) index = 0;
            } while (true);
            
            var result = input.Sum();
            
            Console.WriteLine($"Starting with a frequency of zero, what is the resulting frequency after all of the changes in frequency have been applied? {result}");
        }
    }
}