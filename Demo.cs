using System;
using System.Collections.Generic;

public class TaskScheduler
{
    private PriorityQueue<string, int> priorityQueue;

    public TaskScheduler()
    {
        priorityQueue = new PriorityQueue<string, int>();
    }

    public void AddTask(string task, int priority)
    {
        priorityQueue.Enqueue(task, priority);
    }

    public string GetNextTask()
    {
        if (priorityQueue.Count > 0)
        {
            string result = priorityQueue.Dequeue();
            return result;
        }
        else
        {
            return "No tasks available.";
        }
    }
}

// class Program
// {
//     static void Main(string[] args)
//     {
//         TaskScheduler scheduler = new TaskScheduler();

//         // Adding tasks with priorities
//         scheduler.AddTask("Task 1", -2);
//         scheduler.AddTask("Task 2", -1);
//         scheduler.AddTask("Task 3", -3);

//         // Getting and processing tasks in priority order
//         Console.WriteLine("Next task: " + scheduler.GetNextTask());  // Task 3
//         Console.WriteLine("Next task: " + scheduler.GetNextTask());  // Task 1
//         Console.WriteLine("Next task: " + scheduler.GetNextTask());  // Task 2

//         // Trying to get a task when no tasks are available
//         Console.WriteLine("Next task: " + scheduler.GetNextTask());  // No tasks available.
//     }
// }
