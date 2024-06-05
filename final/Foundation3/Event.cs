using System;

// Base Event class
public abstract class Event
{
    private string _title;
    private string _description;
    private DateTime _dateTime;
    private Address _address;

    public Event(string title, string description, DateTime dateTime, Address address)
    {
        _title = title;
        _description = description;
        _dateTime = dateTime;
        _address = address;
    }

    public virtual string GetStandardDetails()
    {
        return $"Title: {_title}\nDescription: {_description}\nDate: {_dateTime.ToString("yyyy-MM-dd")}\nTime: {_dateTime.ToString("HH:mm")}\nLocation: {_address.GetFullAddress()}";
    }

    public virtual string GetShortDescription()
    {
        return $"{GetEventType()} - {_title} on {_dateTime.ToString("yyyy-MM-dd")}";
    }

    public virtual string GetFullDetails()
    {
        // Implement the base class logic for getting full details
        return "Base class event details";
    }

    protected abstract string GetEventType();
}
