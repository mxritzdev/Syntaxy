using System.Drawing;

namespace Syntaxy.Models;

public class ColorPalette
{
    public Color Primary { get; set; } // Keywords
    public Color Glow { get; set; } // Strings
    public Color Tone { get; set; } // Comments
    public Color Harmony { get; set; } // Identifiers
    public Color Accent { get; set; } // Numbers
    public Color Highlight { get; set; } // Operators
    public Color Base { get; set; } // Plain Text
}