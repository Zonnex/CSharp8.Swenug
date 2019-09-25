using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Demo
{
    class Program
    {
        static async Task Main(string[] args)
        {
            await foreach(int number in NumbersAsync())
            {
                Console.WriteLine(number);
            }
        }

        static async IAsyncEnumerable<int> NumbersAsync()
        {
            var random = new Random();

            for (int i = 0; i < 10; i++)
            {
                await Task.Delay(random.Next(1000, 3000));
                for (int j = 0; j < 10; j++)
                {
                    int value = random.Next();
                    yield return value;    
                }
            }
        }
    }
}
