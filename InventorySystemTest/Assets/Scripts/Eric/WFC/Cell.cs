using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using WFC.Data;

namespace WFC
{
    public class Cell
    {
        public bool collapsed {  get { return (occupant != null); } }

        public Dictionary<string, Prototype> available;
        public Vector2Int coords;
        public Prototype occupant;

        public Cell(int x, int y, Dictionary<string, Prototype> prototypes)
        {
            available = new Dictionary<string, Prototype>(prototypes);
            coords = new Vector2Int(x, y);
            occupant = null;
        }

        public void CollapseCell()
        {
            int randomIndex = Random.Range(0, available.Count);
            occupant = available.ElementAt(randomIndex).Value;

            available.Clear();
        }

    }

}
