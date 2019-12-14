using System.Collections.Generic;

namespace Tetris
{
    class Score
    {

        public static bool ClearLine(int windowWidth, int windowHeight, List<int> linesToClear)
        {
            if (linesToClear.Count == 0)
                return false;

            int canvasWidth = Draw.canvas.GetLength(0);
            int canvasHeight = Draw.canvas.GetLength(1);
            int borderWidth = 2;
            string[,] canvasTemp = new string[windowWidth, windowHeight];

            foreach (var line in linesToClear)
            {
                for (int x = borderWidth; x < canvasWidth - borderWidth; x++)
                {
                    Draw.canvas[x, line] = null;
                }


                //for (int i = canvasHeight - 1; i > 0; i++)
                //{
                //    for (int j = 0; j < canvasWidth; j++)
                //    {
                //        Draw.canvas[i, j] = Draw.canvas[i - 1, j];
                //    }
                //}

            }
            return true;
        }

        public static void SetScore()
        {

        }
    }
}