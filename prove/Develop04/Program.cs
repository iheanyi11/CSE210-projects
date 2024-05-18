using System;

class Program
{
    static void Main(string[] args)
    {
        while (true)
        {
            Console.WriteLine("Mindfulness Program Menu");
            Console.WriteLine("1. Breathing Activity");
            Console.WriteLine("2. Listing Activity");
            Console.WriteLine("3. Reflecting Activity");
            Console.WriteLine("4. Meditation Activity"); // Added option for Meditation
            Console.WriteLine("5. Exit");

            Console.Write("Select an activity (1-5): ");
            int choice = Convert.ToInt32(Console.ReadLine());

            Activity activity;

            switch (choice)
            {
                case 1:
                    activity = new BreathingActivity();
                    activity.Run();
                    break;

                case 2:
                    activity = new ListingActivity();
                    activity.Run();
                    break;

                case 3:
                    activity = new ReflectingActivity();
                    activity.Run();
                    break;

                case 4:
                    activity = new MeditationActivity(); // Create instance of MeditationActivity
                    activity.Run();
                    break;

                case 5:
                    Environment.Exit(0);
                    break;

                default:
                    Console.WriteLine("Invalid choice. Please select again.");
                    break;
            }
        }
    }
}