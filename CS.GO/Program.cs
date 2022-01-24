using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Net.Mime;
using System.Threading.Channels;
using System.Threading.Tasks;

namespace CS.GO
{
    internal class Program
    {
        public static async Task Main(string[] args)
        {
           await Game.StartGame();
        }

        public static bool IsSuccessful(int maxValue)

        {
            Random rnd = new Random();

            return rnd.Next(0, maxValue) == 2;
        }

    }
}
