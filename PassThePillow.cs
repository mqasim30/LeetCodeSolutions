namespace LeetCode.PassThePillow;

public class Solution
{
    public int PassThePillow(int n, int time)
    {
        int chunks = time / (n - 1);
        return chunks % 2 == 0 ? (time % (n - 1) + 1) : (n - time % (n - 1));
    }
}
