using System;

public enum DifficultyLevel
{
    Easy,
    Medium,
    Hard
}

public class Scripture
{
    private Reference _reference;
    private List<Word> _words;
    private DifficultyLevel _difficultyLevel;

    // Property for the difficulty level
    public DifficultyLevel DifficultyLevel => _difficultyLevel;

    // Constructor to initialize the scripture
    public Scripture(Reference reference, string text, DifficultyLevel difficultyLevel)
    {
        _reference = reference;
        _words = new List<Word>();
        _difficultyLevel = difficultyLevel;
        InitializeWords(text);
    }

    // Method to initialize words from the provided text
    private void InitializeWords(string text)
    {
        string[] wordArray = text.Split(' ');

        foreach (var wordText in wordArray)
        {
            _words.Add(new Word(wordText));
        }
    }

    private Random random = new Random();

    // Method to hide random words based on difficulty level
    public void HideRandomWords()
    {
        int wordsToHide = GetWordsToHideCount();

        for (int i = 0; i < wordsToHide; i++)
        {
            int index = random.Next(_words.Count);
            _words[index].Hide();
        }
    }

    // Method to calculate the number of words to hide based on the difficulty level
    private int GetWordsToHideCount()
    {
        switch (_difficultyLevel)
        {
            case DifficultyLevel.Easy:
                return _words.Count / 4; // Example: hide 25% of words
            case DifficultyLevel.Medium:
                return _words.Count / 2; // Example: hide 50% of words
            case DifficultyLevel.Hard:
                return _words.Count - 1; // Example: hide all words except one
            default:
                throw new ArgumentOutOfRangeException();
        }
    }

    // Method to get the display text of the scripture
    public string GetDisplayText()
    {
        List<string> displayWords = new List<string>();

        foreach (var word in _words)
        {
            displayWords.Add(word.GetDisplayText());
        }

        return $"{_reference.GetDisplayText()}: {string.Join(" ", displayWords)}\n\n";
    }

    // Method to check if all words are completely hidden
    public bool IsCompletelyHidden()
    {
        return _words.All(word => word.IsHidden());
    }

    // Method to count the number of hidden words
    public int CountHiddenWords()
    {
        return _words.Count(word => word.IsHidden());
    }
}