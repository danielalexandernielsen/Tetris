using System;
using System.Collections.Generic;

namespace Tetris
{
    class Tetris
    {
        static void Main(string[] args)
        {
            Console.Title = "Tetris";
            Console.CursorVisible = false;

            int interfaceWidth = 60;
            double windowRatio = 1.5;
            int aspectRatio = 2;
            int[] windowSizeXY = Window.setWindow(windowRatio, interfaceWidth);
            
            while (true)
            {
                List<Tuple<string, int, int>> tetromino = Generate.NewTetromino();
                Draw.Game(windowSizeXY[0], windowSizeXY[1], aspectRatio, tetromino);
            }

            Console.ReadLine();
            // Console.Beep();
        }
    }
}
