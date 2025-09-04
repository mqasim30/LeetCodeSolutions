namespace LeetCode.FindClosestPerson;

public class Solution
{
    public int FindClosest(int x, int y, int z)
    {
        int dxz = Math.Abs(x - z), dyz = Math.Abs(y - z);
        if (dxz < dyz)
        {
            return 1;
        }
        else if (dxz > dyz)
        {
            return 2;
        }
        else
        {
            return 0;
        }
    }
}