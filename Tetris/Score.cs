using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Tetris
{
    class Score
    {

        public static bool ClearLine(List<int> linesToClear)
        {
            if (linesToClear.Count == 0)
                return false;

            int canvasWidth = Draw.canvas.GetLength(0);
            int moveDownAboveThisLine = linesToClear.Max();

            foreach (var line in linesToClear)
            {
                for (int x = 0; x < canvasWidth; x++)
                    Draw.canvas[x, line] = null;
            }



            for (int y = 0; y < moveDownAboveThisLine; y++)
            {
                for (int x = 0; x < canvasWidth; x++)
                {
                    if (y == 0)
                        Draw.canvas[x, y] = null;

                    else
                        Draw.canvas[x, y] = Draw.canvas[x, y - 1];
                }
            }


            return true;
        }

        public static void SetScore()
        {

        }
    }
}