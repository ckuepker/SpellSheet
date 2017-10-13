using System.IO;
using de.inc47.Spells;
using Newtonsoft.Json;

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
