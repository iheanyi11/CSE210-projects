using System;
using System.Collections.Generic;
using System.IO;

class GoalManager
{
    private List<Goal> goals;
    private int score;

    public GoalManager()
    {
        goals = new List<Goal>();
        score = 0;
    }

    public void Start()
    {
        int choice;

        do
        {
            Console.WriteLine($"\nYou have {GetScore()} points");

            Console.WriteLine("\nMenu options:");
            Console.WriteLine("1. Create a new Goal");
            Console.WriteLine("2. List Goals");
            Console.WriteLine("3. Save Goals");
            Console.WriteLine("4. Load Goals");
            Console.WriteLine("5. Record Event");
            Console.WriteLine("6. Quit");

            Console.Write("\nEnter your choice: ");
            string input = Console.ReadLine();

            if (!int.TryParse(input, out choice))
            {
                Console.WriteLine("Invalid choice. Please try again.");
                continue;
            }

            switch (choice)
            {
                case 1:
                    CreateGoal();
                    break;
                case 2:
                    ListGoals();
                    break;
                case 3:
                    SaveGoalsToFile("goals.txt");
                    break;
                case 4:
                    LoadGoalsFromFile("goals.txt");
                    break;
                case 5:
                    RecordEvent();
                    break;
                case 6:
                    Console.WriteLine("Goodbye!");
                    break;
                default:
                    Console.WriteLine("Invalid choice. Please try again.");
                    break;
            }
        } while (choice != 6);
    }

    public int GetScore()
    {
        return score;
    }

    public void CreateGoal()
    {
        Console.WriteLine("Enter the type of goal (1 for Simple, 2 for Eternal, 3 for Checklist): ");
        if (int.TryParse(Console.ReadLine(), out int goalType))
        {
            Goal newGoal;

            switch (goalType)
            {
                case 1:
                    newGoal = new SimpleGoal();
                    break;
                case 2:
                    newGoal = new EternalGoal();
                    break;
                case 3:
                    newGoal = new ChecklistGoal();
                    break;
                default:
                    Console.WriteLine("Invalid goal type. Goal not created.");
                    return;
            }

            newGoal.SetGoalDetails();
            goals.Add(newGoal);
            Console.WriteLine("Goal created successfully!");
        }
        else
        {
            Console.WriteLine("Invalid input. Please enter a valid goal type.");
        }
    }

    public void ListGoals()
    {
        if (goals.Count == 0)
        {
            Console.WriteLine("No goals to display.");
        }
        else
        {
            Console.WriteLine("List of Goals:");

            foreach (var goal in goals)
            {
                Console.WriteLine(goal.DisplayGoalDetails());
            }
        }
    }

    public void RecordEvent()
{
    Console.WriteLine("Enter the number of the goal to record an event for:");

    if (int.TryParse(Console.ReadLine(), out int goalNumber) && goalNumber >= 1 && goalNumber <= goals.Count)
    {
        goals[goalNumber - 1].RecordEvent();
        Console.WriteLine("Event recorded successfully!");
    }
    else
    {
        Console.WriteLine("Invalid goal number. Please enter a valid number.");
    }
}


    public void SaveGoalsToFile(string filename)
    {
        try
        {
            using (StreamWriter writer = new StreamWriter(filename))
            {
                writer.WriteLine(score);

                foreach (var goal in goals)
                {
                    writer.WriteLine(goal.SaveGoalToString());
                }
            }

            Console.WriteLine($"Goals saved successfully to {filename}!");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error saving goals: {ex.Message}");
        }
    }

    public void LoadGoalsFromFile(string filename)
    {
        List<string> loadedGoals = new List<string>();

        try
        {
            using (StreamReader reader = new StreamReader(filename))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    loadedGoals.Add(line);
                }
            }

            Console.WriteLine($"Goals loaded successfully from {filename}!");

            // Convert loaded string goals to Goal objects and add them to the goals list
            goals = new List<Goal>();
            foreach (var goalString in loadedGoals)
            {
                Goal goal = Goal.ParseGoalFromString(goalString);
                if (goal != null)
                {
                    goals.Add(goal);
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error loading goals: {ex.Message}");
        }
    }
}