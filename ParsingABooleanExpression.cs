namespace LeetCode.ParsingABooleanExpression;

public class Solution
{
    // Function to handle AND operation
    private bool Andd(string exp)
    {
        int n = exp.Length, j = 0;
        string subexp = "";
        int active = 0;
        while (j < n)
        {
            // If we're not inside parentheses and encounter a comma
            if (active == 0 && exp[j] == ',')
            {
                // Evaluate the sub-expression, return false if it's false
                if (!ParseBoolExpr(subexp)) return false;
                subexp = ""; // Reset sub-expression
                j++;
                continue;
            }
            // Keep track of nested parentheses
            if (exp[j] == '(') active++;
            if (exp[j] == ')') active--;
            subexp += exp[j++]; // Build sub-expression
        }
        // Evaluate the last sub-expression
        if (!ParseBoolExpr(subexp)) return false;
        // If all sub-expressions are true, return true
        return true;
    }

    // Function to handle OR operation
    private bool Orr(string exp)
    {
        int n = exp.Length, j = 0;
        string subexp = "";
        int active = 0;
        while (j < n)
        {
            // If we're not inside parentheses and encounter a comma
            if (active == 0 && exp[j] == ',')
            {
                // Evaluate the sub-expression, return true if it's true
                if (ParseBoolExpr(subexp)) return true;
                subexp = ""; // Reset sub-expression
                j++;
                continue;
            }
            // Keep track of nested parentheses
            if (exp[j] == '(') active++;
            if (exp[j] == ')') active--;
            subexp += exp[j++]; // Build sub-expression
        }
        // Evaluate the last sub-expression
        if (ParseBoolExpr(subexp)) return true;
        // If all sub-expressions are false, return false
        return false;
    }

    // Main function to parse boolean expressions
    public bool ParseBoolExpr(string exp)
    {
        int n = exp.Length;
        // Base case: single character 't' or 'f'
        if (n == 1) return (exp[0] == 't');
        // Handle NOT operation
        if (exp[0] == '!') return !ParseBoolExpr(exp.Substring(2, n - 3));
        // Handle AND operation
        if (exp[0] == '&') return Andd(exp.Substring(2, n - 3));
        // Handle OR operation
        if (exp[0] == '|') return Orr(exp.Substring(2, n - 3));
        // Default case (should not reach here if input is valid)
        return false;
    }
}