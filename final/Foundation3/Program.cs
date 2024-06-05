using System;

class Program
{
    static void Main(string[] args)
    {
        // Create events
        Lecture lecture = new Lecture("Lecture on Inheritance", "Learn about inheritance in object-oriented programming", new DateTime(2024, 6, 15, 18, 0, 0), new Address("123 Main St", "Los Angeles", "CA", "12345"), "John Taylor", 100);
        Reception reception = new Reception("Summer Solstice Reception", "Join us for a celebratory reception", new DateTime(2024, 6, 21, 19, 30, 0), new Address("456 Oak Rd", "Buffalo", "NY", "54321"), "rsvp@company.com");
        OutdoorGathering outdoorGathering = new OutdoorGathering("Picnic in the Park", "Enjoy a relaxing day in the park", new DateTime(2024, 7, 4, 12, 0, 0), new Address("789 Elm St", "Dallas", "TX", "67890"), "Sunny with a high of 80F");

        // Output event details
        Console.WriteLine("Standard Details:");
        Console.WriteLine(lecture.GetStandardDetails());
        Console.WriteLine("\n" + reception.GetStandardDetails());
        Console.WriteLine("\n" + outdoorGathering.GetStandardDetails());

        Console.WriteLine("\nFull Details:");
        Console.WriteLine(lecture.GetFullDetails());
        Console.WriteLine("\n" + reception.GetFullDetails());
        Console.WriteLine("\n" + outdoorGathering.GetFullDetails());

        Console.WriteLine("\nShort Description:");
        Console.WriteLine(lecture.GetShortDescription());
        Console.WriteLine(reception.GetShortDescription());
        Console.WriteLine(outdoorGathering.GetShortDescription());
    }
}