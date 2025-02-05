using Syntaxy;
using Syntaxy.Languages;

namespace Syntaxy.Test;

public static class Program {

    public static async Task Main(string[] args) 
    {

        var syntx = new SyntaxHighlighter()

        syntx.Languages.Add(new CSharpLanguage());

        var tokens = syntx.Parse()

    }

}