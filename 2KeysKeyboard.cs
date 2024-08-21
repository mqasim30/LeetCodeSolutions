namespace LeetCode.KeysKeyboard2;
public class Solution
{
    public int MinSteps(int n)
    {
        if (n == 1) return 0;

        int steps = 0;
        int factor = 2;

        while (n > 1)
        {
            while (n % factor == 0)
            {
                steps += factor;
                n /= factor;
            }
            factor++;
        }

        return steps;
    }
}

