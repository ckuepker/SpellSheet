using de.inc47.SpellSheet.Render.Enum;

namespace de.inc47.SpellSheet.Render
{
  public class Text : Renderable, IText
  {
    public Text(int row, int column, int width, int height, string content, TextStyle style) 
      : base(row, column, width, height)
    {

      Content = content;
      Style = style;
    }

    public string Content { get; }
    public TextStyle Style { get; }
  }
}