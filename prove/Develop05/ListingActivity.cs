using System;
using System.Collections.Generic;
using System.Threading;

public class ListingActivity : MindfulnessActivity
{
    private List<string> _prompts = new List<string>
    {
        "Who are the people in your life that you deeply appreciate, like family or close friends?",
        "What personal strengths do you possess that have helped you overcome challenges?",
        "Who are some of the people you've helped recently, like in your community or family?",
        "When have you felt a deep sense of gratitude or connection, like in a spiritual or emotional moment?",
        "Who are some of your personal heroes, like public figures, leaders, or community members?"
    };

    public ListingActivity(int duration) : base(duration) { }

    public void PerformActivity()
    {
        StartMessage("Listing Activity", "This activity will help you reflect on the good things in your life by having you list as many things as you can in a certain area.");

        string prompt = _prompts.OrderBy(x => Guid.NewGuid()).First();
        Console.WriteLine(prompt);
        PauseWithAnimation(3);

        var items = new List<string>();
        var startTime = DateTime.Now;
        while ((DateTime.Now - startTime).TotalSeconds < _duration)
        {
            Console.Write("List an item: ");
            string item = Console.ReadLine();
            items.Add(item);
        }

        Console.WriteLine($"You listed {items.Count} items.");
        EndMessage("Listing Activity");
    }
}
