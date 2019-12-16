using System;
using System.Collections.Generic;

namespace Tetris
{
    class Draw
    {
        public static string[,] canvas = new string[0, 0];
        public static List<Tuple<string, int, int>> tetromino = new List<Tuple<string, int, int>>();
        static bool isCanvasEmpty = true;
        static List<int> linesToBeScored = new List<int>();

        public static List<int> Game(int windowWidth, int windowHeight, string aspectRatio, List<Tuple<string, int, int>> tetromino)
        {

            if (isCanvasEmpty == true)
            {
                canvas = new string[windowWidth, windowHeight];
                isCanvasEmpty = false;
            }

            Move.ResetMovement(true);
            Move.Gravity(true);
            Draw.tetromino = tetromino;
            List<Tuple<int, int>> tetrominoScrapeTrail = new List<Tuple<int, int>>();

            int leftEdge = 0;
            int topEdge = 0;
            int rightEdge = windowWidth - 1;
            int bottomEdge = windowHeight - 1;
            int canvasWidth = canvas.GetLength(0);
            int canvasHeight = canvas.GetLength(1);

            int countBlocksInLine = 0;
            int countFullLines = 0;

            while (Move.stopMovementOnTetromino == false)
            {
                var tetrominoToDraw = Move.Tetromino(Draw.tetromino, canvas);

                if (tetrominoToDraw.Count != 0)
                {
                    linesToBeScored.Clear();
                    CommitTetrominoToCanvas(canvas, tetrominoScrapeTrail, tetrominoToDraw);

                    Console.WriteLine();

                    for (int y = 0; y < canvasHeight; y++)
                    {
                        Console.BackgroundColor = ConsoleColor.Black;
                        Console.Write("                       ");

                        for (int x = 0; x < canvasWidth; x++)
                        {
                            SetBorder(leftEdge, topEdge, rightEdge, bottomEdge, x, y);
                            SetTetrominoColor(canvas, x, y);
                            Console.Write("  ");

                            if (canvas[x, y] != null)
                                countBlocksInLine++;
                        }

                        if (countBlocksInLine == 10)
                        {
                            countFullLines++;
                            linesToBeScored.Add(y);
                        }
                        countBlocksInLine = 0;

                        Console.BackgroundColor = ConsoleColor.Black;
                        Console.Write("   ");

                        if (y == 1)
                            Console.Write("SCORE:");
                        if (y == 2)
                            Console.Write(Score.playerScore);

                        Console.WriteLine();
                    }


                    Console.SetCursorPosition(0, 0);
                }
            }
            Move.stopMovementOnTetromino = false;
            return linesToBeScored;
        }

        private static void CommitTetrominoToCanvas(string[,] canvas, List<Tuple<int, int>> tetrominoToScrape, List<Tuple<string, int, int>> tetrominoToDraw)
        {
            if (tetrominoToScrape.Count > 0)
            {
                foreach (var block in tetrominoToScrape)
                {
                    int xPrevious = block.Item1;
                    int yPrevious = block.Item2;
                    canvas[xPrevious, yPrevious] = null;
                }
                tetrominoToScrape.Clear();
            }

            foreach (var block in tetrominoToDraw)
            {
                string tetrominoType = block.Item1;
                int x = block.Item2;
                int y = block.Item3;

                tetrominoToScrape.Add(new Tuple<int, int>(x, y));
                canvas[x, y] = tetrominoType;
            }
        }

        private static void SetBorder(int leftEdge, int topEdge, int rightEdge, int bottomEdge, int x, int y)
        {
            if (x == leftEdge || x == rightEdge || y == topEdge || y == bottomEdge)
                Console.BackgroundColor = ConsoleColor.Gray;

            else if (x == leftEdge + 1 || x == rightEdge - 1)
                Console.BackgroundColor = ConsoleColor.DarkGray;

            else
                Console.BackgroundColor = ConsoleColor.Black;
        }

        private static void SetTetrominoColor(string[,] canvas, int x, int y)
        {
            string tetrominoType = canvas[x, y];

            if (tetrominoType != null)
                tetrominoType = Convert.ToString(tetrominoType[0]);

            switch (tetrominoType)
            {
                case "L":
                    Console.BackgroundColor = ConsoleColor.DarkBlue;
                    break;

                case "J":
                    Console.BackgroundColor = ConsoleColor.DarkYellow;
                    break;

                case "Z":
                    Console.BackgroundColor = ConsoleColor.Green;
                    break;

                case "S":
                    Console.BackgroundColor = ConsoleColor.DarkRed;
                    break;

                case "T":
                    Console.BackgroundColor = ConsoleColor.DarkMagenta;
                    break;

                case "O":
                    Console.BackgroundColor = ConsoleColor.Yellow;
                    break;

                case "I":
                    Console.BackgroundColor = ConsoleColor.Cyan;
                    break;
            }
        }
    }
}