namespace LeetCode.LetterThePossibilities;
using System.Text;
public class Solution
{
    public int NumTilePossibilities(string tiles)
    {
        var result = new HashSet<string>();
        var visited = new bool[tiles.Length];
        Array.Sort(tiles.ToCharArray());
        Backtrack(tiles, visited, result, new StringBuilder());
        return result.Count;
    }

    private void Backtrack(string tiles, bool[] visited, HashSet<string> result, StringBuilder sb)
    {
        if (sb.Length > 0)
        {
            result.Add(sb.ToString());
        }

        for (int i = 0; i < tiles.Length; i++)
        {
            if (visited[i] || (i > 0 && tiles[i] == tiles[i - 1] && !visited[i - 1]))
            {
                continue;
            }

            visited[i] = true;
            sb.Append(tiles[i]);
            Backtrack(tiles, visited, result, sb);
            sb.Remove(sb.Length - 1, 1);
            visited[i] = false;
        }
    }
}