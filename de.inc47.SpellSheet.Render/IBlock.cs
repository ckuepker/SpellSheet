using System.Collections.Generic;

namespace de.inc47.SpellSheet.Render
{
  public interface IBlock : IRenderable
  {
    List<IRenderable> Children { get; }
  }
}
