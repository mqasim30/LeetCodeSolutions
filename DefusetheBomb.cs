namespace LeetCode.DefusetheBomb
{
    public class Solution
    {
        public int[] Decrypt(int[] code, int k)
        {

            int[] result = new int[code.Length];

            if (k == 0) return result;

            for (int i = 0; i < code.Length; i++)
            {
                int sum = 0;
                int count = Math.Abs(k);
                int j = i;
                while (count > 0)
                {
                    Console.WriteLine("j + code.Length = " + (j + code.Length));
                    j = (j + code.Length + (k > 0 ? 1 : -1)) % code.Length;
                    Console.WriteLine(j);
                    sum += code[j];
                    count--;
                }
                Console.WriteLine();
                result[i] = sum;
            }

            return result;
        }
    }
}