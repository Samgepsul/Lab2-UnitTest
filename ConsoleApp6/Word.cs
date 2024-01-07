namespace ConsoleApp6;

public class Word
{
    public string Root { get; set; }
    
    public string Prefix { get; set; }
    
    public string Suffix { get; set; }

    public override string ToString()
    {
        return Prefix  + Root +  Suffix;
    }
}