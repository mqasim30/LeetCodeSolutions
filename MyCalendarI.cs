namespace LeetCode.MyCalendarI;
public class MyCalendar
{
    private SortedList<int, int> Starts;
    public MyCalendar()
    {
        Starts = new SortedList<int, int>();
    }

    public bool Book(int start, int end)
    {
        try
        {
            Starts.Add(start, end);
        }
        catch
        {
            return false;
        }

        var newPosition = Starts.IndexOfKey(start);
        if ((newPosition > 0 && Starts.GetValueAtIndex(newPosition - 1) > start) || //not the first, check if starting before the previous ended
            (newPosition < Starts.Count - 1 && end > Starts.GetKeyAtIndex(newPosition + 1)))
        { // not the last, check if ending after the next started
            Starts.RemoveAt(newPosition);
            return false;
        }

        return true;
    }
}