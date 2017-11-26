using System;
using System.IO;
using System.Text;

namespace FrequencyTest
{
    static class Program
    {
        private static void Main()
        {
            var c = new int[char.MaxValue];
            var s = File.ReadAllText("6.txt", Encoding.Default);
            foreach (char t in s.ToLower())
                c[t]++;

            for (var i = 0; i < char.MaxValue; i++)
            {
                if (c[i] > 0 &&
                    char.IsLetterOrDigit((char)i))
                {
                    Console.WriteLine("Letter: {0}  Frequency: {1}",
                        (char)i,
                        c[i]);
                }
            }
            Console.ReadKey();
        }
    }
}
