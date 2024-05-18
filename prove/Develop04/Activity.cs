using System;
using System.Collections.Generic;
using System.Threading;

abstract class Activity
{
    protected string _name;
    protected string _description;
    protected int _duration;

    public Activity(string name, string description)
    {
        _name = name;
        _description = description;
    }

    public void DisplayStartingMessage()
    {
        Console.WriteLine($"Welcome to {_name}!");
        Console.WriteLine(_description);
        Console.Write("Enter the duration in seconds: ");
        _duration = Convert.ToInt32(Console.ReadLine());
        Console.WriteLine("Get ready to begin...");
        ShowSpinner(3); // Pause for 3 seconds
    }

    public void DisplayEndingMessage()
    {
        Console.WriteLine("Good job!");
        Console.WriteLine($"You have completed {_name} for {_duration} seconds.");
        ShowCountDown(3); // Pause for 3 seconds
    }

    public void ShowSpinner(int seconds)
    {
        for (int i = 0; i < seconds; i++)
        {
            Console.Write("/");
            Thread.Sleep(500);
            Console.Write("\b");
            Console.Write("-");
            Thread.Sleep(500);
            Console.Write("\b");
        }
    }

    public void ShowCountDown(int seconds)
    {
        for (int i = seconds; i > 0; i--)
        {
            Console.WriteLine($"...{_name} ending in {i} seconds...");
            Thread.Sleep(1000);
        }
    }

    // Abstract method to be implemented by derived classes
    public abstract void Run();
}