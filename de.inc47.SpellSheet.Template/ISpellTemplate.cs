using de.inc47.Spells;
using de.inc47.SpellSheet.Render;

namespace de.inc47.SpellSheet.Template
{
  public interface ISpellTemplate
  {
    IBlock Apply(ISpell spell, ICharacterInformation character);
  }
}
