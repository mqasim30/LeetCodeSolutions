namespace LeetCode.CourseScheduleIV;

public class Solution
{

    public IList<bool> CheckIfPrerequisite(int numCourses, int[][] prerequisites, int[][] queries)
    {
        var nums = Enumerable.Range(0, numCourses).ToList();

        var child = new bool[numCourses, numCourses];

        foreach (var pair in prerequisites) child[pair[0], pair[1]] = true;

        for (int k = 0; k < numCourses; k++)
        {
            for (int i = 0; i < numCourses; i++)
            {
                for (int j = 0; j < numCourses; j++)
                {
                    if (child[i, k] && child[k, j])
                    {
                        child[i, j] = true;
                    }
                }
            }
        }

        var result = new List<bool>();
        foreach (var pair in queries) result.Add(child[pair[0], pair[1]]);

        return result;
    }
}