using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Timers;

namespace Tetris
{
    class Move
    {

        static List<Tuple<string, int, int>> movement = new List<Tuple<string, int, int>>();
        static int moveX = 0;

        public static List<Tuple<string, int, int>> Tetromino(List<Tuple<string, int, int>> tetromino)
        {
            int startXPosition = 12;
            int startYPosition = 1;
            bool freezeRightMovement = false;
            bool freezeLeftMovement = false;
            int leftEdge = 2;
            int rightEdge = 22;
            int bottomEdge = 40;

            movement.Clear();
            GravityOn(true);

            foreach (var block in tetromino)
            {
                var tetrominoType = block.Item1;
                var tetrominoX = block.Item2 + startXPosition + moveX;
                var tetrominoY = block.Item3 + startYPosition + gravity;

                if (tetrominoY >= bottomEdge)
                {
                    GravityOn(false);
                    callNewTetromino = true;
                }

                if (tetrominoX <= leftEdge)
                    freezeLeftMovement = true;

                if (tetrominoX >= rightEdge)
                    freezeRightMovement = true;

                movement.Add(new Tuple<string, int, int>(
                    tetrominoType,
                    tetrominoX,
                    tetrominoY
                    ));
            }


            if (Console.KeyAvailable == true)
            {
                var keyboard = Console.ReadKey(true);
                if (keyboard.Key == ConsoleKey.LeftArrow && freezeLeftMovement == false)
                {
                    moveX -= 1;
                }

                if (keyboard.Key == ConsoleKey.RightArrow && freezeRightMovement == false)
                {
                    moveX += 1;
                }
            }

            return movement;
        }


        static int gravity = 0;
        static int step = 0;
        static int speed = 0;

        public static void GravityOn(bool on)
        {
            if (on == true)
            {
                step += 1;
                speed = 1;

                if (step % speed == 0)
                    gravity += 1;
            }

            else if (on == false)
                gravity = 0;
        }

        static bool callNewTetromino = false;

        public static bool FinishedCallNewTetromino(string newTetromino)
        {
            if (newTetromino == "New Tetromino")
                callNewTetromino = false;

            return callNewTetromino;
        }
    }
}
