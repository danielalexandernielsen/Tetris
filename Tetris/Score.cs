using System.Collections.Generic;

namespace Tetris
{
    class Score
    {

        public enum Points { tetrominoPlaced, LinesCleared1, LinesCleared2, LinesCleared3, LinesCleared4 };

        public static int playerScore = 0;

        public static bool ClearLine(int windowWidth, int windowHeight, List<int> linesToClear)
        {
            if (linesToClear.Count == 0)
                return false;

            int canvasWidth = Draw.canvas.GetLength(0);
            int canvasHeight = Draw.canvas.GetLength(1);
            int borderWidth = 2;
            int borderHeight = 2;

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

            switch (linesToClear.Count)
            {
                case 1:
                    SetScore(Points.LinesCleared1);
                    break;

                case 2:
                    SetScore(Points.LinesCleared2);
                    break;

                case 3:
                    SetScore(Points.LinesCleared3);
                    break;

                case 4:
                    SetScore(Points.LinesCleared4);
                    break;
            }

            Audio.Effect(Audio.Wav.goodJob);

            return true;
        }

        public static void SetScore(Points type)
        {
            switch (type)
            {
                case Points.tetrominoPlaced:
                    playerScore += 11;
                    break;

                case Points.LinesCleared1:
                    playerScore += 40;
                    break;

                case Points.LinesCleared2:
                    playerScore += 100;
                    break;

                case Points.LinesCleared3:
                    playerScore += 300;
                    break;

                case Points.LinesCleared4:
                    playerScore += 1200;
                    break;
            }
        }
    }
}