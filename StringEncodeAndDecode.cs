namespace LeetCode.StringEncodeAndDecode
{
    public class Solution
    {
        public string Encode(IList<string> strs)
        {
            return string.Concat(strs.Select(s => $"{s.Length};{s}"));
        }

        public List<string> Decode(string s)
        {
            List<string> result = new List<string>();
            int index = 0;
            for (int i = 0; i < s.Length;)
            {
                index = i;
                while (s[index] != ';')
                {
                    index++;
                }
                int.TryParse(s.Substring(i, index - i), out var strLength);
                index++;
                result.Add(s.Substring(index, strLength));
                i = index + strLength;
            }
            return result;
        }
    }

    // public class Program
    // {
    //     public static void Main(string[] args)
    //     {
    //         Solution solution = new Solution();
    //         List<string> strings = ["we","say",":","yes","!@#$%^&*()"];
    //         string result = solution.Encode(strings);
    //         Console.WriteLine(result);
    //         solution.Decode(result);
    //     }
    // }

}