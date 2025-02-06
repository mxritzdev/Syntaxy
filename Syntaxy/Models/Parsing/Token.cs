using Syntaxy.Models.Enums;
using Syntaxy.Models.Parsing.Style;

namespace Syntaxy.Models.Parsing;

public class Token
{
    public string Text;

    public readonly TokenType Type;

    public readonly int Position;
    
    public Token(string text, TokenType type, int position)
    {
        Text = text;
        Type = type;
        Position = position;
    }
}