namespace LeetCode.CrawlerLogFolder;

public class Solution
{
    public int MinOperations(string[] logs)
    {
        Stack<string> pathsStack = new Stack<string>();

        foreach (string log in logs)
        {
            if (log == "../")
            {
                if (pathsStack.Count > 0)
                {
                    pathsStack.Pop();
                }
            }
            else if (log != "./")
            {
                pathsStack.Push(log);
            }
        }

        return pathsStack.Count;
    }
}

// public class Program
// {
//     public static void Main(string[] args)
//     {
//         Solution solution = new Solution();
//         string[] logs = ["d1/", "d2/", "../", "d21/", "./"];
//         Console.WriteLine(solution.MinOperations(logs));
//     }
// }