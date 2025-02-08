namespace LeetCode.FindtheNumberofDistinctColorsAmongtheBalls;


public class Solution {
    public int[] QueryResults(int limit, int[][] queries) {
        int[] result=new int[queries.Length];

        Dictionary<int, int> ballColor=new(queries.Length),
            colorCount=new(queries.Length);

        for(int i=0; i<queries.Length; i++) {
            var query=queries[i];
            int ballNumber=query[0],
                newColor=query[1],
                prevColor=ballColor.GetValueOrDefault(ballNumber);
            if(prevColor>0 && --colorCount[prevColor]==0) {
                colorCount.Remove(prevColor);
            }
            ballColor[ballNumber]=newColor;
            colorCount[newColor]=colorCount.GetValueOrDefault(newColor)+1;

            result[i]=colorCount.Count;
        }
        return result;
    }
}