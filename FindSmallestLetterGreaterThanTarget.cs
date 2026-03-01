namespace LeetCode.FindSmallestLetterGreaterThanTarget;

public class Solution
{
    public char NextGreatestLetter(char[] letters, char target)
    {
        int lo = 0, hi = letters.Length - 1;
        while (lo <= hi)
        {
            var mid = lo + (hi - lo) / 2;
            if (letters[mid] <= target) lo = mid + 1;
            else hi = mid - 1;
        }

        return letters[lo % letters.Length];
    }
}