using System.Collections.Generic;
using UnityEngine;
using WFC.Data;

namespace WFC
{
    public static class WaveFunction
    {
        public static Grid CollapseGrid(int sizeX, int sizeZ, PaletteData data)
        {
            Dictionary<string, Prototype> prototypes = data.GetPrototypes();
            CalculateNeighbours(prototypes);

            Grid grid = new Grid(sizeX, sizeZ, prototypes);

            //Iterative Process
            while (!FullyCollapsed(grid)) {

                Cell minEntropy = GetMinEntropyCell(grid);
                minEntropy.CollapseCell();

                PropagateCollapse(minEntropy.coords, grid);
            }


            return grid;
        }

        static bool FullyCollapsed(Grid grid)
        {
            for (int x = 0; x < grid.cells.GetLength(0); x++) {
                for (int y = 0; y < grid.cells.GetLength(1); y++) {
                    if(!grid[x, y].collapsed) { return false; }
                }
            }

            return true;
        }


        static void PropagateCollapse(Vector2Int coords, Grid grid)
        {
            Stack<Vector2Int> stack = new Stack<Vector2Int>();
            stack.Push(coords);

            while(stack.Count > 0) {
                Vector2Int curCoords = stack.Pop();

                foreach (Vector2Int d in grid.ValidDirections(curCoords)) {
                    Vector2Int otherCoords = (curCoords + d);

                    var otherPrototypes = grid[otherCoords].available;
                    var validNeighbours = GetPossibleNeighbours(grid, curCoords, d);

                    if (otherPrototypes.Count == 0) { continue; }

                    foreach (Prototype prototype in otherPrototypes.Values) {
                        if (!validNeighbours.Contains(prototype.id))
                            otherPrototypes.Remove(prototype.id);

                        else if(!stack.Contains(otherCoords))
                            stack.Push(otherCoords);
                    }
                }
            }
        }

        static Cell GetMinEntropyCell(Grid grid)
        {
            List<Cell> comparer = new List<Cell>();

            for (int x = 0; x < grid.cells.GetLength(0); x++) {
                for (int y = 0; y < grid.cells.GetLength(1); y++) {
                    if (grid[x, y].collapsed) { continue; }
                    if (comparer.Count == 0) { comparer.Add(grid[x, y]); continue; }

                    if (comparer[0].available.Count < grid[x, y].available.Count) {
                        comparer.Clear();
                        comparer.Add(grid[x, y]);
                        continue;
                    }

                    else if (comparer[0].available.Count == grid[x, y].available.Count) {
                        comparer.Add(grid[x, y]);
                    }
                }
            }

            int randomIndex = Random.Range(0, comparer.Count);
            return comparer[randomIndex];
        }

        static void CalculateNeighbours(Dictionary<string, Prototype> prototypes)
        {
            foreach (Prototype prototype in prototypes.Values) {

                foreach (Prototype _prototype in prototypes.Values) {
                    if (prototype.posX == _prototype.negX) { prototype.valid_posX.Add(_prototype.id); }
                    if (prototype.negX == _prototype.posX) { prototype.valid_negX.Add(_prototype.id); }
                    if (prototype.posZ == _prototype.negZ) { prototype.valid_posZ.Add(_prototype.id); }
                    if (prototype.negZ == _prototype.posZ) { prototype.valid_negZ.Add(_prototype.id); }
                }
            }
        }

        static List<string> GetPossibleNeighbours(Grid grid, Vector2Int coords, Vector2Int direction)
        {
            List<string> result = new List<string>();

            foreach (Prototype prototype in grid[coords].available.Values) {
                foreach (string validNeighbour in prototype.validNeighbours(direction)) {
                    result.Add(validNeighbour);
                }
            }
            return result;
        }



    }
}