using System;
using System.Collections.Generic;
using System.Text;

namespace Tetris
{
    class Generate
    {
        static Dictionary<int, List<Tuple<string, int, int>>> bag = new Dictionary<int, List<Tuple<string, int, int>>>();
        static readonly List<Tuple<string, int, int>> lTetromino = new List<Tuple<string, int, int>>();
        static readonly List<Tuple<string, int, int>> jTetromino = new List<Tuple<string, int, int>>();
        static readonly List<Tuple<string, int, int>> zTetromino = new List<Tuple<string, int, int>>();
        static readonly List<Tuple<string, int, int>> sTetromino = new List<Tuple<string, int, int>>();
        static readonly List<Tuple<string, int, int>> iTetrominok = new List<Tuple<string, int, int>>();
        static readonly List<Tuple<string, int, int>> tTetromino = new List<Tuple<string, int, int>>();
        static readonly List<Tuple<string, int, int>> oTetromino = new List<Tuple<string, int, int>>();
        static readonly Random random = new Random();

        public static List<Tuple<string, int, int>> NewTetromino()
        {

            if (bag.Count == 0)
                FillBag();

            int tetromino = 0;
            while (true)
            {
                tetromino = random.Next(1, 8);
                bag.TryGetValue(tetromino, out var value);

                if (value != null)
                    break;
            }

            List<Tuple<string, int, int>> newTetromino = bag[tetromino];
            bag.Remove(tetromino);

            return newTetromino;
        }


        private static void FillBag()
        {
            //    { " ", " ", "L" }
            //    { "L", "L", "L" }

            lTetromino.Add(new Tuple<string, int, int>("L", 0, 2));
            lTetromino.Add(new Tuple<string, int, int>("L", 1, 0));
            lTetromino.Add(new Tuple<string, int, int>("L", 1, 1));
            lTetromino.Add(new Tuple<string, int, int>("L", 1, 2));
            bag.Add(1, lTetromino);

            //    { "J", " ", " " }
            //    { "J", "J", "J" }

            jTetromino.Add(new Tuple<string, int, int>("J", 0, 0));
            jTetromino.Add(new Tuple<string, int, int>("J", 1, 0));
            jTetromino.Add(new Tuple<string, int, int>("J", 1, 1));
            jTetromino.Add(new Tuple<string, int, int>("J", 1, 2));
            bag.Add(2, jTetromino);


            //    { "Z", "Z", " " }
            //    { " ", "Z", " " }
            //    { " ", "Z", "Z" }

            zTetromino.Add(new Tuple<string, int, int>("Z", 0, 0));
            zTetromino.Add(new Tuple<string, int, int>("Z", 0, 1));
            zTetromino.Add(new Tuple<string, int, int>("Z", 1, 1));
            zTetromino.Add(new Tuple<string, int, int>("Z", 2, 1));
            zTetromino.Add(new Tuple<string, int, int>("Z", 2, 2));
            bag.Add(3, zTetromino);

            //    { " ", "S", "S" }
            //    { " ", "S", " " }
            //    { "S", "S", " " }

            sTetromino.Add(new Tuple<string, int, int>("S", 0, 1));
            sTetromino.Add(new Tuple<string, int, int>("S", 0, 2));
            sTetromino.Add(new Tuple<string, int, int>("S", 1, 1));
            sTetromino.Add(new Tuple<string, int, int>("S", 2, 0));
            sTetromino.Add(new Tuple<string, int, int>("S", 2, 1));
            bag.Add(4, sTetromino);

            //    { "I", "I", "I", "I" }

            iTetrominok.Add(new Tuple<string, int, int>("I", 0, 0));
            iTetrominok.Add(new Tuple<string, int, int>("I", 0, 1));
            iTetrominok.Add(new Tuple<string, int, int>("I", 0, 2));
            iTetrominok.Add(new Tuple<string, int, int>("I", 0, 3));
            bag.Add(5, iTetrominok);

            //    { " ", "T", " " }
            //    { "T", "T", "T" }

            tTetromino.Add(new Tuple<string, int, int>("T", 0, 1));
            tTetromino.Add(new Tuple<string, int, int>("T", 1, 0));
            tTetromino.Add(new Tuple<string, int, int>("T", 1, 1));
            tTetromino.Add(new Tuple<string, int, int>("T", 1, 2));
            bag.Add(6, tTetromino);

            //    { "O", "O", "O" }
            //    { "O", "O", "O" }
            //    { "O", "O", "O" }

            oTetromino.Add(new Tuple<string, int, int>("O", 0, 0));
            oTetromino.Add(new Tuple<string, int, int>("O", 0, 1));
            oTetromino.Add(new Tuple<string, int, int>("O", 0, 2));
            oTetromino.Add(new Tuple<string, int, int>("O", 1, 0));
            oTetromino.Add(new Tuple<string, int, int>("O", 1, 1));
            oTetromino.Add(new Tuple<string, int, int>("O", 1, 2));
            oTetromino.Add(new Tuple<string, int, int>("O", 2, 0));
            oTetromino.Add(new Tuple<string, int, int>("O", 2, 1));
            oTetromino.Add(new Tuple<string, int, int>("O", 2, 2));
            bag.Add(7, oTetromino);
        }
    }
}
