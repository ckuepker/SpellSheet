using System.Collections.Generic;
using de.inc47.Spells;

namespace de.inc47.SpellSheet.IO
{
  public interface ISpellsImporter
  {
    IEnumerable<ISpell> Import(string path);
  }
}
