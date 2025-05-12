namespace LeetCode.Finding3DigitEvenNumbers;

public class Solution
{
    public int[] FindEvenNumbers(int[] digits)
    {
        HashSet<int> nums = new HashSet<int>();
        int n = digits.Length;
        for (int i = 0; i < n; ++i)
        {
            for (int j = 0; j < n; ++j)
            {
                for (int k = 0; k < n; ++k)
                {
                    if (i == j || j == k || i == k)
                    {
                        continue;
                    }
                    int num = digits[i] * 100 + digits[j] * 10 + digits[k];
                    if (num >= 100 && num % 2 == 0)
                    {
                        nums.Add(num);
                    }
                }
            }
        }
        List<int> res = nums.ToList();
        res.Sort();
        return res.ToArray();
    }
}