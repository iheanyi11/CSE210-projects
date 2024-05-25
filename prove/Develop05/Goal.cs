using System;

class Goal
{
    protected string name;
    protected string description;
    protected bool complete;

    public virtual void SetGoalDetails()
    {
        Console.Write("Enter the name of the goal: ");
        name = Console.ReadLine();

        Console.Write("Enter goal description: ");
        description = Console.ReadLine();

        complete = false;
    }

    public virtual bool IsComplete()
    {
        return complete;
    }

    public virtual int GetPoints()
    {
        return 0;
    }

    public virtual int GetGoalId()
    {
        return 0;
    }

    public virtual void RecordEvent()
    {
        complete = true;
    }

    public virtual string DisplayGoalDetails()
    {
        string status = IsComplete() ? "[X]" : "[ ]";
        return $"{status} {name} ({description})";
    }
    

    public virtual string SaveGoalToString()
    {
        return $"{name}|{description}|{complete}";
    }

    public static Goal ParseGoalFromString(string goalString)
    {
        string[] parts = goalString.Split('|');
        if (parts.Length >= 3)
        {
            Goal goal = new Goal();
            goal.LoadGoalFromParts(parts);
            return goal;
        }
        return null;
    }

    protected virtual void LoadGoalFromParts(string[] parts)
    {
        if (parts.Length >= 3)
        {
            name = parts[0];
            description = parts[1];
            if (bool.TryParse(parts[2], out bool loadedComplete))
            {
                complete = loadedComplete;
            }
        }
    }
}