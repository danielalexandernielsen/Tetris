﻿using System;
using System.Collections.Generic;

namespace Tetris
{
    class Move
    {
        static List<Tuple<string, int, int>> tetrominoMovement = new List<Tuple<string, int, int>>();
        public static bool stopMovementOnTetromino = false;
        static int moveX = 0;
        static int moveY = 0;
        static int tetrominoIDvalue = 1000;
        static string tetrominoID;

        public static List<Tuple<string, int, int>> Tetromino(List<Tuple<string, int, int>> tetromino, string[,] canvas)
        {
            int startXPosition = 6;
            int startYPosition = 1;
            bool freezeRightMovement = false;
            bool freezeLeftMovement = false;
            bool freezeAllMovement = false;
            int leftEdge = 2;
            int rightEdge = 11;
            int bottomEdge = 20;

            GravityOn(true);
            tetrominoMovement.Clear();
            tetrominoID = Convert.ToString(tetrominoIDvalue);
            tetrominoIDvalue++;

            foreach (var block in tetromino)
            {
                var tetrominoType = block.Item1 + tetrominoID;
                var tetrominoX = block.Item2 + startXPosition + moveX;
                var tetrominoY = block.Item3 + startYPosition + gravity + moveY;

                freezeAllMovement = Collision.OnMovement(tetrominoX, tetrominoY, canvas, tetrominoID);

                if ((tetrominoY > bottomEdge) || freezeAllMovement == true)
                {
                    GravityOn(false);
                    ResetMovement(true);
                    stopMovementOnTetromino = true;
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

                if (keyboard.Key == ConsoleKey.DownArrow)
                {
                    moveY += 1;
                }

                if (keyboard.Key == ConsoleKey.UpArrow)
                {
                    Draw.tetromino = (Generate.Rotate());
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
                speed = 10;
                step += 1;

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
                moveY = 0;
            }
        }
    }
}