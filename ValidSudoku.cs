namespace LeetCode.ValidSudoku
{
    public class Solution
    {
        int rowLimit = 3;
        int colLimit = 3;
        public bool IsValidSudoku(char[][] board)
        {
            int rowLength = board.Length;
            int colLength = board[0].Length;

            if (!CheckRows(board))
            {
                return false;
            }

            if (!CheckCols(board))
            {
                return false;
            }

            if(!Check3x3(board)){
                return false;
            }
            return true;
        }
        private bool Check3x3(char[][] board)
        {
            List<int> ints = new List<int>();

            for (int k = 0; k < board.Length * board.Length; k++)
            {

                if (rowLimit > board.Length || colLimit > board.Length)
                {
                    if ((rowLimit + 3) <= board.Length)
                    {
                        rowLimit += 3;
                        colLimit = 3;
                    }
                    else
                    {
                        break;
                    }
                }
                ints.Clear();
                for (int row = rowLimit - 3; row < rowLimit; row++)
                {
                    for (int col = colLimit - 3; col < colLimit; col++)
                    {
                        if (!char.IsDigit(board[row][col]))
                        {
                            continue;
                        }
                        if (ints.Contains(board[row][col] - '0'))
                        {
                            Console.WriteLine($"Found Duplicate At ({row},{col})");
                            return false;
                        }
                        else
                        {
                            ints.Add(board[row][col] - '0');
                        }
                    }
                }
                colLimit += 3;
            }


            return true;
        }
        private bool CheckRows(char[][] board)
        {
            List<int> ints = new List<int>();
            for (int row = 0; row < board.Length; row++)
            {
                ints.Clear();
                for (int col = 0; col < board[0].Length; col++)
                {
                    if (!char.IsDigit(board[row][col]))
                    {
                        continue;
                    }
                    if (ints.Contains(board[row][col] - '0'))
                    {
                        Console.WriteLine($"Found Duplicate At ({row},{col})");
                        return false;
                    }
                    else
                    {
                        ints.Add(board[row][col] - '0');
                    }
                }
            }
            return true;
        }

        private bool CheckCols(char[][] board)
        {
            List<int> ints = new List<int>();
            for (int col = 0; col < board[0].Length; col++)
            {
                ints.Clear();
                for (int row = 0; row < board.Length; row++)
                {
                    if (!char.IsDigit(board[row][col]))
                    {
                        continue;
                    }
                    if (ints.Contains(board[row][col] - '0'))
                    {
                        Console.WriteLine($"Found Duplicate At ({row},{col})");
                        return false;
                    }
                    else
                    {
                        ints.Add(board[row][col] - '0');
                    }
                }
            }
            return true;
        }
    }
    // public class Program
    // {
    //     public static void Main(string[] args)
    //     {
    //         Solution solution = new Solution();

    //         char[][] board =
    //         [['5','3','.','.','7','.','.','.','.']
    //         ,['6','.','.','1','9','5','.','.','.']
    //         ,['.','9','8','.','.','.','.','6','.']
    //         ,['8','.','.','.','6','.','.','.','3']
    //         ,['4','.','.','8','.','3','.','.','1']
    //         ,['7','.','.','.','2','.','.','.','6']
    //         ,['.','6','.','.','.','.','2','8','.']
    //         ,['.','.','.','4','1','9','.','.','5']
    //         ,['.','.','.','.','8','.','.','7','9']];

    //         char[][] board1 =
    //         [['8','3','.','.','7','.','.','.','.']
    //         ,['6','.','.','1','9','5','.','.','.']
    //         ,['.','9','8','.','.','.','.','6','.']
    //         ,['8','.','.','.','6','.','.','.','3']
    //         ,['4','.','.','8','.','3','.','.','1']
    //         ,['7','.','.','.','2','.','.','.','6']
    //         ,['.','6','.','.','.','.','2','8','.']
    //         ,['.','.','.','4','1','9','.','.','5']
    //         ,['.','.','.','.','8','.','.','7','9']];

    //         System.Console.WriteLine(solution.IsValidSudoku(board));
    //     }
    // }
}