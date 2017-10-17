using System.Collections.Generic;
using System.Linq.Expressions;
using de.inc47.SpellSheet.Render;

namespace de.inc47.SpellSheet.Template
{
  public interface ITemplate<T>
  {
    IBlock Apply(T data);
  }
}
