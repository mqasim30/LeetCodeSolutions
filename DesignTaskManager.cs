namespace LeetCode.DesignTaskManager;

public class TaskManager {
 // task-(userid, priority) dict:
 private Dictionary<int, (int uId, int pri)> dict;

 // sorted set items:
 private SortedSet<(int pri, int tId, int uId)> sortedSet;

 public class SetComp : IComparer<(int pri, int tId, int uId)>
 {
     public int Compare((int pri, int tId, int uId) a, (int pri, int tId, int uId) b)
     {
         if (a.pri != b.pri)
         {
             return b.pri.CompareTo(a.pri); // Higher priority first
         }

         if (a.tId != b.tId)
             return b.tId.CompareTo(a.tId);     // Higher taskId first

         return a.uId.CompareTo(b.uId);
     }
 }
    public TaskManager(IList<IList<int>> tasks) {
        dict = new Dictionary<int, (int uId, int pri)>();
sortedSet = new SortedSet<(int pri, int tId, int uId)>(new SetComp());

foreach (var task in tasks)
{
    int uId = task[0], tId = task[1], pri = task[2];
    Add(uId, tId, pri);
}
    }
    
      public void Add(int userId, int taskId, int priority)
  {
      dict[taskId] = (userId, priority);
      sortedSet.Add((priority, taskId, userId));
  }

  public void Edit(int taskId, int newPriority)
  {
      if (dict.TryGetValue(taskId, out var task))
      {
          sortedSet.Remove((task.pri, taskId, task.uId));
          dict[taskId] = (task.uId, newPriority);
          sortedSet.Add((newPriority, taskId, task.uId));
      }
  }

  public void Rmv(int taskId)
  {
      if (dict.TryGetValue(taskId, out var task))
      {
          sortedSet.Remove((task.pri, taskId, task.uId));
          dict.Remove(taskId);
      }
  }

  public int ExecTop()
  {
      if (sortedSet.Count == 0)
          return -1;

      var topTask = sortedSet.First();
      sortedSet.Remove(topTask);
      dict.Remove(topTask.tId);

      return topTask.uId;
  }
}

/**
 * Your TaskManager object will be instantiated and called as such:
 * TaskManager obj = new TaskManager(tasks);
 * obj.Add(userId,taskId,priority);
 * obj.Edit(taskId,newPriority);
 * obj.Rmv(taskId);
 * int param_4 = obj.ExecTop();
 */