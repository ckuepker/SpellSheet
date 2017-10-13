using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Spells;

namespace de.inc47.SpellSheet.IO
{
  public class CharacterImporter : ICharacterImporter
  {
    public ICharacterInformation Import(string path)
    {
      string json = File.ReadAllText(path);
      return JsonConvert.DeserializeObject<CharacterInformation>(json);
    }
  }
}
