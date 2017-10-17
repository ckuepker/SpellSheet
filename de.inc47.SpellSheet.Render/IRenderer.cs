using System.CodeDom;

namespace de.inc47.SpellSheet.Render
{
  public interface IRenderer
  {
    void Render(IRenderable element);
    void Render(IBlock block);
    void Render(IText text);
    void Render(INumeric numeric);
  }
}
