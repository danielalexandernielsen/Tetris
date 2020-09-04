using System;
using System.Collections.Generic;
using System.Text;

namespace Tetris
{
    class TitleScreen
    {
        public static void Show()
        {
            Console.Title = "Tetris";
            Console.CursorVisible = false;

            Audio.Music(Audio.Wav.start);

            Console.WriteLine();
            Console.WriteLine(@"       ___________________________________________ .___   _________       ");
            Console.WriteLine(@"       \__    ___/\_   _____/\__    ___/\______   \|   | /   _____/       ");
            Console.WriteLine(@"         |    |    |    __)_   |    |    |       _/|   | \_____  \        ");
            Console.WriteLine(@"         |    |    |        \  |    |    |    |   \|   | /        \       ");
            Console.WriteLine(@"         |____|   /_______  /  |____|    |____|_  /|___|/_______  /       ");
            Console.WriteLine(@"                          \/                    \/              \/        ");
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine(@"                          - PRESS SPACE TO START -                         ");
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();

            while (true)
            {
                var keyboard = Console.ReadKey(true);

                if (keyboard.Key == ConsoleKey.Spacebar)
                {
                    Console.Clear();
                    break;
                }
            }
        }
    }
}
