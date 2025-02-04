using Syntaxy.Models;

namespace Syntaxy.Languages;

public class CSharpLanguage : ILanguage
{
    public string[] GetNames()
    {
        return ["cs", "csharp"];
    }
    

    public List<Property> GetProperties()
    {
        
        var properties = new List<Property>();

        // Strings
        properties.Add(new Property()
        {
            Regex = "\"(.*?)\"",
            Color = "#CE9178",
            IsBold = false,
            IsItalic = true
        });

        // Character literals
        properties.Add(new Property()
        {
            Regex = "'(.*?)'",
            Color = "#CE9178",
            IsBold = false,
            IsItalic = true
        });
        
        properties.Add(new Property()
        {
            Regex = "\\b(public|private|protected|internal|static|readonly|const|sealed|virtual|override|abstract)\\b",
            Color = "#9CDCFE",
            IsBold = false,
            IsItalic = false
        });
        
        // Data Types
        properties.Add(new Property()
        {
            Regex = "\\b(int|float|double|bool|string|void|decimal|byte|sbyte|short|ushort|long|ulong|char|object)\\b",
            Color = "#569CD6",
            IsBold = false,
            IsItalic = false
        });
        
        // Control Flow
        properties.Add(new Property()
        {
            Regex = "\\b(if|else|for|foreach|while|do|switch|case|default|break|continue|goto|return)\\b",
            Color = "#C586C0",
            IsBold = false,
            IsItalic = false
        });

        // Access Modifiers
        properties.Add(new Property()
        {
            Regex = "\\b(public|private|protected|internal|static|readonly|const|sealed|virtual|override|abstract)\\b",
            Color = "#9CDCFE",
            IsBold = false,
            IsItalic = false
        });

        // Exception Handling
        properties.Add(new Property()
        {
            Regex = "\\b(try|catch|finally|throw)\\b",
            Color = "#D16969",
            IsBold = false,
            IsItalic = false
        });

        // Contextual Keywords
        properties.Add(new Property()
        {
            Regex = "\\b(async|await|yield|nameof|var|dynamic|partial)\\b",
            Color = "#D7BA7D",
            IsBold = false,
            IsItalic = false
        });

        // Null and Boolean Literals
        properties.Add(new Property()
        {
            Regex = "\\b(true|false|null)\\b",
            Color = "#569CD6",
            IsBold = false,
            IsItalic = false
        });
        
        
        
        return properties;
    }
}