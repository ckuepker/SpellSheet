using de.inc47.SpellSheet.Render.Enum;

namespace de.inc47.SpellSheet.Render.Builder
{
  public interface IRenderableBuilder
  {
    IRenderableBuilder Below(IRenderable target);
    IText Text(string content, TextStyle style);
  }
}
