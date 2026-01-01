namespace LeetCode.PlusOne;

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
