using de.inc47.SpellSheet.Render.Enum;

namespace de.inc47.SpellSheet.Render
{
  public interface IText : IRenderable
  {
    string Text { get; }
    TextStyle Style { get; }
  }
}