using System;

public class WritingAssignment : Assignment
{
    public string _title;

    public WritingAssignment(string studentName, string topic, string title) :base(studentName, topic)
    {
        _title = title;
    }

    public string GetWritingInformation()
    {
        string studentName = GetStudentName();
        return ($"{_title} by {studentName}");
    }


}