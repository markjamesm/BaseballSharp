using System;
using MLBSharp;

namespace MLBSharpCli
{
    class Program
    {
        static void Main(string[] args)
        {
            string todaysDate = DateTime.Now.ToString("MM-dd-yyyy").Replace("-", "/");

            var dates = Endpoints.Matchups(todaysDate);

            foreach (var item in dates)
            {
                Console.WriteLine(item);
            }
        }
    }
}
