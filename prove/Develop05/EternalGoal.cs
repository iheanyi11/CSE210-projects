using System;

class EternalGoal : Goal
{
    private int points;

    public override void SetGoalDetails()
    {
        base.SetGoalDetails();

        Console.Write("Enter points for completing the Eternal Goal: ");
        string input = Console.ReadLine();
        if (!int.TryParse(input, out points))
        {
            Console.WriteLine("Invalid points. Goal creation canceled.");
            return;
        }
    }

    public override bool IsComplete()
    {
        return false; // Eternal goals are never complete
    }

    public override int GetPoints()
    {
        return points;
    }

    public override void RecordEvent()
    
    {
        Console.WriteLine($"Recording event for Eternal Goal: {name}");
        points += 100;
    }

    public override string DisplayGoalDetails()
    {
        string status = IsComplete() ? "[X]" : "[ ]";
        return $"{status} {name} ({description}) - Points: {points}";
    }
}