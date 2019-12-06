using System;
using System.Collections.Generic;
using System.Threading;

namespace Tetris
{
    class Draw
    {
        static string[,] canvas = new string[0, 0];
        public static List<Tuple<string, int, int>> tetromino = new List<Tuple<string, int, int>>();

        public static void Game(int windowWidth, int windowHeight, string aspectRatio, List<Tuple<string, int, int>> tetromino)
        {
            if (canvas.GetLength(0) == 0)
                canvas = new string[windowWidth, windowHeight];

            Move.ResetMovement(true);
            Move.GravityOn(true);
            Draw.tetromino = tetromino;
            List<Tuple<int, int>> tetrominoScrapeTrail = new List<Tuple<int, int>>();

            int leftEdge = 0;
            int topEdge = 0;
            int rightEdge = windowWidth - 1;
            int bottomEdge = windowHeight - 1;
            int canvasWidth = canvas.GetLength(0);
            int canvasHeight = canvas.GetLength(1);

            while (Move.stopMovementOnTetromino == false)
            {
                var tetrominoToDraw = Move.Tetromino(Draw.tetromino, canvas);
                if (tetrominoToDraw.Count != 0)
                {
                    CommitTetrominoToCanvas(canvas, tetrominoScrapeTrail, tetrominoToDraw);

                    for (int y = 0; y < canvasHeight; y++)
                    {
                        for (int x = 0; x < canvasWidth; x++)
                        {
                            SetBorder(leftEdge, topEdge, rightEdge, bottomEdge, x, y);
                            SetTetrominoColor(canvas, x, y);

                            if (canvas[x, y] != aspectRatio)
                                Console.Write(aspectRatio);

                        }
                        Console.WriteLine();
                    }
                    Console.SetCursorPosition(0, 0);
                }

            }
            Move.stopMovementOnTetromino = false;
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