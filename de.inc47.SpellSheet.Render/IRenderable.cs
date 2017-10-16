namespace de.inc47.SpellSheet.Render
{
  public interface IRenderable
  {
    int Column { get; }
    int Row { get; }
    int Width { get; }
    int Height { get; }
  }
}