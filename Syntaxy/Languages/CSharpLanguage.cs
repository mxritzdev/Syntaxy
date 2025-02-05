using Syntaxy.Interfaces;
using Syntaxy.Models;
using Syntaxy.Models.Enums;

namespace Syntaxy.Languages;

public class CSharpLanguage : ILanguage
{
    public LanguageOptions GetConfig(LanguageOptions options)
    {
        options.Names = new List<string>()
        {
            "csharp",
            "cs"
        };
        
        return options;
    }
    

    public List<IProperty> GetProperties()
    {
        
        var properties = new List<IProperty>();

        // Strings
        properties.Add(new SimpleProperty()
        {
            Regex = "\"(.*?)\"",
            Type = TokenType.String
        });
        
        // Character literals
        properties.Add(new SimpleProperty()
        {
            Regex = "'(.*?)'",
            Type = TokenType.String
        });
        
        properties.Add(new SimpleProperty()
        {
            Regex = "\\b(public|private|protected|internal|static|readonly|const|sealed|virtual|override|abstract)\\b",
            Type = TokenType.Keyword
        });
        
        // Data Types
        properties.Add(new SimpleProperty()
        {
            Regex = "\\b(int|float|double|bool|string|void|decimal|byte|sbyte|short|ushort|long|ulong|char|object)\\b",
            Type = TokenType.Keyword
        });
        
        // Control Flow
        properties.Add(new SimpleProperty()
        {
            Regex = "\\b(if|else|for|foreach|while|do|switch|case|default|break|continue|goto|return)\\b",
            Type = TokenType.Keyword
        });

        // Access Modifiers
        properties.Add(new SimpleProperty()
        {
            Regex = "\\b(class|public|private|protected|internal|static|readonly|const|sealed|virtual|override|abstract)\\b",
            Type = TokenType.Identifier
        });

        // Exception Handling
        properties.Add(new SimpleProperty()
        {
            Regex = "\\b(try|catch|finally|throw)\\b",
            Type = TokenType.Keyword
        });

        // Contextual Keywords
        properties.Add(new SimpleProperty()
        {
            Regex = "\\b(async|await|yield|nameof|var|dynamic|partial)\\b",
            Type = TokenType.Keyword
        });

        // Null and Boolean Literals
        properties.Add(new SimpleProperty()
        {
            Regex = "\\b(true|false|null)\\b",
            Type = TokenType.Keyword
        });
        
        properties.Add(new SimpleProperty()
        {
            Regex = "\\b-?\\b\\d+(\\.\\d+)?(f|F|d|d|u|U|m|M|l|L|ul|UL|lu|LU)?\\b",
            Type = TokenType.Number
        });
        
        return properties;
    }
}