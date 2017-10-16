namespace de.inc47.SpellSheet.Render
{
  public interface IRenderer
  {
    void Render(IRenderable element);
    void RenderBlock(IBlock block);
    void RenderText(IText text);
    void RenderNumeric(INumeric numeric);
  }
}
