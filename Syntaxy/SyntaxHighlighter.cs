using System.Text;
using System.Text.Json;
using System.Text.RegularExpressions;
using Syntaxy.Models;

namespace Syntaxy;

public class SyntaxHighlighter
{
    public List<ILanguage> Languages { get; set; } = new List<ILanguage>();

    public Task<string> HighlightAsync(string code, string language)
    {
        return Task.FromResult(Highlight(code, language));
    }
    
    public string Highlight(string code, string language)
    {

        ILanguage? lang = Languages.FirstOrDefault(l => l.GetNames().Contains(language));
        
        if (lang == null)
            return code;
        
        StringBuilder text = new StringBuilder(code);

        
        
        foreach (var property in lang.GetProperties())
        {
            var regex = new Regex(property.Regex);
            
            var matches = regex.Matches(text.ToString()).Cast<Match>().OrderByDescending(m => m.Index).ToList();
            
            foreach (Match match in matches)
            {
                string replacement = $"<span style=\"color: {property.Color};\">{match.Value}</span>";
                text.Remove(match.Index, match.Length);
                text.Insert(match.Index, replacement);
                
                text = new StringBuilder(text.ToString());
                
                Console.WriteLine(match.Value);
            }
        }
        

        return text.ToString();
    }
}