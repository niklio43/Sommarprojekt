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
        public Cell this[Vector2Int coords] { get { return cells[coords.x, coords.y]; } }

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


        public List<Vector2Int> ValidDirections(Vector2Int coords)
        {
            List<Vector2Int> dirs = new List<Vector2Int>()
            {
                Vector2Int.right,
                Vector2Int.left,
                Vector2Int.up,
                Vector2Int.down,
            };

            for(int i = 0; i < dirs.Count; i++) {
                Vector2Int check = coords + dirs[i];
                if (
                    (check.x < 0 || check.x > (cells.GetLength(0) - 1))
                    ||
                    (check.y < 0 || check.y > (cells.GetLength(1) - 1))
                   ) 
                {
                    dirs.RemoveAt(i);
                    i--;
                }
            }

            return dirs;
        }


    }

}