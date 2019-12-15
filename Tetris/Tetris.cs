using System;
using System.Collections.Generic;
using System.Threading;


namespace Tetris
{
    class Tetris
    {
        static void Main(string[] args)
        {
            Console.Title = "Tetris";
            Console.CursorVisible = false;

            Audio.Music(Audio.Wav.theme);

            int interfaceWidthRHS = 40;
            double windowRatio = 1;
            string aspectRatio = new string(' ', 2);
            int[] windowSizeXY = Window.SetWindow(windowRatio, interfaceWidthRHS);


            while (true)
            {
                List<Tuple<string, int, int>> tetromino = Generate.NewTetromino();
                var linesToClear = Draw.Game(windowSizeXY[0], windowSizeXY[1], aspectRatio, tetromino);
                var playerClearedLines = Score.ClearLine(windowSizeXY[0], windowSizeXY[1], linesToClear);
                // Score.SetScore();
            }
        }
    }
}