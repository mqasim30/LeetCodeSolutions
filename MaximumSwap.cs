namespace LeetCode.MaximumSwap;

public class Solution
{
    public int MaximumSwap(int num)
    {
        char[] digits = num.ToString().ToCharArray();
        int n = digits.Length;

        int maxPos = n - 1;
        int x = -1, y = -1;

        for (int i = n - 2; i >= 0; i--)
        {
            if (digits[i] < digits[maxPos])
            {
                x = i;
                y = maxPos;
            }
            else if (digits[i] > digits[maxPos])
            {
                maxPos = i;
            }
        }
        if (x != -1 && y != -1)
        {

            char temp = digits[x];
            digits[x] = digits[y];
            digits[y] = temp;

            return int.Parse(new string(digits));
        }
        return num;
    }
}