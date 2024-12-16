using System;
using System.Threading;

public class BreathingActivity : MindfulnessActivity
{
    public BreathingActivity(int duration) : base(duration) { }

    public void PerformActivity()
    {
        StartMessage("Breathing Activity", "This activity will help you relax by walking you through breathing in and out slowly. Clear your mind and focus on your breathing.");

        for (int i = 0; i < _duration / 2; i++)
        {
            Console.WriteLine("Breathe in... breathe deeply... feel at peace...");
            PauseWithAnimation(3);
            Console.WriteLine("Breathe out... release all the stress and tension...");
            PauseWithAnimation(3);
        }

        EndMessage("Breathing Activity");
    }
}
