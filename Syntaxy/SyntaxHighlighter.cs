using System.Text;
using System.Text.Json;
using System.Text.RegularExpressions;
using Syntaxy.Models;
using Syntaxy.Models.Enums;

namespace Syntaxy;

public class SyntaxHighlighter
{
    public List<ILanguage> Languages { get; set; } = new List<ILanguage>();

    public Task<List<Token>>  ParseAsync(string code, string language)
    {
        return Task.FromResult(Parse(code, language));
    }
    
    public List<Token> Parse(string code, string language)
    {
        List<Token> tokens = new List<Token>();

        ILanguage? lang = Languages.FirstOrDefault(l => l.GetConfig(new LanguageOptions()).Names.Contains(language));
        
        if (lang == null) {
            tokens.Add(new Token(code, TokenType.PlainText, 0));
            
            return tokens;
        }
        
        int currentIndex = 0;

        // todo: fix this
        
        while (currentIndex < code.Length)
        {
            bool matched = false;
            
            foreach (var property in lang.GetProperties())
            {
                var regex = new Regex(property.Regex, RegexOptions.Multiline);
                var match = regex.Match(code, currentIndex);

                if (match.Success && match.Index == currentIndex)
                {
                    // Add the matched token
                    tokens.Add(new Token(match.Value, property.Type, match.Index));
                    currentIndex += match.Length;
                    matched = true;
                    break;
                }
            }

            if (!matched)
            {
                Console.WriteLine("not matched");
                
                // Capture unmatched text segment
                int nextIndex = currentIndex + 1;

                if (char.IsWhiteSpace(code[currentIndex]))
                {
                    if (tokens.Count > 0 && tokens[^1].Type == TokenType.Whitespace)
                        tokens[^1].Text += code[currentIndex];
                    else
                        tokens.Add(new Token(code[currentIndex].ToString(), TokenType.Whitespace, currentIndex));
                    
                    currentIndex = nextIndex;
                    
                    continue;
                }
                
                if (tokens.Count > 0 && tokens[^1].Type == TokenType.PlainText)
                    tokens[^1].Text += code[currentIndex];
                else
                    tokens.Add(new Token(code.Substring(currentIndex, 1), TokenType.PlainText, currentIndex));
            
                
                currentIndex = nextIndex;
            }
        }

        return tokens;


        /*StringBuilder text = new StringBuilder(code);

        foreach (var property in lang.GetProperties())
        {
            var regex = new Regex(property.Regex);

            var matches = regex.Matches(text.ToString()).Cast<Match>().OrderByDescending(m => m.Index).ToList();

            foreach (Match match in matches)
            {
                string replacement = $"<span style=\"color: {property};\">{match.Value}</span>";
                text.Remove(match.Index, match.Length);
                text.Insert(match.Index, replacement);

                Console.WriteLine(match.Value);
            }
        }


        return text.ToString();*/
    }
}