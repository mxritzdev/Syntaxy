namespace Syntaxy.Models;

public class Property
{
    public string RegexBefore { get; set; } = string.Empty;
    
    public required string Regex { get; set; }
    
    public string RegexAfter { get; set; } = string.Empty;
    
    public string Color { get; set; } = string.Empty;

    public bool IsBold { get; set; } = false;

    public bool IsItalic { get; set; } = false;
}