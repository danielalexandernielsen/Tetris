using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace Tetris
{
    class Draw
    {

        public static void Game(int windowWidth, int windowHeight, int aspectRatio, string[,] tetromino, int FPS)
        {
            string[,] canvas = new string[windowWidth, windowHeight];
            List<Tuple<int, int>> tetrominoToScrape = new List<Tuple<int, int>>();

            int leftEdge = 0;
            int topEdge = 0;
            int rightEdge = windowWidth - 1;
            int bottomEdge = windowHeight - 1;
            int moveX = 0;


            while (true)
            {
                var tetrominoToDraw = Move.Tetromino(tetromino, leftEdge, rightEdge);
                CommitTetrominoToCanvas(canvas, tetrominoToScrape, tetrominoToDraw);

                for (int y = 0; y < canvas.GetLength(1); y++)
                {
                    for (int x = 0; x < canvas.GetLength(0); x++)
                    {
                        SetBorder(leftEdge, topEdge, rightEdge, bottomEdge, x, y);
                        SetTetrominoColor(canvas, x, y);

                        Console.Write(new string(' ', aspectRatio));
                    }
                    Console.WriteLine();
                }
                Console.SetCursorPosition(0, 0);
                Thread.Sleep(960 / FPS);
            }
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
            switch (canvas[x, y])
            {
                case "L":
                    Console.BackgroundColor = ConsoleColor.DarkRed;
                    break;

                case "J":
                    Console.BackgroundColor = ConsoleColor.Blue;
                    break;

                case "Z":
                    Console.BackgroundColor = ConsoleColor.Red;
                    break;

                case "S":
                    Console.BackgroundColor = ConsoleColor.Green;
                    break;

                case "T":
                    Console.BackgroundColor = ConsoleColor.Magenta;
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
