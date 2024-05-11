using System;

public class Word
{
    private string _text;
    private bool _isHidden;
    private int _originalLength;

    // Constructor to initialize a word
    public Word(string text)
    {
        _text = text;
        _isHidden = false;
        _originalLength = text.Length;
    }

    // Method to hide the word
    public void Hide()
    {
        _isHidden = true;
    }

    // Method to show the word
    public void Show()
    {
        _isHidden = false;
    }

    // Method to check if the word is hidden
    public bool IsHidden()
    {
        return _isHidden;
    }

    // Method to get the display text of the word
    public string GetDisplayText()
    {
        if (_isHidden)
        {
            return new string('_', _originalLength);
        }

        return _text;
    }
}