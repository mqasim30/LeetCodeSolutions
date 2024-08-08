namespace LeetCode.SpiralMatrixIII;
public class Solution
{
    public int[][] SpiralMatrixIII(int rows, int cols, int rStart, int cStart)
    {
        int row = rStart, col = cStart;

        // Direction vectors: right, down, left, up (clockwise)
        int dRow = 0, dCol = 1;
        int turnCount = 2;  // Counter to determine when to increase the number of moves
        List<int[]> result = new List<int[]>();
        int currentMoves = 1;
        int nextMoves = 2;

        while (result.Count < rows * cols)
        {
            // Check if the current position is within bounds
            if (row >= 0 && row < rows && col >= 0 && col < cols)
            {
                result.Add(new int[] { row, col });
            }

            // Move in the current direction
            row += dRow;
            col += dCol;
            currentMoves--;

            // Change direction if all moves for the current direction are done
            if (currentMoves == 0)
            {
                int temp = dRow;
                dRow = dCol;
                dCol = -temp;  // Rotate direction 90 degrees clockwise
                turnCount--;

                if (turnCount == 0)
                {
                    turnCount = 2;  // Reset turn counter after two turns
                    currentMoves = nextMoves;
                    nextMoves++;
                }
                else
                {
                    currentMoves = nextMoves - 1;
                }
            }
        }

        return result.ToArray();
    }
}
