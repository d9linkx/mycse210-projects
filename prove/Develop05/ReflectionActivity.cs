using System;
using System.Collections.Generic;
using System.Linq;

public class ReflectionActivity : MindfulnessActivity
{
    private List<string> _prompts = new List<string>
    {
        "Think of a time when you helped someone in need, like offering a helping hand during a tough moment.",
        "Think of a time when you overcame a difficult challenge, like finishing a project against all odds.",
        "Think of a time when you supported a friend or family member, showing the strength of your bond.",
        "Think of a time when you stood up for what’s right, even when it was tough."
    };

    private List<string> _questions = new List<string>
    {
        "Why was this experience so meaningful to you? What lessons did you learn?",
        "Have you faced a similar situation before? How did this one differ?",
        "What was your first step when you took on this challenge?",
        "How did you feel after overcoming that obstacle? Were you proud of yourself?",
        "How did this experience shape your perspective on life?",
        "What aspect of this experience would you like to apply in other areas of your life?",
        "What did you learn about yourself through this experience?",
        "How can you hold on to this lesson in the future, when things get tough?"
    };

    public ReflectionActivity(int duration) : base(duration) { }

    public void PerformActivity()
    {
        StartMessage("Reflection Activity", "This activity will help you reflect on times in your life when you have shown strength and resilience. This will help you recognize the power you have and how you can use it in other aspects of your life.");

        string prompt = _prompts.OrderBy(x => Guid.NewGuid()).First();
        Console.WriteLine(prompt);
        PauseWithAnimation(3);

        for (int i = 0; i < _duration / 10; i++)
        {
            string question = _questions.OrderBy(x => Guid.NewGuid()).First();
            Console.WriteLine(question);
            PauseWithAnimation(10);
        }

        EndMessage("Reflection Activity");
    }
}
