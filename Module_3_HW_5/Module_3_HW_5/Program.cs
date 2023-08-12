using System.Diagnostics;

namespace Module_3_HW_5
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            string result = await ExecuteAsyncMethods();
            Console.WriteLine(result);
        }

        public static async Task<string> ReadAsync(string filename)
        {
            using (StreamReader reader = new StreamReader(filename))
            {
                return await reader.ReadToEndAsync();
            }
        }

        public static async Task<string> ExecuteAsyncMethods()
        {
            Task<string> helloTask = ReadAsync("hello.txt");
            Task<string> worldTask = ReadAsync("world.txt");

            await Task.WhenAll(helloTask, worldTask);

            string helloText = await helloTask;
            string worldText = await worldTask;

            return $"{helloText} {worldText}";
        }
    }
}