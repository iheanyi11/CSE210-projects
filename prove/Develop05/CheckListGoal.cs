using System;
using System.Collections.Generic;

class ChecklistGoal : Goal
{
    private List<string> items;
    private Dictionary<string, bool> itemStatus;
    private int points;
    private int requiredTimes;
    private int bonus;

    public ChecklistGoal()
    {
        items = new List<string>();
        itemStatus = new Dictionary<string, bool>();
    }

    public override void SetGoalDetails()
    {
        base.SetGoalDetails();

        Console.Write("Enter points for completing the goal: ");
        string input = Console.ReadLine();
        if (!int.TryParse(input, out points))
        {
            Console.WriteLine("Invalid points. Goal creation canceled.");
            return;
        }

        Console.Write("How many times does this goal need to be accomplished for a bonus? ");
        input = Console.ReadLine();
        if (!int.TryParse(input, out requiredTimes) || requiredTimes < 1)
        {
            Console.WriteLine("Invalid bonus count. Goal creation canceled.");
            return;
        }

        for (int i = 1; i <= requiredTimes; i++)
        {
            items.Add($"Item {i}");
            itemStatus.Add($"Item {i}", false);
        }

        Console.Write($"What is the bonus for accomplishing it {requiredTimes} times? ");
        input = Console.ReadLine();
        if (!int.TryParse(input, out bonus))
        {
            Console.WriteLine("Invalid bonus. Goal creation canceled.");
            return;
        }
    }

    public override bool IsComplete()
    {
        int completedCount = itemStatus.Values.Count(status => status);
        return completedCount >= requiredTimes;
    }

    public override void RecordEvent()
    {
        Console.WriteLine("Enter the item number to mark as complete: ");
        string input = Console.ReadLine();
        if (!int.TryParse(input, out int itemNumber) || itemNumber < 1 || itemNumber > items.Count)
        {
            Console.WriteLine("Invalid item number. Event recording canceled.");
            return;
        }

        string selectedItem = items[itemNumber - 1];
        if (!itemStatus.ContainsKey(selectedItem))
        {
            Console.WriteLine("Item not found. Event recording canceled.");
            return;
        }

        if (!itemStatus[selectedItem])
        {
            itemStatus[selectedItem] = true;
            Console.WriteLine("Event recorded successfully!");
        }
        else
        {
            Console.WriteLine("Item already marked as complete. Event recording canceled.");
        }
    }

    public override string DisplayGoalDetails()
    {

        
        string status = IsComplete() ? "[X]" : "[ ]";
        string checklistStatus = $"---- Currently Completed: {itemStatus.Values.Count(s => s)}/{requiredTimes}";

        return $"{status} {name} ({description}) - Points: {points} {checklistStatus} - Bonus: {bonus}";
    }

    protected override void LoadGoalFromParts(string[] parts)
    {
        base.LoadGoalFromParts(parts);

        if (parts.Length >= 6)
        {
            if (int.TryParse(parts[3], out int loadedPoints))
            {
                points = loadedPoints;
            }

            if (int.TryParse(parts[4], out int loadedRequiredTimes))
            {
                requiredTimes = loadedRequiredTimes;
            }

            if (int.TryParse(parts[5], out int loadedBonus))
            {
                bonus = loadedBonus;
            }
        }
    }

    public override string SaveGoalToString()
    {
        return $"{base.SaveGoalToString()}|{points}|{requiredTimes}|{bonus}";
    }
}