using System.Text;

namespace LeetCode.ReplaceWords;

public class Solution
{
    public string ReplaceWords(IList<string> dictionary, string sentence)
    {
        List<string> strings = sentence.Split(' ').ToList();
        List<string> dict = (List<string>)dictionary;
        dict.Sort((x, y) => x.Length.CompareTo(y.Length));
        StringBuilder result = new StringBuilder();
        for (int i = 0; i < strings.Count; i++)
        {
            bool ContainsDictWord = false;
            foreach (var str in dict)
            {
                if (strings[i].Contains(str))
                {
                    int newIndex = strings[i].IndexOf(str);
                    if (newIndex == 0)
                    {
                        ContainsDictWord = true;
                        result.Append(str);
                        result.Append(' ');
                        break;
                    }
                }
            }
            if (!ContainsDictWord)
            {
                result.Append(strings[i]);
                result.Append(' ');
            }
        }

        return result.ToString().TrimEnd();
    }
}
// public class Program
// {
//     static void Main(string[] args)
//     {
//         Solution solution = new Solution();
//         List<string> dictionary = ["catt", "cat", "bat", "rat"];
//         string sentence = "the cattle was rattled by the battery";
//         Console.WriteLine(solution.ReplaceWords(dictionary, sentence));
//     }
// }
