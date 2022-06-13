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
        private Grid grid;

        public void Initialize()
        {
            grid = new Grid(sizeX, sizeY);
        }


    }

}