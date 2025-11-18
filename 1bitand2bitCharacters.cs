namespace LeetCode.bitand2bitCharacters;

public class Solution
{
    public bool IsOneBitCharacter(int[] bits)
    {
        int i = 0;
        int n = bits.Length;

        while (i < n - 1)
        {
            if (bits[i] == 1)
            {
                i += 2;
            }
            else
            {
                i += 1;
            }
        }

        return i == n - 1;
    }
}