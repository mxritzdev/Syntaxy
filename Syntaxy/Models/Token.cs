using Syntaxy.Models.Enums;

namespace Syntaxy.Models;

public class Token
{
    public string Text { get; set; }

    public TokenType Type { get; set; }
    
    public int Position { get; set; }
    
    public Token(string text, TokenType type, int position)
    {
        Text = text;
        Type = type;
    }
}