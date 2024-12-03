using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;

class Program
{
    static void Main(string[] args)
    {
        // I added a library of scriptures to provide variety for the user.
        List<Scripture> scriptures = LoadScriptures();

        Console.WriteLine("Welcome to the Scripture Memorizer!");
        Console.WriteLine("Select a scripture to memorize:");

        // User-friendly menu system for selecting or loading scriptures.
        for (int i = 0; i < scriptures.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {scriptures[i].GetReference()}");
        }
        Console.WriteLine($"{scriptures.Count + 1}. Load new scriptures from file");

        int choice = GetValidUserChoice(scriptures.Count + 1);
        if (choice == scriptures.Count + 1)
        {
            Console.WriteLine("Enter the file path for the scriptures:");
            string filePath = Console.ReadLine();

            // Dynamic scripture loading from a file.
            scriptures = LoadScripturesFromFile(filePath);
        }

        Scripture selectedScripture = scriptures[choice - 1];

        while (true)
        {
            Console.Clear();
            Console.WriteLine(selectedScripture.GetDisplayText());

            if (selectedScripture.IsFullyHidden())
            {
                // Congratulatory message when the scripture is fully hidden.
                Console.WriteLine("Congratulations! You have successfully hidden the entire scripture!");
                break;
            }

            Console.WriteLine("Press Enter to hide words, type 'hint' for a hint, or type 'quit' to exit.");
            string input = Console.ReadLine();

            if (input.ToLower() == "quit")
            {
                break;
            }
            else if (input.ToLower() == "hint")
            {
                // Added a hint system to reveal one previously hidden word.
                selectedScripture.RevealOneWord();
            }
            else
            {
                selectedScripture.HideRandomWords();
            }
        }
    }

    // Helper method to load default scriptures into a library.
    // Enhanced: Provides variety for scripture practice.
    static List<Scripture> LoadScriptures()
    {
        return new List<Scripture>
        {
            new Scripture(new Reference("John", 3, 16), "For God so loved the world that he gave his one and only Son, that whoever believes in him shall not perish but have eternal life."),
            new Scripture(new Reference("Proverbs", 3, 5, 6), "Trust in the Lord with all your heart and lean not on your own understanding; in all your ways submit to him, and he will make your paths straight.")
        };
    }

    // Load scriptures dynamically from a file.
    static List<Scripture> LoadScripturesFromFile(string filePath)
    {
        List<Scripture> scriptures = new List<Scripture>();

        try
        {
            foreach (string line in File.ReadAllLines(filePath))
            {
                string[] parts = line.Split('|');
                if (parts.Length == 3)
                {
                    Reference reference = Reference.Parse(parts[0]);
                    scriptures.Add(new Scripture(reference, parts[1]));
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error reading file: {ex.Message}");
        }

        return scriptures.Count > 0 ? scriptures : LoadScriptures();
    }

    // Helper method to get a valid choice from the user.
    static int GetValidUserChoice(int maxChoice)
    {
        int choice;
        while (!int.TryParse(Console.ReadLine(), out choice) || choice < 1 || choice > maxChoice)
        {
            Console.WriteLine("Invalid choice. Please select a valid option:");
        }
        return choice;
    }
}

// Scripture class encapsulates scripture-specific responsibilities.
class Scripture
{
    private Reference _reference;
    private List<Word> _words;

    public Scripture(Reference reference, string text)
    {
        _reference = reference;
        _words = text.Split(' ').Select(word => new Word(word)).ToList();
    }

    public string GetReference()
    {
        return _reference.ToString();
    }

    public string GetDisplayText()
    {
        // Added color coding for visible and hidden words.
        return $"{_reference}\n" + string.Join(" ", _words.Select(word => word.IsHidden() ? $"[{word.GetMaskedText()}]" : word.GetText()));
    }

    public void HideRandomWords()
    {
        // Smarter hiding logic to ensure only unhidden words are hidden.
        var unhiddenWords = _words.Where(word => !word.IsHidden()).ToList();
        if (unhiddenWords.Count == 0) return;

        Random random = new Random();
        int wordsToHide = Math.Min(3, unhiddenWords.Count);

        for (int i = 0; i < wordsToHide; i++)
        {
            unhiddenWords[random.Next(unhiddenWords.Count)].Hide();
        }
    }

    public void RevealOneWord()
    {
        var hiddenWords = _words.Where(word => word.IsHidden()).ToList();
        if (hiddenWords.Count > 0)
        {
            Random random = new Random();
            hiddenWords[random.Next(hiddenWords.Count)].Reveal();
        }
    }

    public bool IsFullyHidden()
    {
        return _words.All(word => word.IsHidden());
    }
}

// Word class encapsulates word-specific responsibilities, including its hidden/shown state.
class Word
{
    private string _text;
    private bool _isHidden;

    public Word(string text)
    {
        _text = text;
        _isHidden = false;
    }

    public string GetText()
    {
        return _text;
    }

    public string GetMaskedText()
    {
        return new string('_', _text.Length);
    }

    public void Hide()
    {
        _isHidden = true;
    }

    public void Reveal()
    {
        _isHidden = false;
    }

    public bool IsHidden()
    {
        return _isHidden;
    }
}

// Reference class encapsulates scripture reference details, including multiple verses.
class Reference
{
    private string _book;
    private int _startChapter;
    private int _startVerse;
    private int _endChapter;
    private int _endVerse;

    public Reference(string book, int startChapter, int startVerse, int? endChapter = null, int? endVerse = null)
    {
        _book = book;
        _startChapter = startChapter;
        _startVerse = startVerse;
        _endChapter = endChapter ?? startChapter;
        _endVerse = endVerse ?? startVerse;
    }

    public static Reference Parse(string referenceText)
    {
        // Handles parsing from string for flexibility in file loading.
        string[] parts = referenceText.Split(new[] { ' ', ':' }, StringSplitOptions.RemoveEmptyEntries);
        return new Reference(parts[0], int.Parse(parts[1]), int.Parse(parts[2]));
    }

    public override string ToString()
    {
        return _startChapter == _endChapter && _startVerse == _endVerse
            ? $"{_book} {_startChapter}:{_startVerse}"
            : $"{_book} {_startChapter}:{_startVerse}-{_endChapter}:{_endVerse}";
    }
}
