using System;
using System.Collections.Generic;
using System.Text;

namespace Tetris
{
    class Generate
    {
        static Dictionary<int, string[,]> bag = new Dictionary<int, string[,]>();
        static readonly Random random = new Random();
 
        public static string[,] NewTetromino()
        {
            int tetromine = 0;

            if (bag.Count == 0)
                FillBag();

            while (true)
            {
                tetromine = random.Next(1, 8);
                bag.TryGetValue(tetromine, out var value);

                if (value != null)
                    break;
            }

            string[,] newBlock = bag[tetromine];
            bag.Remove(tetromine);

            return newBlock;
        }


        private static void FillBag()
        {
            var lTetromino = new string[,] {
                { " ", " ", "L" },
                { "L", "L", "L" },
                };
            bag.Add(1, lTetromino);

            var jTetromino = new string[,] {
                { "J", " ", " " },
                { "J", "J", "J" },
                };
            bag.Add(2, jTetromino);

            var zTetromino = new string[,] {
                { "Z", "Z", " " },
                { " ", "Z", " " },
                { " ", "Z", "Z" },
                };
            bag.Add(3, zTetromino);

            var sTetromino = new string[,] {
                { " ", "S", "S" },
                { " ", "S", " " },
                { "S", "S", " " },
                };
            bag.Add(4, sTetromino);

            var iTetrominok = new string[,] {
                { "I", "I", "I", "I" }
                };
            bag.Add(5, iTetrominok);

            var tTetromino = new string[,] {
                { " ", "T", " " },
                { " ", "T", " " },
                { "T", "T", "T" },
                };
            bag.Add(6, tTetromino);

            var oTetromino = new string[,] {
                { "O", "O", "O" },
                { "O", "O", "O" },
                { "O", "O", "O" },
                };
            bag.Add(7, oTetromino);
        }
    }
}
