namespace LeetCode.TrappingRainWaterII;

public class Solution
{
    public record Cell(int height, int row, int col);

    public int TrapRainWater(int[][] heightMap)
    {

        // Define two direction arrays, that will help
        // us explore the neighbors of each cell: dRow = [0, 0, -1, 1], dCol = [-1, 1, 0, 0].
        int[] dRow = [0, 0, -1, 1];
        int[] dCol = [-1, 1, 0, 0];

        // Initialize numOfRows and numOfCols to the number of rows and columns
        // of the original grid, respectively.
        int numOfRows = heightMap.Length;
        int numOfCols = heightMap[0].Length;

        // Create a numOfRows x numOfCols boolean grid, called visited, with all its values initialized to false.
        bool[,] visited = new bool[numOfRows, numOfCols];
        PriorityQueue<Cell, int> boundary = new();

        // Push the cells of the first and last row and column
        // of the grid into the boundary and mark them as visited.
        for (int i = 0; i < numOfRows; i++)
        {
            boundary.Enqueue(new Cell(heightMap[i][0], i, 0), heightMap[i][0]);
            boundary.Enqueue(new Cell(heightMap[i][numOfCols - 1], i, numOfCols - 1), heightMap[i][numOfCols - 1]);
            // Mark left and right boundary cells as visited
            visited[i, 0] = visited[i, numOfCols - 1] = true;
        }

        for (int i = 0; i < numOfCols; i++)
        {
            boundary.Enqueue(new Cell(heightMap[0][i], 0, i), heightMap[0][i]);
            boundary.Enqueue(new Cell(heightMap[numOfRows - 1][i], numOfRows - 1, i), heightMap[numOfRows - 1][i]);
            // Mark left and right boundary cells as visited
            visited[0, i] = visited[numOfRows - 1, i] = true;
        }

        // Initialize totalWaterVolume to 0.
        int totalWaterVolume = 0;

        // While the boundary is not empty
        while (boundary.Count > 0)
        {
            // Pop the top cell out of the boundary, as [minBoundaryHeight, [currentRow, currentCol]] -
            // this is the cell with the minimum height in the unexplored part of the boundary
            var topCell = boundary.Dequeue();

            int currentRow = topCell.row;
            int currentCol = topCell.col;

            // Update minBoundaryHeight to height
            int minBoundaryHeight = topCell.height;

            // Loop through all neighbors of the current cell, with direction from 0 to 3

            for (int direction = 0; direction < 4; direction++)
            {
                // Initialize neighborRow to currentRow + dRow[direction]
                // and neighborCol to currentCol + dCol[direction]
                int neighborRow = currentRow + dRow[direction];
                int neighborCol = currentCol + dCol[direction];

                // Check if the neighbor is within the grid bounds and not yet
                // visited
                if (isValidCell(neighborRow, neighborCol, numOfRows, numOfCols) &&
                    !visited[neighborRow, neighborCol])
                {
                    // If the cell (neighborRow, neighborCol) is valid, i.e. it is not out of
                    // the bounds of the grid and not visited:

                    int neighborHeight = heightMap[neighborRow][neighborCol];

                    // If the neighbor's height is less than the current
                    // boundary height, water can be trapped
                    if (neighborHeight < minBoundaryHeight)
                    {
                        totalWaterVolume += minBoundaryHeight - neighborHeight;
                    }

                    // Push the neighbor into the boundary with updated height
                    // (to prevent water leakage)
                    int maxHeight = Math.Max(neighborHeight, minBoundaryHeight);
                    boundary.Enqueue(new Cell(maxHeight, neighborRow, neighborCol), maxHeight);
                    visited[neighborRow, neighborCol] = true;
                }
            }
        }

        // Return totalWaterVolume.
        return totalWaterVolume;
    }

    // Helper function to check if a cell is valid (within grid bounds)
    bool isValidCell(int row, int col, int numOfRows, int numOfCols)
    {
        return row >= 0 && col >= 0 && row < numOfRows && col < numOfCols;
    }
}