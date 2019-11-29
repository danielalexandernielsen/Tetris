using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;

namespace Tetris
{
    class Move
    {

        static List<Tuple<string, int, int>> coordinates = new List<Tuple<string, int, int>>();
        static List<Tuple<string, int, int>> coordinatesModified = new List<Tuple<string, int, int>>();
        static int moveX = 0;
        static int gravity = 0;
        static Stopwatch time = Stopwatch.StartNew();

        public static List<Tuple<string, int, int>> Tetromino(string[,] tetromino, int leftEdge, int RightEdge)
        {
            coordinates = GetTetrominoCoordinates(tetromino);
            coordinatesModified.Clear();

            int startXPosition = 12;
            int startYPosition = 1;
            
            if (time.ElapsedMilliseconds % 500 == 0)
            {
                int gravity = Gravity(step: 1, speed: 1);
            }
            

            if (Console.KeyAvailable == true)
            {
                var keyboard = Console.ReadKey(true);
                if (keyboard.Key == ConsoleKey.LeftArrow)
                {
                    moveX -= 1;
                }

                if (keyboard.Key == ConsoleKey.RightArrow)
                {
                    moveX += 1;
                }
            }

            foreach (var block in coordinates)
            {
                var tetrominoType = block.Item1;
                var tetrominoX = block.Item2;
                var tetrominoY = block.Item3;

                coordinatesModified.Add(new Tuple<string, int, int>(
                    tetrominoType,
                    tetrominoX + startXPosition + moveX,
                    tetrominoY + startYPosition + gravity
                    ));
            }

            return coordinatesModified;
        }


        static List<Tuple<string, int, int>> XY = new List<Tuple<string, int, int>>();

        private static List<Tuple<string, int, int>> GetTetrominoCoordinates(string[,] tetromino)
        {

            int tetrominoXLength = tetromino.GetLength(0);
            int tetrominoYLength = tetromino.GetLength(1);

            string empty = " ";
            for (int x = 0; x < tetrominoXLength; x++)
            {
                for (int y = 0; y < tetrominoYLength; y++)
                {
                    string block = tetromino[x, y];

                    if (block != empty)
                        XY.Add(new Tuple<string, int, int>(block, x, y));
                }
            }
            return XY;
        }


        static int steps = 0;
        static int speeds = 0;

        public static int Gravity(int step, int speed)
        {
            steps += step;
            speeds = speed;
            int gravity = steps * speeds;

            return gravity;
        }
    }
}
