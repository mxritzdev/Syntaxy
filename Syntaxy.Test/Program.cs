using Syntaxy.Languages;

namespace Syntaxy.Test;

class Program
{
    static void Main(string[] args)
    {
        
        string testCode = "using System;\n\nnamespace Example\n{\n    class Program\n    {\n        static void Main(string[] args)\n        {\n            Console.WriteLine(\"Hello, World!\")       }\n    }\n}\n";
        
        var syntaxHighlighter = new SyntaxHighlighter();
        
        syntaxHighlighter.Languages.Add(new CSharpLanguage());
        
        var tokens = syntaxHighlighter.Parse(testCode, "csharp");

        foreach (var token in tokens)
        {
            Console.WriteLine($"Text: {token.Text}, Type: {token.Type}, Position: {token.Position}");
        }
    }
}