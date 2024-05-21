namespace LeetCode.ScoreAfterFlippingMatrix
{
    public class Solution
    {
        public int MatrixScore(int[][] grid)
        {
            int rowsCount = grid.Length;
            int colsCount = grid[0].Length;
            int result = 0;

            for (int row = 0; row < rowsCount; row++)
            {
                if (grid[row][0] == 0)
                {
                    for (int col = 0; col < colsCount; col++)
                    {
                        grid[row][col] = (grid[row][col] == 0) ? 1 : 0;
                    }
                }
            }
            int oneCount = 0;

            for (int col = 0; col < colsCount; col++)
            {
                oneCount = 0;
                for (int row = 0; row < rowsCount; row++)
                {
                    oneCount += grid[row][col];
                }
                if (oneCount < rowsCount - oneCount)
                {
                    for (int i = 0; i < rowsCount; i++)
                    {
                        grid[i][col] = (grid[i][col] == 0) ? 1 : 0;
                    }
                }
            }

            for (int i = 0; i < rowsCount; i++)
            {
                for (int j = 0; j < colsCount; j++)
                {
                    if(grid[i][j] == 1){
                        result +=(int)Math.Pow(2,colsCount - j - 1);
                        Console.WriteLine(result);
                    }
                    else{
                        Console.WriteLine("Encountered a zero");
                    }
                }
            }
            return result;
        }
    }
    // public class Program
    // {
    //     public static void Main(string[] args)
    //     {
    //         Solution solution = new Solution();
    //         int[][] grid = [[0]];
    //         solution.MatrixScore(grid);
    //     }
    // }
}