using System.Text;
using Yangen;

namespace Yangen.Demo
{
    internal class Program
    {
        public static int SamplesCount { get; set; } = 3;

        static void Main(string[] args)
        {
            while (true)
            {
                Console.Clear();

                foreach (var (index, example, method) in Examples.Search().Select((x, i) => (i, x.Item1, x.Item2)))
                {
                    Console.WriteLine($"{index + 1}. {example.Name}");

                    foreach (var (resultIndex, result) in method(SamplesCount).Select((y, u) => (u, y)))
                    {
                        Console.WriteLine($"\t> {resultIndex + 1}.\t{result}");
                    }
                    Console.WriteLine();
                }

                Console.WriteLine("Press X to close program.");
                Console.WriteLine("Or any other key to update samples.");

                if (Console.ReadKey().KeyChar is 'x')
                {
                    break;
                }
            }
        }
    }
}