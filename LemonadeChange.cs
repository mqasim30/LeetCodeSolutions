namespace LeetCode.LemonadeChange;

public class Solution
{
    public bool LemonadeChange(int[] bills)
    {
        int fiveDollars = 0;
        int tenDollars = 0;

        foreach (int bill in bills)
        {
            if (bill == 5)
            {
                fiveDollars++;
            }
            else if (bill == 10)
            {
                if (fiveDollars > 0)
                {
                    fiveDollars--;
                    tenDollars++;
                }
                else
                {
                    return false;
                }
            }
            else
            { // bill == 20
                if (fiveDollars > 0 && tenDollars > 0)
                {
                    fiveDollars--;
                    tenDollars--;
                }
                else if (fiveDollars >= 3)
                {
                    fiveDollars -= 3;
                }
                else
                {
                    return false;
                }
            }
        }

        return true;
    }
}
