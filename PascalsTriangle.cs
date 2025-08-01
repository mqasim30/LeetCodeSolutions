namespace LeetCode.PascalsTraingle;

public class Solution
{
    public IList<IList<int>> Generate(int numRows)
    {
        List<List<int>> pascalsNumbers = new List<List<int>>();
        int currentIndex = 0;
        while (currentIndex < numRows)
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
        return result;
    }
}