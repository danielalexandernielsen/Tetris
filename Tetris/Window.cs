using System;
using System.Collections.Generic;
using System.Text;

namespace Tetris
{
    class Window
    {
        public static int[] setWindow(double windowRatio, int interfaceWidth)
        {
            int realTetrisWidth = 34;
            int realTetrisHeight = 28;

            int canvasWidth = Convert.ToInt16(realTetrisWidth * windowRatio) / 2;
            int canvasHeight = Convert.ToInt16(realTetrisHeight * windowRatio);

            int windowWidth = canvasWidth + interfaceWidth;
            int windowHeight = canvasHeight;

            Console.SetWindowSize(windowWidth, windowHeight);
            int[] windowSizeXY = { canvasWidth, canvasHeight };

            return windowSizeXY;
        }
    }
}
