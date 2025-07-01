namespace LeetCode.LexicographicallyMinimumStringAfterRemovingStars;

public class Solution
{
    public string ClearStars(string s)
    {
        Stack<int>[] cnt = new Stack<int>[26];
        for (int i = 0; i < 26; i++)
        {
            cnt[i] = new Stack<int>();
        }
        char[] arr = s.ToCharArray();
        for (int i = 0; i < arr.Length; i++)
        {
            if (arr[i] != '*')
            {
                cnt[arr[i] - 'a'].Push(i);
            }
            else
            {
                for (int j = 0; j < 26; j++)
                {
                    if (cnt[j].Count > 0)
                    {
                        arr[cnt[j].Pop()] = '*';
                        break;
                    }
                }
            }
        }
        return new string(Array.FindAll(arr, c => c != '*'));
    }
}