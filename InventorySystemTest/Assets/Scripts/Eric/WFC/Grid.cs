using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using WFC.Data;

namespace WFC
{
    public class Grid
    {

        public Cell[,] cells;
        public Cell this[int x, int y] { get { return cells[x, y]; } }


        public Grid(int width, int height, Dictionary<string, Prototype> prototypes)
        {
            cells = new Cell[width, height];

            //Construct all cells
            for (int x = 0; x < width; x++) {
                for (int y = 0; y < height; y++) {
                    cells[x, y] = new Cell(x, y, prototypes);
                }
            }
        }



    }

}