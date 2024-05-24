namespace LeetCode.MaximumScoreWordsFormedByLetters
{
    public class Solution
    {
        public int MaxScoreWords(string[] words, char[] letters, int[] score)
        {
            int[] count = new int[26];
            int[] lettersCount = new int[26];

            foreach (char c in letters)
            {
                count[c - 'a']++;
            }

            int ans = 0;
            ans = backtracking(words, score, count, lettersCount, 0, 0, ans);
            return ans;
        }

        private int backtracking(String[] words, int[] score, int[] count, int[] lettersCount, int pos, int temp, int ans)
        {
            for (int i = 0; i < 26; i++)
            {
                if (lettersCount[i] > count[i]) return ans;
            }

            ans = Math.Max(ans, temp);

            for (int i = pos; i < words.Length; i++)
            {
                foreach (char c in words[i].ToCharArray())
                {
                    lettersCount[c - 'a']++;
                    temp += score[c - 'a'];
                }

                ans = backtracking(words, score, count, lettersCount, i + 1, temp, ans);

                foreach (char c in words[i].ToCharArray())
                {
                    lettersCount[c - 'a']--;
                    temp -= score[c - 'a'];
                }
            }

            return ans;
        }
    }
    // public class Program
    // {
    //     public static void Main(string[] args)
    //     {
    //         Solution solution = new Solution();
    //         int[] score = [1, 0, 9, 5, 0, 0, 3, 0, 0, 0, 0, 0, 0, 0, 2, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0];
    //         char[] letters = ['a', 'a', 'c', 'd', 'd', 'd', 'g', 'o', 'o'];
    //         string[] words = ["dog", "cat", "dad", "good"];
    //         System.Console.WriteLine(solution.MaxScoreWords(words, letters, score));
    //     }
    // }
}