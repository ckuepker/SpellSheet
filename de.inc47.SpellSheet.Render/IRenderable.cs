namespace de.inc47.SpellSheet.Render
{
  public interface IRenderable
  {
    int Column { get; }
    int Row { get; }
    int Width { get; }
    int Height { get; }
  }

  public abstract class Renderable : IRenderable
  {
    protected Renderable(int row, int column, int width, int height)
    {
      Column = column;
      Row = row;
      Width = width;
      Height = height;
    }

    public int Column { get; }
    public int Row { get; }
    public int Width { get; }
    public int Height { get; }
  }
}