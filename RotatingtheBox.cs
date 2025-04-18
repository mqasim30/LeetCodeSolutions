namespace LeetCode.RotatingtheBox;
public class Solution
{
    public char[][] RotateTheBox(char[][] box)
    {
        int ROWS = box.Length;
        int COLS = box[0].Length;

        char[][] res = new char[COLS][];
        for (int i = 0; i < COLS; i++)
        {
            res[i] = new char[ROWS];
            Array.Fill(res[i], '.');
        }

        for (int r = 0; r < ROWS; r++)
        {
            int i = COLS - 1;
            for (int c = COLS - 1; c >= 0; c--)
            {
                if (box[r][c] == '#')
                {
                    res[i][ROWS - r - 1] = '#';
                    i--;
                }
                else if (box[r][c] == '*')
                {
                    res[c][ROWS - r - 1] = '*';
                    i = c - 1;
                }
            }
        }
        return res;
    }
}