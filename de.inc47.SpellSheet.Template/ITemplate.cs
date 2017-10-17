using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using de.inc47.Spells;
using de.inc47.SpellSheet.Render;

namespace de.inc47.SpellSheet.Template
{
  public interface ITemplate<T>
  {
    IBlock Apply(T data);
  }

  public class SpellTemplate : ITemplate<Tuple<ISpell, ICharacterInformation>>
  {
    public IBlock Apply(Tuple<ISpell, ICharacterInformation> data)
    {
      var spell = data.Item1;
      var info = data.Item2;
      var root = new Block();

      return root;
    }
  }
}
