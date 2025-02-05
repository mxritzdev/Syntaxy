namespace Syntaxy.Models;

public class AdvancedProperty : IProperty 
{
    public required Regex Regex { get; set; }

    public required Func<string, Task<Token[]>> ProcessMatch { get; set; }

    public RegexOptions GetRegexOptions { get; set; } = RegexOptions.Multiline;
}