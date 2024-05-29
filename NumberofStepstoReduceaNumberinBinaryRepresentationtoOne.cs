namespace LeetCode.NumberofStepstoReduceaNumberinBinaryRepresentationtoOne
{
    public class Solution
    {
        public int NumSteps(string s)
        {
            int l = s.Length - 1;
            int carry = 0;
            int count = 0;

            while (l > 0)
            {
                if (Char.GetNumericValue(s[l]) + carry == 0)
                {
                    carry = 0;
                    count++;
                }
                else if (Char.GetNumericValue(s[l]) + carry == 2)
                {
                    carry = 1;
                    count++;
                }
                else
                {
                    carry = 1;
                    count += 2;
                }
                l--;
            }

            if (carry == 1)
            {
                count++;
            }

            return count;
        }
    }
    // public class Program
    // {
    //     public static void Main(string[] args)
    //     {
    //         Solution solution = new Solution();
    //         solution.NumSteps("110");
    //     }
    // }
}