namespace LeetCode.PowerofTwo;

public class Solution
{
    public bool IsPowerOfTwo(int n)
    {
        if (n < 1)
            return false;

        while (n >= 2)
        {
            if ((n % 2 != 0 && n != 1))
                return false;

            n = n / 2;
        }

        return true;
    }
}