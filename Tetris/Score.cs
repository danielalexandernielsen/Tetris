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
            int borderHeight = 2;

            Audio.Effect(Audio.Wav.goodJob);

            foreach (var line in linesToClear)
            {
                for (int x = borderWidth; x < canvasWidth - borderWidth; x++)
                {
                    Draw.canvas[x, line] = null;
                }

                for (int y = line; y > borderHeight; y--)
                {
                    for (int x = borderWidth; x < canvasWidth - borderWidth; x++)
                    {
                        Draw.canvas[x, y] = Draw.canvas[x, y - 1];
                    }
                }
            }

            return true;
        }

        public static void SetScore()
        {

        }
    }
}