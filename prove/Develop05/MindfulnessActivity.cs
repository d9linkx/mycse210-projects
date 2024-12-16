using System;
using System.IO;
using System.Threading;

public class MindfulnessActivity
{
    protected int _duration;

    public MindfulnessActivity(int duration)
    {
        _duration = duration;
    }

    public void StartMessage(string activityName, string description)
    {
        Console.WriteLine($"Starting {activityName}...");
        Console.WriteLine(description);
        Console.WriteLine($"Duration: {_duration} seconds");
        Console.WriteLine("Get ready, relax and focus...");
        PauseWithAnimation(3);
    }

    public void EndMessage(string activityName)
    {
        Console.WriteLine("Well done! You've done an amazing job!");
        Console.WriteLine($"You have completed the {activityName} activity for {_duration} seconds.");
        PauseWithAnimation(3);
        LogActivity(activityName);
    }

    public void PauseWithAnimation(int seconds)
    {
        string[] spinner = { "|", "/", "-", "\\" };
        for (int i = 0; i < seconds; i++)
        {
            Console.Write($"Loading... {spinner[i % 4]}", 0, 3);
            Thread.Sleep(1000); // pause for a second
            Console.SetCursorPosition(0, Console.CursorTop);
        }
        Console.WriteLine(""); // New line after animation
    }

    public void LogActivity(string activityName)
    {
        using (StreamWriter logFile = new StreamWriter("activity_log.txt", true))
        {
            logFile.WriteLine($"Activity: {activityName}, Duration: {_duration} seconds");
        }
    }
}
