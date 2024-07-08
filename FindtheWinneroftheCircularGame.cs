namespace LeetCode.FindtheWinneroftheCircularGame;
public class Solution
{
    public int FindTheWinner(int n, int k)
    {
        List<int> circle = new List<int>();
        for (int i = 1; i <= n; ++i)
        {
            circle.Add(i);
        }
        int curIndex = 0;

        while (circle.Count > 1)
        {
            int nextToRemove = (curIndex + k - 1) % circle.Count;
            circle.RemoveAt(nextToRemove);
            curIndex = nextToRemove;
        }

        return circle[0];
    }
}
