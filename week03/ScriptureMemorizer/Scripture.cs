public class Scripture
{
    private Reference _reference;
    private List<Word> _words;

    public Scripture(Reference reference, string text)
    {
        _reference = reference;
        _words = new List<Word>();
        
        string[] wordArray = text.Split(' ');
        foreach (string wordText in wordArray)
        {
            _words.Add(new Word(wordText));
        }
    }

    public void HideRandomWords(int numberToHide)
    {
        Random random = new Random();
        int wordsHidden = 0;
        
        // Get only words that aren't hidden yet
        var visibleWords = _words.Where(word => !word.IsHidden()).ToList();
        
        while (wordsHidden < numberToHide && visibleWords.Count > 0)
        {
            int index = random.Next(visibleWords.Count);
            visibleWords[index].Hide();
            wordsHidden++;
            visibleWords.RemoveAt(index); // Remove from available words
        }
    }

    public string GetDisplayText()
    {
        string displayText = _reference.GetDisplayText() + " ";
        foreach (Word word in _words)
        {
            displayText += word.GetDisplayText() + " ";
        }
        return displayText.Trim();
    }

    public bool IsCompletelyHidden()
    {
        foreach (Word word in _words)
        {
            if (!word.IsHidden())
                return false;
        }
        return true;
    }
}