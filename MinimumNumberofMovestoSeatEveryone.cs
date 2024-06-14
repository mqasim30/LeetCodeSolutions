namespace LeetCode.MinimumNumberofMovestoSeatEveryone;

public class Solution
{
    public int MinMovesToSeat(int[] seats, int[] students)
    {
        int result = 0;
        Array.Sort(seats);
        Array.Sort(students);

        for (int i = 0; i < seats.Length; i++)
        {
            result += Math.Abs(seats[i] - students[i]);
        }
        return result;
    }
}

// public class Program
// {
//     static void Main(string[] args)
//     {
//         Solution solution = new Solution();
//         int[] seats = [3, 1, 5], students = [2, 7, 4];
//         Console.WriteLine(solution.MinMovesToSeat(seats, students));
//     }
// }
