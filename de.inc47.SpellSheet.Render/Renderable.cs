namespace de.inc47.SpellSheet.Render
{
  public abstract class Renderable : IRenderable
  {
    protected Renderable(int row, int column, int width, int height, string name = "")
    {
      Row = row;
      Column = column;
      Width = width;
      Height = height;
      Name = name;
    }

    public string Name { get; }
    public int Column { get; }
    public int Row { get; }
    public int Width { get; }
    public int Height { get; }
  }
}