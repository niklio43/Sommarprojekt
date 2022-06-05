using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace WFC
{
    public class Cell
    {
        Vector2Int gridPosition;

        public Cell(int x, int y)
        {
            gridPosition = new Vector2Int(x, y);
        }


    }

}
