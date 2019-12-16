using System;
using System.Collections.Generic;
using System.Threading;


namespace Tetris
{
    class Tetris
    {
        static void Main(string[] args)
        {


            int interfaceWidth = 62;
            double windowRatio = 1;
            string aspectRatio = new string(' ', 2);
            int[] windowSizeXY = Window.SetWindow(windowRatio, interfaceWidth);
            TitleScreen.Show();
            Audio.Music(Audio.Wav.theme);


            while (true)
            {
                List<Tuple<string, int, int>> tetromino = Generate.NewTetromino();
                var linesToClear = Draw.Game(windowSizeXY[0], windowSizeXY[1], aspectRatio, tetromino);
                Score.ClearLine(windowSizeXY[0], windowSizeXY[1], linesToClear);

            }
        }
    }
}