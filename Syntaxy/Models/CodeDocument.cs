using Syntaxy.Models.Parsing;

namespace Syntaxy.Models;

public class CodeDocument
{
    public List<Token> Tokens { get; set; } = new List<Token>();
}