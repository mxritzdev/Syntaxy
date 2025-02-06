using System.Text;
using System.Text.Json;
using System.Text.RegularExpressions;
using Syntaxy.Models;
using Syntaxy.Models.Enums;
using Syntaxy.Models.Parsing;

namespace Syntaxy;

public class SyntaxHighlighter
{
    public List<ILanguage> Languages { get; set; } = new List<ILanguage>();

    public Task<CodeDocument>  ParseAsync(string code, string language)
    {
        return Task.FromResult(Parse(code, language));
    }
    
    public CodeDocument Parse(string code, string language)
    {
        var document = new CodeDocument();
        

        ILanguage? lang = Languages.FirstOrDefault(l => l.GetConfig(new LanguageOptions()).Names.Contains(language));
        
        if (lang == null) {
            document.Tokens.Add(new Token(code, TokenType.PlainText, 0));
            
            return document;
        }
        
        int currentIndex = 0;

        // todo: fix this
        
        while (currentIndex < code.Length)
        {
            bool matched = false;
            
            foreach (var property in lang.GetProperties())
            {
                var regex = new Regex(property.Regex, property.GetRegexOptions());
                
                var match = regex.Match(code, currentIndex);
                
                if (match.Success && match.Index == currentIndex)
                {
                    if (property is SimpleProperty simpleProperty) {
    
                        // Add the matched token
                        document.Tokens.Add(new Token(match.Value, simpleProperty.Type, currentIndex));
                        currentIndex += match.Length;
                        matched = true;
                        break;
                    } 
                    if (property is AdvancedProperty advancedProperty) {

                        // use advanced processing
                        var processedTokens = advancedProperty.ProcessMatch(match);

                        document.Tokens.AddRange(processedTokens);
                        currentIndex += match.Length;
                        matched = true;
                        break;
                        
                    }
                }                
            }

            if (!matched)
            {
                // Capture unmatched text segment
                int nextIndex = currentIndex + 1;

                // group whitespace
                if (char.IsWhiteSpace(code[currentIndex]))
                {
                    if (document.Tokens.Count > 0 && document.Tokens[^1].Type == TokenType.Whitespace)
                        document.Tokens[^1].Text += code[currentIndex];
                    else
                        document.Tokens.Add(new Token(code[currentIndex].ToString(), TokenType.Whitespace, currentIndex));
                    
                    currentIndex = nextIndex;
                    
                    continue;
                }
                
                // group plain text
                if (document.Tokens.Count > 0 && document.Tokens[^1].Type == TokenType.PlainText)
                    document.Tokens[^1].Text += code[currentIndex];
                else
                    document.Tokens.Add(new Token(code.Substring(currentIndex, 1), TokenType.PlainText, currentIndex));
            
                
                currentIndex = nextIndex;
            }
        }

        return document;
    }
}