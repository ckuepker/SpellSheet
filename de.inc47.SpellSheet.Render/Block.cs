using System;
using System.Collections.Generic;
using System.Linq;

namespace de.inc47.SpellSheet.Render
{
  public class Block : IBlock
  {
    private List<IRenderable> _children;

    public Block(string id = "", List<IRenderable> children = null)
    {
      Id = id;
      _children = children ?? new List<IRenderable>();
    }

    public List<IRenderable> Children {
      get { return _children; }
    }

    public bool ContainsChild(Func<IRenderable,bool> condition)
    {
      var childBlocks = Children.OfType<IBlock>();
      var childComponents = Children.Where(c => !(c is IBlock));
      foreach (var c in childComponents)
      {
        if (condition(c))
        {
          return true;
        }
      }
      foreach (var child in childBlocks)
      {
        if (condition(child))
        {
          return true;
        }
        if (child.ContainsChild(condition))
        {
          return true;
        }
      }
      return false;
    }

    public string Id { get; }

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