namespace de.inc47.SpellSheet.Render
{
  public interface IRenderable
  {
    string Name { get; }
    int Column { get; }
    int Row { get; }
    int Width { get; }
    int Height { get; }
  }
}