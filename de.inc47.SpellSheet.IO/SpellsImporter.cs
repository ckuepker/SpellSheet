using System.Collections.Generic;
using System.IO;
using de.inc47.Spells;
using Newtonsoft.Json;

namespace de.inc47.SpellSheet.IO
{
  public class SpellsImporter : ISpellsImporter
  {
    public IEnumerable<ISpell> Import(string path)
    {
      string json = File.ReadAllText(path);
      IEnumerable<Spell> spells = JsonConvert.DeserializeObject<IEnumerable<Spell>>(json);
      return spells;
    }
  }
}