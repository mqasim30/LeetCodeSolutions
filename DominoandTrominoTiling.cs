namespace LeetCode.DominoandTrominoTiling;

public class Solution
{
    public int NumTilings(int n)
    {
        if (n < 2)
            return n;

        const int mod = 1_000_000_007;
        var pState = (Full: 0L, Empty: 1L, Corner: 0L);

        for (var i = 0; i < n; i++)
        {
            var state = pState;

            state.Empty = (pState.Empty + pState.Full) % mod;
            state.Full = (pState.Empty + pState.Corner + pState.Corner) % mod;
            state.Corner = (pState.Empty + pState.Corner) % mod;

            pState = state;
        }

        return (int)pState.Empty;
    }
}