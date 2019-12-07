using System;
using System.Collections.Generic;
using System.Text;

namespace Tetris
{
    class Collision
    {
        public static bool Downwards(int x, int y, string[,] canvas, string tetrominoID, int reverseLastXmove, List<Tuple<string, int, int>> tetromino, int saveY)
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
                //int isRowBelowEmpty = 0;

                //foreach (var block in tetromino)
                //{
                //    int checkYbelow = block.Item3 + saveY + 1;
                //    if (canvas[x + reverseLastXmove, checkYbelow] != null && tetrominoID != tetrominoOnCanvasID)
                //    {
                //        isRowBelowEmpty++;
                //    }
                //}

                //if (isRowBelowEmpty == 0)
                    return true;  
            }      
            return false;
        }
    }
}
