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

            int interfaceWidth = 40;
            double windowRatio = 1;
            string aspectRatio = new string(' ', 2);
            int[] windowSizeXY = Window.SetWindow(windowRatio, interfaceWidth);

            while (true)
            {
                List<Tuple<string, int, int>> tetromino = Generate.NewTetromino();
                var linesToClear = Draw.Game(windowSizeXY[0], windowSizeXY[1], aspectRatio, tetromino);
                Score.ClearLine(linesToClear);
                Score.SetScore();
                Thread.Sleep(150);
            }
        }
    }
}