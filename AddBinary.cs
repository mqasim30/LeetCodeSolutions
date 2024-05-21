namespace LeetCode.AddBinary
{
    public class Solution
    {
        public string AddBinary(string a, string b)
        {
            a = new string(a.Reverse().ToArray());
            b = new string(b.Reverse().ToArray());
            string result = "";
            int carry = 0;

            for (int i = 0; i < Math.Max(a.Length, b.Length); i++)
            {
                int digit1 = 0;
                int digit2 = 0;

                if (i < a.Length)
                {
                    digit1 = a[i] - '0';
                }
                else
                {
                    digit1 = 0;
                }

                if (i < b.Length)
                {
                    digit2 = b[i] - '0';
                }
                else
                {
                    digit2 = 0;
                }
                int sum = digit1 + digit2 + carry;
                result = (sum % 2).ToString() + result;
                carry = sum / 2;
            }
            if (carry != 0)
            {
                result = carry + result;
            }
            return result;
        }
    }
    // public class Program
    // {
    //     public static void Main(string[] args)
    //     {
    //         Solution solution = new Solution();
    //         Console.WriteLine(solution.AddBinary("11", "1"));
    //         Console.WriteLine(solution.AddBinary("1010", "1011"));
    //         Console.WriteLine(solution.AddBinary("1111", "1111"));
    //         Console.WriteLine(solution.AddBinary("10100000100100110110010000010101111011011001101110111111111101000000101111001110001111100001101", "110101001011101110001111100110001010100001101011101010000011011011001011101111001100000011011110011"));
    //         Console.WriteLine(solution.AddBinary("1011", "10"));
    //     }
    // }
}