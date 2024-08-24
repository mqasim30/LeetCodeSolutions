namespace LeetCode.FindtheClosestPalindrome;
public class Solution {
    public string NearestPalindromic(string numberStr) {
        long number = long.Parse(numberStr);
        if (number <= 10) return (number - 1).ToString();
        if (number == 11) return "9";

        int length = numberStr.Length;
        long leftHalf = long.Parse(numberStr.Substring(0, (length + 1) / 2));
        
        // Generate possible palindrome candidates
        long[] palindromeCandidates = new long[5];
        palindromeCandidates[0] = GeneratePalindromeFromLeft(leftHalf - 1, length % 2 == 0);
        palindromeCandidates[1] = GeneratePalindromeFromLeft(leftHalf, length % 2 == 0);
        palindromeCandidates[2] = GeneratePalindromeFromLeft(leftHalf + 1, length % 2 == 0);
        palindromeCandidates[3] = (long)Math.Pow(10, length - 1) - 1;
        palindromeCandidates[4] = (long)Math.Pow(10, length) + 1;

        long nearestPalindrome = 0;
        long minDifference = long.MaxValue;

        // Find the nearest palindrome
        foreach (long candidate in palindromeCandidates) {
            if (candidate == number) continue;
            long difference = Math.Abs(candidate - number);
            if (difference < minDifference || (difference == minDifference && candidate < nearestPalindrome)) {
                minDifference = difference;
                nearestPalindrome = candidate;
            }
        }

        return nearestPalindrome.ToString();
    }

    private long GeneratePalindromeFromLeft(long leftHalf, bool isEvenLength) {
        long palindrome = leftHalf;
        if (!isEvenLength) leftHalf /= 10;  // Skip the middle digit for odd length numbers
        
        // Generate the second half by mirroring the first half
        while (leftHalf > 0) {
            palindrome = palindrome * 10 + leftHalf % 10;
            leftHalf /= 10;
        }
        
        return palindrome;
    }
}
