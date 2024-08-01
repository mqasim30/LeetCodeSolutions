namespace LeetCode.NumberofSeniorCitizens;

public class Solution
{
    public int CountSeniors(string[] details)
    {
        int ans = 0;
        foreach (var detail in details)
        {
            int age = int.Parse(detail.Substring(11, 2));
            if (age > 60)
            {
                ans++;
            }
        }
        return ans;
    }
}
