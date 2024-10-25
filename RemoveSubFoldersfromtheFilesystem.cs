namespace LeetCode.RemoveSubFoldersfromtheFilesystem;

public class Solution
{
    public IList<string> RemoveSubfolders(string[] folder)
    {
        // Sort the folders lexicographically so parent folders come before their subfolders
        Array.Sort(folder);

        // Initialize result list with the first folder
        IList<string> ans = new List<string>();
        ans.Add(folder[0]);

        // Iterate through remaining folders starting from index 1
        for (int i = 1; i < folder.Length; i++)
        {
            // Get the last added folder path and add a trailing slash
            string lastFolder = ans[ans.Count - 1] + "/";

            // Check if current folder starts with lastFolder
            // If it doesn't start with lastFolder, then it's not a subfolder
            if (!folder[i].StartsWith(lastFolder))
            {
                ans.Add(folder[i]);
            }
        }

        return ans;
    }
}