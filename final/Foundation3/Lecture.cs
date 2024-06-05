using System;

// Lecture class
public class Lecture : Event
{
    private string _speakerName;
    private int _capacity;

    public Lecture(string title, string description, DateTime dateTime, Address address, string speakerName, int capacity)
        : base(title, description, dateTime, address)
    {
        _speakerName = speakerName;
        _capacity = capacity;
    }

    public override string GetFullDetails()
    {
        return $"{GetStandardDetails()}\nEvent Type: Lecture\nSpeaker: {_speakerName}\nCapacity: {_capacity}";
    }

    protected override string GetEventType()
    {
        return "Lecture";
    }
}