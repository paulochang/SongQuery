using System;
using System.Threading.Tasks;
using InfoProvider;

namespace SongQueryGui
{
    internal class Program
    {
        private static async Task Main(string[] args)
        {
            ISongProvider songProvider = new SongProvider();

            Console.WriteLine("Welcome!");
            Console.Write("Please type the name of a music artist: ");

            var artistName = Console.ReadLine();

            Console.WriteLine("Loading....");

            var result = await songProvider.GetSongNames(artistName);
            Console.WriteLine("I found the following songs:");

            foreach (var song in result) Console.WriteLine(" * " + song);
        }
    }
}