namespace LeetCode.FindthePunishmentNumberofanInteger;

public class Solution
{
    public int PunishmentNumber(int n)
    {
        int result = 1;
        for (int i = 9; i <= n; i++)
        {
            int p = i * i;
            for (int d1 = 10; d1 < p; d1 *= 10)
            {
                int q1 = Math.DivRem(p, d1, out int r1);
                int m1 = i - r1;
                if (m1 < 0) break;
                if (m1 == q1) { result += p; break; }
                for (int d2 = 10; d2 < q1; d2 *= 10)
                {
                    int q2 = Math.DivRem(q1, d2, out int r2);
                    int m2 = m1 - r2;
                    if (m2 == q2) { result += p; goto nextI; }
                    for (int d3 = 10; d3 < q2; d3 *= 10)
                    {
                        int q3 = Math.DivRem(q2, d3, out int r3);
                        if (m2 == q3 + r3) { result += p; goto nextI; }
                    }
                }
            }
        nextI:;
        }
        return result;
    }
}