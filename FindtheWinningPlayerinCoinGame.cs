namespace LeetCode.FindtheWinningPlayerinCoinGame;
public class Solution
{
    public string LosingPlayer(int x, int y)
    {
        int maxMoves = Math.Min(x, y / 4);
        if (maxMoves % 2 == 0)
        {
            return "Bob";
        }
        else
        {
            return "Alice";
        }
    }
}
