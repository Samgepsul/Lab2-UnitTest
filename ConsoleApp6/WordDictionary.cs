namespace ConsoleApp6;

public class WordDictionary
{
    private readonly List<Word> words = new List<Word>();

    public void Add(Word word)
    {
        if (word != null)
        {
            words.Add(word);
        }
    }

    public IEnumerable<Word> FindByRoot(string root)
    {
        return words.Where(w => root.Contains(w.Root, StringComparison.OrdinalIgnoreCase)).ToList();
    }

    public bool Contains(string root)
    {
        return words.Count(w => w.ToString().Equals(root, StringComparison.OrdinalIgnoreCase)) != 0;
    }
}