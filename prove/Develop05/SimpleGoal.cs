using System;

class SimpleGoal : Goal
{
    private int points;

    public override void SetGoalDetails()
    {
        base.SetGoalDetails();

        Console.Write("Enter points for completing the goal: ");
        string input = Console.ReadLine();
        if (!int.TryParse(input, out points))
        {
            Console.WriteLine("Invalid points. Goal creation canceled.");
        }
    }

    public override bool IsComplete()
{
    return complete;
}

    public override int GetPoints()
    {
        return points;
    }

    public override void RecordEvent()
    {
        complete = true;
    }

    public override string DisplayGoalDetails()
    {
        string status = IsComplete() ? "[X]" : "[ ]";
        return $"{status} {name} ({description}) - Points: {points}";
    }
}