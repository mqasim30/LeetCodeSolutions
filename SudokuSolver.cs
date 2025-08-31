namespace LeetCode.SudokuSolver;

public class Solution
{
    public void SolveSudoku(char[][] board)
    {
        bool isValid(int r, int c, char value)
        {
            for (int i = 0; i < 9; i++)
            {
                if (board[r][i] == value) return false;
                if (board[i][c] == value) return false;
            }
            // check square
            int newR = r % 3;
            int newC = c % 3;
            if (newR == 1) r -= 1;
            else if (newR == 2) r -= 2;
            if (newC == 1) c -= 1;
            else if (newC == 2) c -= 2;
            for (int i = r; i < r + 3; i++)
            {
                for (int j = c; j < c + 3; j++)
                {
                    if (board[i][j] == value) return false;
                }
            }
            return true;
        }
        bool done = false;
        void solve()
        {
            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    if (board[i][j] == '.')
                    {
                        for (char c = '1'; c <= '9'; c++)
                        {
                            if (isValid(i, j, c))
                            {
                                board[i][j] = c;
                                solve();
                                if (done) return;
                                board[i][j] = '.';
                            }
                        }
                        return;
                    }
                }
            }
            done = true;
        }
        solve();
    }
}