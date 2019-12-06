using System;
using System.Collections.Generic;
using System.Text;

namespace Tetris
{
    class Collision
    {
        public static bool OnMovement(int x, int y, string[,] canvas, string tetrominoID)
        {

            string tetrominoOnCanvasID = canvas[x, y];

            if (tetrominoOnCanvasID != null)
            {
                tetrominoOnCanvasID = (Convert.ToString(tetrominoOnCanvasID[1]) +
                                       Convert.ToString(tetrominoOnCanvasID[2]) +
                                       Convert.ToString(tetrominoOnCanvasID[3]) +
                                       Convert.ToString(tetrominoOnCanvasID[4]));
                tetrominoOnCanvasID = Convert.ToString(Convert.ToInt32(tetrominoOnCanvasID) + 1);

            }
            else
                tetrominoOnCanvasID = "junk";

            if (canvas[x, y] != null && tetrominoID != tetrominoOnCanvasID)
            {
                
                return true;
            }

            return false;
        }
    }
}
