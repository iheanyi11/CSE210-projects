using System;

class Program
{
    static void Main(string[] args)
    {
       Assignment assignment1 = new Assignment("Samuel Bennett", "Multiplication");
       string summary = assignment1.GetSummary();
       Console.WriteLine(summary);

       MathAssignment assignment2 = new MathAssignment("Samuel Bennett", "Multiplication", "7.3", "8-19");
       string summary2 = assignment2.GetSummary();
       string assignmentNd2 = assignment2.GetHomeworkList();
       Console.WriteLine(summary2);
       Console.WriteLine(assignmentNd2);

        WritingAssignment assignment3 = new WritingAssignment("Mary Waters", "European History", "The Causes of World War II");
        Console.WriteLine(assignment3.GetSummary());
        Console.WriteLine(assignment3.GetWritingInformation());
    }
}