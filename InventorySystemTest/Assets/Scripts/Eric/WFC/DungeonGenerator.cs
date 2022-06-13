using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using WFC.Data;

namespace WFC
{
    public class DungeonGenerator : MonoBehaviour
    {
        public int sizeX = 10, sizeY = 10;

        [HideInInspector] public List<PaletteData> availablePalettes;
        [HideInInspector] public PaletteData selectedPalette;

        Grid grid;

        public void Start()
        {
            grid = WaveFunction.CollapseGrid(sizeX, sizeY, selectedPalette);

            for (int x = 0; x < grid.cells.GetLength(0); x++) {
                for (int y = 0; y < grid.cells.GetLength(1); y++) {
                    GameObject _temp = Instantiate(grid[x, y].occupant.gameobject);
                    _temp.name = $"{x},{y}";
                    _temp.transform.parent = transform;
                    _temp.transform.position = new Vector3(x, 0, y);
                    _temp.transform.eulerAngles = new Vector3(0, (90 * grid[x, y].occupant.rotation), 0);
                }
            }

        }


    }

}