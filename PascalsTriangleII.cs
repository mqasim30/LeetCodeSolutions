namespace LeetCode.PascalsTriangleII
{
    public class Solution
    {
        public IList<int> GetRow(int numRows)
        {
            List<List<int>> pascalsNumbers = new List<List<int>>();
            int currentIndex = 0;
            while (currentIndex < numRows+1)
            {
                List<int> row = new List<int>();
                for (int j = 0; j <= currentIndex; j++)
                {
                    if (j == 0 || j == currentIndex)
                    {
                        row.Add(1);
                    }
                    else
                    {
                        row.Add(pascalsNumbers[currentIndex - 1][j - 1] + pascalsNumbers[currentIndex - 1][j]);
                    }
                }
                pascalsNumbers.Add(row);
                currentIndex++;
            }

            IList<IList<int>> result = pascalsNumbers.Cast<IList<int>>().ToList();
            PrintPascalsTriangle(result);
            return result[numRows];
        }

        public void PrintPascalsTriangle(IList<IList<int>> triangle)
        {
            for (int i = 0; i < triangle.Count; i++)
            {
                Console.Write(new string(' ', (triangle.Count - i - 1) * 2));

                for (int j = 0; j < triangle[i].Count; j++)
                {
                    Console.Write($"{triangle[i][j]} ");
                }

                Console.WriteLine();
            }
        }
    }

    // public class Program
    // {
    //     public static void Main(string[] args)
    //     {
    //         Solution solution = new Solution();
    //         foreach (var item in solution.GetRow(3))
    //         {
    //             Console.WriteLine(item);
    //         }
    //     }
    // }
}