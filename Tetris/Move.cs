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

        static List<Tuple<string, int, int>> tetrominoMovement = new List<Tuple<string, int, int>>();
        public static bool movementFinished = false;
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
            
            GravityOn(true);
            tetrominoMovement.Clear();

            foreach (var block in tetromino)
            {
                var tetrominoType = block.Item1;
                var tetrominoX = block.Item2 + startXPosition + moveX;
                var tetrominoY = block.Item3 + startYPosition + gravity;

                if (tetrominoY > bottomEdge)
                {                    
                    GravityOn(false);
                    ResetMovement(true);
                    movementFinished = true;
                    tetrominoMovement.Clear();
                    break;
                }

                if (tetrominoX <= leftEdge)
                    freezeLeftMovement = true;

                if (tetrominoX >= rightEdge)
                    freezeRightMovement = true;

                tetrominoMovement.Add(new Tuple<string, int, int>(
                    tetrominoType,
                    tetrominoX,
                    tetrominoY
                    ));
            }

            Controller(freezeRightMovement, freezeLeftMovement);
            return tetrominoMovement;
        }

        private static void Controller(bool freezeRightMovement, bool freezeLeftMovement)
        {
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
        }

        static int gravity = 0;
        static int step = 0;
        static int speed = 0;

        public static void GravityOn(bool state)
        {
            if (state == true)
            {
                step += 1;
                speed = 2;

                if (step % speed == 0)
                    gravity += 1;
            }

            else if (state == false)
            {
                gravity = 0;
                step = 0;
            }
        }


        public static void ResetMovement(bool state)
        {
            if (state == true)
            {
                moveX = 0;
            }   
        }
    }
}
