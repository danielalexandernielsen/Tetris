using System;
using System.Collections.Generic;
using System.Text;

namespace Tetris
{
    class Generate
    {
        static Dictionary<int, List<Tuple<string, int, int>>> tetrominoBag = new Dictionary<int, List<Tuple<string, int, int>>>();

        static Dictionary<int, List<Tuple<string, int, int>>> lRotationBag = new Dictionary<int, List<Tuple<string, int, int>>>();
        static Dictionary<int, List<Tuple<string, int, int>>> jRotationBag = new Dictionary<int, List<Tuple<string, int, int>>>();
        static Dictionary<int, List<Tuple<string, int, int>>> zRotationBag = new Dictionary<int, List<Tuple<string, int, int>>>();
        static Dictionary<int, List<Tuple<string, int, int>>> sRotationBag = new Dictionary<int, List<Tuple<string, int, int>>>();
        static Dictionary<int, List<Tuple<string, int, int>>> iRotationBag = new Dictionary<int, List<Tuple<string, int, int>>>();
        static Dictionary<int, List<Tuple<string, int, int>>> tRotationBag = new Dictionary<int, List<Tuple<string, int, int>>>();

        static readonly List<Tuple<string, int, int>> lTetrominoUp = new List<Tuple<string, int, int>>();
        static readonly List<Tuple<string, int, int>> lTetrominoRight = new List<Tuple<string, int, int>>();
        static readonly List<Tuple<string, int, int>> lTetrominoDown = new List<Tuple<string, int, int>>();
        static readonly List<Tuple<string, int, int>> lTetrominoLeft = new List<Tuple<string, int, int>>();

        static readonly List<Tuple<string, int, int>> jTetrominoUp = new List<Tuple<string, int, int>>();
        static readonly List<Tuple<string, int, int>> jTetrominoRight = new List<Tuple<string, int, int>>();
        static readonly List<Tuple<string, int, int>> jTetrominoDown = new List<Tuple<string, int, int>>();
        static readonly List<Tuple<string, int, int>> jTetrominoLeft = new List<Tuple<string, int, int>>();

        static readonly List<Tuple<string, int, int>> zTetrominoUp = new List<Tuple<string, int, int>>();
        static readonly List<Tuple<string, int, int>> zTetrominoRight = new List<Tuple<string, int, int>>();
        static readonly List<Tuple<string, int, int>> zTetrominoDown = new List<Tuple<string, int, int>>();
        static readonly List<Tuple<string, int, int>> zTetrominoLeft = new List<Tuple<string, int, int>>();

        static readonly List<Tuple<string, int, int>> sTetrominoUp = new List<Tuple<string, int, int>>();
        static readonly List<Tuple<string, int, int>> sTetrominoRight = new List<Tuple<string, int, int>>();
        static readonly List<Tuple<string, int, int>> sTetrominoDown = new List<Tuple<string, int, int>>();
        static readonly List<Tuple<string, int, int>> sTetrominoLeft = new List<Tuple<string, int, int>>();

        static readonly List<Tuple<string, int, int>> iTetrominoUp = new List<Tuple<string, int, int>>();
        static readonly List<Tuple<string, int, int>> iTetrominoRight = new List<Tuple<string, int, int>>();
        static readonly List<Tuple<string, int, int>> iTetrominoDown = new List<Tuple<string, int, int>>();
        static readonly List<Tuple<string, int, int>> iTetrominoLeft = new List<Tuple<string, int, int>>();

        static readonly List<Tuple<string, int, int>> tTetrominoUp = new List<Tuple<string, int, int>>();
        static readonly List<Tuple<string, int, int>> tTetrominoRight = new List<Tuple<string, int, int>>();
        static readonly List<Tuple<string, int, int>> tTetrominoLeft = new List<Tuple<string, int, int>>();
        static readonly List<Tuple<string, int, int>> tTetrominoDown = new List<Tuple<string, int, int>>();

        static readonly List<Tuple<string, int, int>> oTetromino = new List<Tuple<string, int, int>>();

        static readonly Random random = new Random();
        static List<Tuple<string, int, int>> newTetrominoRotation = new List<Tuple<string, int, int>>();
        static int tetromino;
        static int rotation = 1;
        static int fillRotationBagOnce = 1;

        public static List<Tuple<string, int, int>> NewTetromino()
        {

            if (tetrominoBag.Count == 0)
                FillBags();

            tetromino = 0;
            while (true)
            {
                tetromino = random.Next(1, 8);
                tetrominoBag.TryGetValue(tetromino, out var value);

                if (value != null)
                    break;
            }

            List<Tuple<string, int, int>> newTetromino = tetrominoBag[tetromino];
            tetrominoBag.Remove(tetromino);

            return newTetromino;
        }

        public static List<Tuple<string, int, int>> Rotation()
        {
            if (rotation < 4)
                rotation++;
            else
                rotation = 1;

            switch (tetromino)
            {
                case 1:
                    newTetrominoRotation = lRotationBag[rotation];
                    break;

                case 2:
                    newTetrominoRotation = jRotationBag[rotation];
                    break;

                case 3:
                    newTetrominoRotation = zRotationBag[rotation];
                    break;

                case 4:
                    newTetrominoRotation = sRotationBag[rotation];
                    break;

                case 5:
                    newTetrominoRotation = iRotationBag[rotation];
                    break;

                case 6:
                    newTetrominoRotation = tRotationBag[rotation];
                    break;
            }

            return newTetrominoRotation;
        }


        private static void FillBags()
        {
            if (fillRotationBagOnce == 1)
            {
                lRotationBag.Add(1, lTetrominoUp);
                lRotationBag.Add(2, lTetrominoRight);
                lRotationBag.Add(3, lTetrominoDown);
                lRotationBag.Add(4, lTetrominoLeft);

                jRotationBag.Add(1, jTetrominoUp);
                jRotationBag.Add(2, jTetrominoRight);
                jRotationBag.Add(3, jTetrominoDown);
                jRotationBag.Add(4, jTetrominoLeft);

                zRotationBag.Add(1, zTetrominoUp);
                zRotationBag.Add(2, zTetrominoRight);
                zRotationBag.Add(3, zTetrominoDown);
                zRotationBag.Add(4, zTetrominoLeft);

                sRotationBag.Add(1, sTetrominoUp);
                sRotationBag.Add(2, sTetrominoRight);
                sRotationBag.Add(3, sTetrominoDown);
                sRotationBag.Add(4, sTetrominoLeft);

                iRotationBag.Add(1, iTetrominoUp);
                iRotationBag.Add(2, iTetrominoRight);
                iRotationBag.Add(3, iTetrominoDown);
                iRotationBag.Add(4, iTetrominoLeft);

                tRotationBag.Add(1, tTetrominoUp);
                tRotationBag.Add(2, tTetrominoRight);
                tRotationBag.Add(3, tTetrominoDown);
                tRotationBag.Add(4, tTetrominoLeft);

                fillRotationBagOnce++;
            }


            //    { " ", " ", "L" }
            //    { "L", "L", "L" }
            //    { " ", " ", " " }
            lTetrominoUp.Add(new Tuple<string, int, int>("L", 0, 2));
            lTetrominoUp.Add(new Tuple<string, int, int>("L", 1, 0));
            lTetrominoUp.Add(new Tuple<string, int, int>("L", 1, 1));
            lTetrominoUp.Add(new Tuple<string, int, int>("L", 1, 2));
            tetrominoBag.Add(1, lTetrominoUp);

            //    { " ", "L", " " }
            //    { " ", "L", " " }
            //    { " ", "L", "L" }
            lTetrominoRight.Add(new Tuple<string, int, int>("L", 0, 1));
            lTetrominoRight.Add(new Tuple<string, int, int>("L", 1, 1));
            lTetrominoRight.Add(new Tuple<string, int, int>("L", 2, 1));
            lTetrominoRight.Add(new Tuple<string, int, int>("L", 2, 2));

            //    { " ", " ", " " }
            //    { "L", "L", "L" }
            //    { "L", " ", " " }
            lTetrominoDown.Add(new Tuple<string, int, int>("L", 1, 0));
            lTetrominoDown.Add(new Tuple<string, int, int>("L", 1, 1));
            lTetrominoDown.Add(new Tuple<string, int, int>("L", 1, 2));
            lTetrominoDown.Add(new Tuple<string, int, int>("L", 2, 0));

            //    { "L", "L", " " }
            //    { " ", "L", " " }
            //    { " ", "L", " " }
            lTetrominoLeft.Add(new Tuple<string, int, int>("L", 1, 0));
            lTetrominoLeft.Add(new Tuple<string, int, int>("L", 1, 1));
            lTetrominoLeft.Add(new Tuple<string, int, int>("L", 1, 2));
            lTetrominoLeft.Add(new Tuple<string, int, int>("L", 2, 2));

            ///////////////////////////////////////////////////////////////////////////

            //    { "J", " ", " " }
            //    { "J", "J", "J" }
            //    { " ", " ", " " }
            jTetrominoUp.Add(new Tuple<string, int, int>("J", 0, 0));
            jTetrominoUp.Add(new Tuple<string, int, int>("J", 1, 0));
            jTetrominoUp.Add(new Tuple<string, int, int>("J", 1, 1));
            jTetrominoUp.Add(new Tuple<string, int, int>("J", 1, 2));

            tetrominoBag.Add(2, jTetrominoUp);

            //    { " ", "J", "J" }
            //    { " ", "J", " " }
            //    { " ", "J", " " }
            jTetrominoRight.Add(new Tuple<string, int, int>("J", 0, 1));
            jTetrominoRight.Add(new Tuple<string, int, int>("J", 0, 2));
            jTetrominoRight.Add(new Tuple<string, int, int>("J", 1, 1));
            jTetrominoRight.Add(new Tuple<string, int, int>("J", 2, 1));

            //    { " ", " ", " " }
            //    { "J", "J", "J" }
            //    { " ", " ", "J" }
            jTetrominoDown.Add(new Tuple<string, int, int>("J", 1, 0));
            jTetrominoDown.Add(new Tuple<string, int, int>("J", 1, 1));
            jTetrominoDown.Add(new Tuple<string, int, int>("J", 1, 2));
            jTetrominoDown.Add(new Tuple<string, int, int>("J", 2, 2));


            //    { " ", "J", " " }
            //    { " ", "J", " " }
            //    { "J", "J", " " }
            jTetrominoLeft.Add(new Tuple<string, int, int>("J", 0, 1));
            jTetrominoLeft.Add(new Tuple<string, int, int>("J", 1, 1));
            jTetrominoLeft.Add(new Tuple<string, int, int>("J", 2, 0));
            jTetrominoLeft.Add(new Tuple<string, int, int>("J", 2, 1));

            ///////////////////////////////////////////////////////////////////////////

            //    { "Z", "Z", " " }
            //    { " ", "Z", "Z" }
            //    { " ", " ", " " }
            zTetrominoUp.Add(new Tuple<string, int, int>("Z", 0, 0));
            zTetrominoUp.Add(new Tuple<string, int, int>("Z", 0, 1));
            zTetrominoUp.Add(new Tuple<string, int, int>("Z", 1, 1));
            zTetrominoUp.Add(new Tuple<string, int, int>("Z", 1, 2));
            tetrominoBag.Add(3, zTetrominoUp);

            //    { " ", " ", "Z" }
            //    { " ", "Z", "Z" }
            //    { " ", "Z", " " }
            zTetrominoRight.Add(new Tuple<string, int, int>("Z", 0, 2));
            zTetrominoRight.Add(new Tuple<string, int, int>("Z", 1, 1));
            zTetrominoRight.Add(new Tuple<string, int, int>("Z", 1, 2));
            zTetrominoRight.Add(new Tuple<string, int, int>("Z", 2, 1));

            //    { " ", " ", " " }
            //    { "Z", "Z", " " }
            //    { " ", "Z", "Z" }
            zTetrominoDown.Add(new Tuple<string, int, int>("Z", 1, 0));
            zTetrominoDown.Add(new Tuple<string, int, int>("Z", 1, 1));
            zTetrominoDown.Add(new Tuple<string, int, int>("Z", 2, 1));
            zTetrominoDown.Add(new Tuple<string, int, int>("Z", 2, 2));

            //    { " ", "Z", " " }
            //    { "Z", "Z", " " }
            //    { "Z", " ", " " }
            zTetrominoLeft.Add(new Tuple<string, int, int>("Z", 0, 1));
            zTetrominoLeft.Add(new Tuple<string, int, int>("Z", 1, 0));
            zTetrominoLeft.Add(new Tuple<string, int, int>("Z", 1, 1));
            zTetrominoLeft.Add(new Tuple<string, int, int>("Z", 2, 0));


            ///////////////////////////////////////////////////////////////////////////

            //    { " ", "S", "S" }
            //    { "S", "S", " " }
            //    { " ", " ", " " }
            sTetrominoUp.Add(new Tuple<string, int, int>("S", 0, 1));
            sTetrominoUp.Add(new Tuple<string, int, int>("S", 0, 2));
            sTetrominoUp.Add(new Tuple<string, int, int>("S", 1, 0));
            sTetrominoUp.Add(new Tuple<string, int, int>("S", 1, 1));
            tetrominoBag.Add(4, sTetrominoUp);

            //    { " ", "S", " " }
            //    { " ", "S", "S" }
            //    { " ", " ", "S" }
            sTetrominoRight.Add(new Tuple<string, int, int>("S", 0, 1));
            sTetrominoRight.Add(new Tuple<string, int, int>("S", 1, 1));
            sTetrominoRight.Add(new Tuple<string, int, int>("S", 1, 2));
            sTetrominoRight.Add(new Tuple<string, int, int>("S", 2, 2));

            //    { " ", " ", " " }
            //    { " ", "S", "S" }
            //    { "S", "S", " " }
            sTetrominoDown.Add(new Tuple<string, int, int>("S", 1, 1));
            sTetrominoDown.Add(new Tuple<string, int, int>("S", 1, 2));
            sTetrominoDown.Add(new Tuple<string, int, int>("S", 2, 0));
            sTetrominoDown.Add(new Tuple<string, int, int>("S", 2, 1));

            //    { "S", " ", " " }
            //    { "S", "S", " " }
            //    { " ", "S", " " }
            sTetrominoLeft.Add(new Tuple<string, int, int>("S", 0, 0));
            sTetrominoLeft.Add(new Tuple<string, int, int>("S", 0, 0));
            sTetrominoLeft.Add(new Tuple<string, int, int>("S", 1, 1));
            sTetrominoLeft.Add(new Tuple<string, int, int>("S", 2, 1));

            ///////////////////////////////////////////////////////////////////////////


            //    { " ", " ", " ", " " }
            //    { "I", "I", "I", "I" }
            //    { " ", " ", " ", " " }
            //    { " ", " ", " ", " " }
            iTetrominoUp.Add(new Tuple<string, int, int>("I", 1, 0));
            iTetrominoUp.Add(new Tuple<string, int, int>("I", 1, 1));
            iTetrominoUp.Add(new Tuple<string, int, int>("I", 1, 2));
            iTetrominoUp.Add(new Tuple<string, int, int>("I", 1, 3));
            tetrominoBag.Add(5, iTetrominoUp);

            //    { " ", " ", "I", " " }
            //    { " ", " ", "I", " " }
            //    { " ", " ", "I", " " }
            //    { " ", " ", "I", " " }
            iTetrominoRight.Add(new Tuple<string, int, int>("I", 0, 2));
            iTetrominoRight.Add(new Tuple<string, int, int>("I", 1, 2));
            iTetrominoRight.Add(new Tuple<string, int, int>("I", 2, 2));
            iTetrominoRight.Add(new Tuple<string, int, int>("I", 2, 3));

            //    { " ", " ", " ", " " }
            //    { " ", " ", " ", " " }
            //    { "I", "I", "I", "I" }
            //    { " ", " ", " ", " " }
            iTetrominoDown.Add(new Tuple<string, int, int>("I", 2, 0));
            iTetrominoDown.Add(new Tuple<string, int, int>("I", 2, 1));
            iTetrominoDown.Add(new Tuple<string, int, int>("I", 2, 2));
            iTetrominoDown.Add(new Tuple<string, int, int>("I", 2, 3));

            //    { " ", "I", " ", " " }
            //    { " ", "I", " ", " " }
            //    { " ", "I", " ", " " }
            //    { " ", "I", " ", " " }
            iTetrominoLeft.Add(new Tuple<string, int, int>("I", 0, 1));
            iTetrominoLeft.Add(new Tuple<string, int, int>("I", 1, 1));
            iTetrominoLeft.Add(new Tuple<string, int, int>("I", 2, 1));
            iTetrominoLeft.Add(new Tuple<string, int, int>("I", 3, 1));

            ///////////////////////////////////////////////////////////////////////////

            //    { " ", "T", " " }
            //    { "T", "T", "T" }
            //    { " ", " ", " " }
            tTetrominoUp.Add(new Tuple<string, int, int>("T", 0, 1));
            tTetrominoUp.Add(new Tuple<string, int, int>("T", 1, 0));
            tTetrominoUp.Add(new Tuple<string, int, int>("T", 1, 1));
            tTetrominoUp.Add(new Tuple<string, int, int>("T", 1, 2));
            tetrominoBag.Add(6, tTetrominoUp);

            //    { " ", "T", " " }
            //    { " ", "T", "T" }
            //    { " ", "T", " " }
            tTetrominoRight.Add(new Tuple<string, int, int>("T", 0, 1));
            tTetrominoRight.Add(new Tuple<string, int, int>("T", 1, 1));
            tTetrominoRight.Add(new Tuple<string, int, int>("T", 1, 2));
            tTetrominoRight.Add(new Tuple<string, int, int>("T", 2, 1));

            //    { " ", " ", " " }
            //    { "T", "T", "T" }
            //    { " ", "T", " " }
            tTetrominoDown.Add(new Tuple<string, int, int>("T", 1, 0));
            tTetrominoDown.Add(new Tuple<string, int, int>("T", 1, 1));
            tTetrominoDown.Add(new Tuple<string, int, int>("T", 1, 2));
            tTetrominoDown.Add(new Tuple<string, int, int>("T", 3, 1));

            //    { " ", "T", " " }
            //    { "T", "T", " " }
            //    { " ", "T", " " }
            tTetrominoLeft.Add(new Tuple<string, int, int>("T", 0, 1));
            tTetrominoLeft.Add(new Tuple<string, int, int>("T", 1, 0));
            tTetrominoLeft.Add(new Tuple<string, int, int>("T", 1, 1));
            tTetrominoLeft.Add(new Tuple<string, int, int>("T", 2, 1));


            ///////////////////////////////////////////////////////////////////////////

            //    { " ", "O", "O", " " }
            //    { " ", "O", "O", " " }
            //    { " ", " ", " ", " " }
            oTetromino.Add(new Tuple<string, int, int>("O", 0, 1));
            oTetromino.Add(new Tuple<string, int, int>("O", 0, 2));
            oTetromino.Add(new Tuple<string, int, int>("O", 1, 1));
            oTetromino.Add(new Tuple<string, int, int>("O", 1, 2));
            tetrominoBag.Add(7, oTetromino);
        }
    }
}