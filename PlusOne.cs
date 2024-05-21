namespace LeetCode.PlusOne
{
    public class Solution
    {
        public int[] PlusOne(int[] digits)
        {
            int index = 0;
            int carry = 0;

            if (digits[digits.Length - 1] <= 8)
            {
                digits[digits.Length - 1] += 1;
            }
            else
            {
                Array.Reverse(digits);
                digits[0] = 0;
                carry = 1;
                index += 1;
                while (carry != 0)
                {
                    if (index < digits.Length)
                    {
                        if (digits[index] <= 8)
                        {
                            digits[index] += 1;
                            carry = 0;
                            Array.Reverse(digits);
                            break;
                        }
                        else
                        {
                            digits[index] = 0;
                            carry = 1;
                            index += 1;
                        }
                    }
                    else
                    {

                        if (carry != 0)
                        {
                            Array.Resize(ref digits, digits.Length + 1);
                            digits[digits.Length - 1] = carry;
                        }
                        Array.Reverse(digits);
                        break;
                    }

                }
            }
            return digits;
        }
    }
    // public class Program
    // {
    //     public static void Main(string[] args)
    //     {
    //         Solution solution = new Solution();
    //         int[] digits = [1, 2, 3];
    //         // Console.WriteLine(string.Join("", solution.PlusOne([1, 2, 3])));
    //         // Console.WriteLine(string.Join("", solution.PlusOne([4, 3, 2, 1])));
    //         // Console.WriteLine(string.Join("", solution.PlusOne([9])));
    //         Console.WriteLine(string.Join("", solution.PlusOne([9,9,9,9])));
    //         //Console.WriteLine(string.Join("", solution.PlusOne([2,0,9])));
    //         //Console.WriteLine(string.Join("", solution.PlusOne([9,1,1,9])));
    //         //Console.WriteLine(string.Join("", solution.PlusOne([9,8,9])));
    //     }
    // }
}