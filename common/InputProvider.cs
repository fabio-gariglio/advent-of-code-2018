using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace common
{
    public class InputProvider
    {
        private readonly string _path;

        public InputProvider(string path = "input.txt")
        {
            _path = path;
        }

        public async Task<IEnumerable<T>> Get<T>(Func<string, T> converter)
        {
            var input = await Get();

            return input.Select(converter);
        }

        public async Task<IEnumerable<string>> Get()
        {
            using (var streamReader = new StreamReader("input.txt"))
            {
                var content = await streamReader.ReadToEndAsync();

                var input = content.Split(new[] {'\n', '\r'}, StringSplitOptions.RemoveEmptyEntries);
                
                return input;
            }
        }
    }
}