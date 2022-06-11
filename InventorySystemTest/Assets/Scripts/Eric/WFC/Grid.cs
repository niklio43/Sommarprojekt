using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace WFC
{
    public class Grid
    {
        public Cell[,] cells;

        public Grid(int width, int height)
        {
            cells = new Cell[width, height];

            //Construct all cells
            for (int x = 0; x < width; x++) {
                for (int y = 0; y < height; y++) {
                    cells[x, y] = new Cell(x, y);
                }
            }
        }



    }

}