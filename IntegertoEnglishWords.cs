namespace LeetCode.IntegertoEnglishWords;
public class Solution
{
    public string NumberToWords(int num)
    {
        if (num == 0)
            return "Zero";

        string[] largeUnits = new string[] { "Thousand", "Million", "Billion" };
        string result = ConvertThreeDigitsToWords(num % 1000);
        num /= 1000;

        for (int i = 0; i < largeUnits.Length; i++)
        {
            if (num > 0 && num % 1000 > 0)
            {
                result = ConvertThreeDigitsToWords(num % 1000) + largeUnits[i] + " " + result;
            }
            num /= 1000;
        }

        return result.Trim();
    }

    private string ConvertThreeDigitsToWords(int num)
    {
        string[] singleDigits = new string[] { "Zero", "One", "Two", "Three", "Four", "Five", "Six", "Seven", "Eight", "Nine" };
        string[] teens = new string[] { "Ten", "Eleven", "Twelve", "Thirteen", "Fourteen", "Fifteen", "Sixteen", "Seventeen", "Eighteen", "Nineteen" };
        string[] tens = new string[] { "", "", "Twenty", "Thirty", "Forty", "Fifty", "Sixty", "Seventy", "Eighty", "Ninety" };

        string result = "";

        if (num > 99)
        {
            result += singleDigits[num / 100] + " Hundred ";
        }

        num %= 100;

        if (num < 20 && num > 9)
        {
            result += teens[num % 10] + " ";
        }
        else
        {
            if (num > 19)
            {
                result += tens[num / 10] + " ";
            }
            num %= 10;
            if (num > 0)
            {
                result += singleDigits[num] + " ";
            }
        }

        return result;
    }
}
