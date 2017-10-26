using de.inc47.SpellSheet.Render.Enum;

namespace de.inc47.SpellSheet.Render.Builder
{
  public interface IRenderableBuilder
  {
    IRenderableBuilder Below(IRenderable target);
    IRenderableBuilder RightOf(IRenderable target);
    IRenderableBuilder Above(IRenderable target);
    IRenderableBuilder LeftOf(IRenderable target);
    IText Text(string content = "", TextStyle style = TextStyle.Default);
  }
}
