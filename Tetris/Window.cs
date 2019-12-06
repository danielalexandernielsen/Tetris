﻿using System;

namespace Tetris
{
    class Window
    {
        public static int[] setWindow(double windowRatio, int interfaceWidth)
        {
            int realTetrisWidth = 28;
            int realTetrisHeight = 22;

            int canvasWidth = realTetrisWidth / 2;
            int canvasHeight = realTetrisHeight;

            int windowWidth = canvasWidth + interfaceWidth;
            int windowHeight = canvasHeight + 1;

            Console.SetWindowSize(windowWidth, windowHeight);
            int[] windowSizeXY = { canvasWidth, canvasHeight };

            return windowSizeXY;
        }
    }
}