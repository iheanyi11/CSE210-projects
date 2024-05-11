using System;

class Program
{
    static void Main(string[] args)
    {
        // Creating a reference
        Reference reference = new Reference("Proverbs", 3, 5, 6);

        // Providing the scripture text
        string text = "Trust in the LORD with all your heart and lean not on your own understanding; in all your ways submit to him, and he will make your paths straight.";

        // Choosing the difficulty level
        DifficultyLevel selectedDifficulty = ChooseDifficultyLevel();

        // Creating the scripture with the selected difficulty level
        Scripture scripture = new Scripture(reference, text, selectedDifficulty);

        Console.WriteLine("Press Enter to continue or type 'quit' to exit:");

        while (true)
        {
            Console.Clear();
            Console.WriteLine(scripture.GetDisplayText());

            Console.WriteLine("Press Enter to continue or type 'quit' to exit:");
            string input = Console.ReadLine();

            // Exiting the program if the user types 'quit' or all words are hidden
            if (input.ToLower() == "quit" || scripture.IsCompletelyHidden())
            {
                break;
            }

            // Calculating the number of words to hide based on difficulty level
            int wordsToHide = CalculateWordsToHide(scripture);

            // Hiding random words in the scripture
            scripture.HideRandomWords();
        }
    }

    static DifficultyLevel ChooseDifficultyLevel()
    {
        Console.WriteLine("Choose a difficulty level: ");
        Console.WriteLine("1. Easy");
        Console.WriteLine("2. Medium");
        Console.WriteLine("3. Hard");

        while (true)
        {
            string input = Console.ReadLine();

            // Validating user input for difficulty level
            if (int.TryParse(input, out int choice) && Enum.IsDefined(typeof(DifficultyLevel), choice - 1))
            {
                return (DifficultyLevel)(choice - 1);
            }
            else
            {
                Console.WriteLine("Invalid choice. Please enter a valid number.");
            }
        }
    }

    static int CalculateWordsToHide(Scripture scripture)
    {
        // Hiding a number of words based on the difficulty level
        switch (scripture.DifficultyLevel)
        {
            case DifficultyLevel.Easy:
                return scripture.CountHiddenWords() / 2; // Hiding half of the words
            case DifficultyLevel.Medium:
                return scripture.CountHiddenWords(); // Hiding all words
            case DifficultyLevel.Hard:
                return scripture.CountHiddenWords() * 2; // Hiding double the number of words
            default:
                return 0;
        }
    }
}