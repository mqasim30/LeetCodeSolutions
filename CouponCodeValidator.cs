namespace LeetCode.CouponCodeValidator;

using System.Text.RegularExpressions;
public class Solution
{

    public IList<string> ValidateCoupons(string[] code, string[] businessLine, bool[] isActive)
    {
        int n = code.Length;
        string pattern = @"^[a-zA-Z0-9_]+$";
        Regex regex = new Regex(pattern);

        Dictionary<string, List<string>> businessLineCodes = new Dictionary<string, List<string>>
        {
            { "electronics", new List<string>() },
            { "grocery", new List<string>() },
            { "pharmacy", new List<string>() },
            { "restaurant", new List<string>() }
        };

        for (int i = 0; i < n; i++)
        {
            if (!string.IsNullOrEmpty(code[i])
                && regex.IsMatch(code[i])
                && isActive[i]
                && businessLineCodes.ContainsKey(businessLine[i]))
            {
                businessLineCodes[businessLine[i]].Add(code[i]);
            }
        }

        List<string> result = new List<string>();
        foreach (KeyValuePair<string, List<string>> kvp in businessLineCodes)
        {
            kvp.Value.Sort((a, b) => string.Compare(a, b, StringComparison.Ordinal));
            result.AddRange(kvp.Value);
        }

        return result;
    }
}