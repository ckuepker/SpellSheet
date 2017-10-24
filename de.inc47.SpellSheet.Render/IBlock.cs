using System;
using System.Collections.Generic;

namespace de.inc47.SpellSheet.Render
{
  public interface IBlock : IRenderable
  {
    List<IRenderable> Children { get; }
    bool ContainsChild(Func<IRenderable,bool> condition);
    IRenderable FindChild(Func<IRenderable, bool> condition);
    T FindChild<T>(Func<T,bool> condition) where T : IRenderable;
  }
}
