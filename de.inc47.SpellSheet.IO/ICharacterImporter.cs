using de.inc47.Spells;

namespace de.inc47.SpellSheet.IO
{
    public interface ICharacterImporter
    {
      ICharacterInformation Import(string path);
    }
}
