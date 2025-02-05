namespace Syntaxy.Models;

public class AdvancedProperty : IProperty 
{
    public required Regex Regex { get; set; }

    public required Func<Match, Task<Token[]>> ProcessMatch { get; set; }

    public RegexOptions GetRegexOptions() => RegexOptions.Multiline;
}