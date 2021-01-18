using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using InfoProvider;

namespace SongQueryGui
{
    class Program
    {
        static async Task Main(string[] args)
        {
            ISongProvider songProvider = new SongProvider();

            Console.WriteLine("Welcome!");
            Console.Write("Please type the name of a music artist: ");

            string artistName = Console.ReadLine();

            Console.WriteLine("Loading....");

            IEnumerable<String> result = await songProvider.GetSongNames(artistName);
            Console.WriteLine("I found the following songs:");
            
            foreach (var song in result)
            {
                Console.WriteLine(" * " + song);
            }
        }
    }
}