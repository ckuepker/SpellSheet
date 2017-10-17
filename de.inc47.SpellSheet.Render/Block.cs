using System.Collections.Generic;
using System.Linq;

namespace de.inc47.SpellSheet.Render
{
  public class Block : IBlock
  {
    private List<IRenderable> _children;

    public Block(List<IRenderable> children = null)
    {
      _children = children ?? new List<IRenderable>();
    }

    public List<IRenderable> Children {
      get { return _children; }
    }
    public int Column {
      get { return Children.Any() ? Children.Select(c => c.Column).Min() : 0; }
    }

    public int Row
    {
      get { return Children.Any() ? Children.Select(c => c.Row).Min() : 0; }
    }

    public int Width {
      get { return Children.Any() ? Children.Select(c => c.Column + c.Width).Max() - Children.Select(c => c.Column).Min() : 0; }
    }
    public int Height {
      get { return Children.Any() ? Children.Select(c => c.Row + c.Height).Max() - Children.Select(c => c.Row).Min() : 0; }
    }
  }
}