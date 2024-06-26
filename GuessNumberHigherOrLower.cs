namespace LeetCode.GuessNumberHigherOrLower;

public class Solution //: GuessGame
{
    public int GuessNumber(int n)
    {
        int left = 1, right = n;
        while (left <= right)
        {
            int mid = left + (right - left) / 2;
            int result = 0;
            //result = guess(mid);
            if (result == 0)
            {
                return mid;
            }
            else if (result == -1)
            {
                right = mid - 1;
            }
            else
            {
                left = mid + 1;
            }
        }
        return -1;
    }
}