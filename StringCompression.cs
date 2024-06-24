namespace LeetCode.StringCompression;

using System.Text;

public class Solution
{
    public int Compress(char[] chars)
    {
        int writeIndex = 0;
        int count = 1;
        char prev = chars[0];

        for (int i = 1; i < chars.Length; i++)
        {
            if (chars[i] == prev)
            {
                count++;
            }
            else
            {
                chars[writeIndex++] = prev;
                if (count > 1)
                {
                    foreach (char digit in count.ToString())
                    {
                        chars[writeIndex++] = digit;
                    }
                }

                prev = chars[i];
                count = 1;
            }
        }

        chars[writeIndex++] = prev;
        if (count > 1)
        {
            foreach (char digit in count.ToString())
            {
                chars[writeIndex++] = digit;
            }
        }

        return writeIndex;
    }
}

// public class Program
// {
//     public static void Main(string[] args)
//     {
//         Solution solution = new Solution();
//         char[] chars = ['a', 'b', 'b', 'b', 'b', 'b', 'b', 'b', 'b', 'b', 'b', 'b', 'b', 'c'];
//         Console.WriteLine(solution.Compress(chars));
//     }
// }