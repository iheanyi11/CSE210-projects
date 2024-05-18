using System;
using System.Threading;

class MeditationActivity : Activity
{
    public MeditationActivity() : base("Meditation Activity", "This activity will guide you through a peaceful meditation to calm your mind.")
    {
    }

    public override void Run()
    {
        DisplayStartingMessage();
        Console.WriteLine("Let's begin the meditation...");

        // Implement your meditation logic here, e.g., display soothing messages, calming background music, etc.
        for (int i = 0; i < _duration; i++)
        {
            Console.WriteLine("Inhale... Exhale...");
            Thread.Sleep(1000);
        }

        DisplayEndingMessage();
    }
}