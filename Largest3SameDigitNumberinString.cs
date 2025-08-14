namespace LeetCode.Largest3SameDigitNumberinString;

public class Solution
{
    public string LargestGoodInteger(string num)
    {
        int target = -1;
        for (int i = 0; i < num.Length - 2; i++)
        {
            if (num[i] == num[i + 1] && num[i] == num[i + 2])
            {
                int current = int.Parse(num.Substring(i, 3));
                if (current > target)
                {
                    target = current;
                }
            }
        }
        if (target != -1)
        {
            if (target == 0)
            {
                return target + "00";
            }
            return target.ToString();
        }
        return "";
    }
}