
namespace LeetCode.GreatestCommonDivisorofStrings;

public class Solution
{
    public string GcdOfStrings(string str1, string str2)
    {
        string result = "";
        if (!(str1 + str2).Equals(str2 + str1))
        {
            return "";
        }
        int gcdLength = Gcd(str1.Length, str2.Length);
        result = str1.Substring(0, gcdLength);
        return result;
    }

    private int Gcd(int length1, int length2)
    {
        while (length2 != 0)
        {
            int temp = length2;
            length2 = length1 % length2;
            length1 = temp;
        }
        return length1;
    }
}

// public class Program
// {
//     public static void Main(string[] args)
//     {
//         Solution solution = new Solution();
//         //string str1 = "ABCABC", str2 = "ABC";
//         string str1 = "ABABAB", str2 = "ABAB";
//         //string str1 = "Leet", str2 = "Code";
//         Console.WriteLine(solution.GcdOfStrings(str1, str2));
//     }
// }