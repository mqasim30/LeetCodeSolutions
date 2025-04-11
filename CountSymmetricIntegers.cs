namespace LeetCode.CountSymmetricIntegers;

public class Solution
{
    public int CountSymmetricIntegers(int low, int high)
    {
        int count = 0;
        for (int i = low; i <= high; i++)
        {
            if (IsSymmetric(i))
            {
                count++;
            }
        }
        return count;
    }

    private bool IsSymmetric(int num)
    {
        string str = num.ToString();
        int len = str.Length;
        if (len % 2 != 0) return false; // Must be even length

        int half = len / 2;
        int leftSum = 0, rightSum = 0;

        for (int i = 0; i < half; i++)
        {
            leftSum += str[i] - '0';
            rightSum += str[i + half] - '0';
        }

        return leftSum == rightSum;
    }
}