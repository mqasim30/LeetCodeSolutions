namespace LeetCode.RelativeRanks
{
    public class Solution
    {
        public string[] FindRelativeRanks(int[] score)
        {
            string[] result = new string[score.Length];
            Dictionary<int, string> keyValuePairs = new Dictionary<int, string>();
            for (int i = 0; i < score.Length; i++)
            {
                keyValuePairs.Add(score[i], "");
            }
            var sortedDictionary = keyValuePairs.OrderByDescending(keySelector => keySelector.Key);
            int count = 0;
            foreach (var item in sortedDictionary.Take(3))
            {
                if(count == 0){
                    keyValuePairs[item.Key] = "Gold Medal";
                    count++;
                }
                else if(count == 1){
                    keyValuePairs[item.Key] = "Silver Medal";
                    count++;
                }
                else{
                    keyValuePairs[item.Key] = "Bronze Medal";
                    count++;
                }
            }
            Console.WriteLine(count);
            foreach (var item in sortedDictionary.Skip(3))
            {
                count++;
                keyValuePairs[item.Key] = count.ToString();
            }
            int index = 0;
            foreach (var item in keyValuePairs)
            {
                result[index] = keyValuePairs[item.Key];
                index++;
            }
            return result;
        }
    }

//     public class Solution
// {
//     public string[] FindRelativeRanks(int[] score)
//     {
//         var places = Enumerable.Range(1, score.Length).ToArray();
//         var ranks = Array.ConvertAll(places, GetRank);
//         Array.Sort(score, places);
//         Array.Reverse(places);
//         Array.Sort(places, ranks);
//         return ranks;
//     }

//     public string GetRank(int i) => i switch
//     {
//         1 => "Gold Medal",
//         2 => "Silver Medal",
//         3 => "Bronze Medal",
//         var x => x.ToString(),
//     };
// }
    // public class Program
    // {
    //     public static void Main(string[] args)
    //     {
    //         Solution solution = new Solution();
    //         int[] ranks = [10,3,8,9,4];
    //         solution.FindRelativeRanks(ranks);
    //     }
    // }
}