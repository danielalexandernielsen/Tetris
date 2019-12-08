using System;
using System.Collections.Generic;
using System.Text;

namespace Tetris
{
    class Collision
    {
        public enum Collided { no, yes, sideways };

        public static Collided Downwards(int x, int y, string[,] canvas, string tetrominoID, int previousMoveX)
        {

            string tetrominoOnCanvasID = canvas[x, y];

            if (tetrominoOnCanvasID != null)
            {
                tetrominoOnCanvasID = (Convert.ToString(tetrominoOnCanvasID[1]) +
                                       Convert.ToString(tetrominoOnCanvasID[2]) +
                                       Convert.ToString(tetrominoOnCanvasID[3]) +
                                       Convert.ToString(tetrominoOnCanvasID[4]) +
                                       Convert.ToString(tetrominoOnCanvasID[5]) +
                                       Convert.ToString(tetrominoOnCanvasID[6]) +
                                       Convert.ToString(tetrominoOnCanvasID[7]));
                tetrominoOnCanvasID = Convert.ToString(Convert.ToInt32(tetrominoOnCanvasID) + 1);
            }
            else
                tetrominoOnCanvasID = "junk";

            if (canvas[x, y] != null && tetrominoID != tetrominoOnCanvasID)
            {
                if (previousMoveX == 0)
                {
                    return Collided.yes;
                }

                else
                {
                    if (canvas[x + previousMoveX, y] != null && previousMoveX != 0)
                    {
                        return Collided.sideways;
                    }
                }
            }

            return Collided.no;
        }
    }
}
