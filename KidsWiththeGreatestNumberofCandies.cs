namespace LeetCode.KidsWiththeGreatestNumberofCandies;
public class Solution
{
    public IList<bool> KidsWithCandies(int[] candies, int extraCandies)
    {
        IList<bool> results = new List<bool>();
        int max = candies.Max();
        for (int i = 0; i < candies.Length; i++)
        {
            if ((candies[i] + extraCandies) >= max)
            {
                results.Add(true);
            }
            else
            {
                results.Add(false);
            }
        }
        return results;
    }
}
public class Program
{
    public static void Main(string[] args)
    {
        Solution solution = new Solution();
        int[] candies = [2, 3, 5, 1, 3];
        int extraCandies = 3;
        Console.WriteLine(solution.KidsWithCandies(candies, extraCandies));
    }
}