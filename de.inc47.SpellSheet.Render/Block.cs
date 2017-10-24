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

    public IRenderable FindChild(Func<IRenderable, bool> condition)
    {
      return FindChild<IRenderable>(condition);
    }

    public T FindChild<T>(Func<T, bool> condition) where T : IRenderable
    {
      foreach (var c in Children.OfType<T>())
      {
        if (condition(c))
        {
          return c;
        }
      }
      foreach (IBlock b in Children.OfType<IBlock>())
      {
        return b.FindChild<T>(condition);
      }
      return default(T);
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