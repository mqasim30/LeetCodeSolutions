namespace LeetCode.FindKthBitinNthBinaryString;

public sealed class Solution
{
    private readonly static Dictionary<int, string> c = new Dictionary<int, string>
    {
        { 1, "0" },
        { 2, "011" },
        { 3, "0111001" },
        { 4, "011100110110001" }
    };

    public char FindKthBit(int n, int k)
    {
        if (c.ContainsKey(n))
        {
            return c[n][k - 1];
        }

        var sb = new StringBuilder();
        sb.Append('0');
        var st = new Stack<char>();

        for (int i = 1; i <= n; i++)
        {
            foreach (var chunk in sb.GetChunks())
            {
                foreach (var c in chunk.Span)
                {
                    st.Push(c == '0' ? '1' : '0');
                }
            }

            sb.Append('1');

            while (st.Count > 0)
            {
                sb.Append(st.Pop());
            }

            if (!c.ContainsKey(i))
            {
                c.Add(i, sb.ToString());
            }
        }

        //return sb.ToString()[k - 1];
        return c[n][k - 1];
    }
}