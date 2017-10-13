using de.inc47.Spells.Enumerations;

namespace de.inc47.Spells
{
  public interface ISpell
  {
    string Name { get; }
    int ZfW { get; }
    // ReSharper disable once InconsistentNaming
    int ZD { get; }

    // ReSharper disable once InconsistentNaming
    Zeiteinheit ZDEinheit { get; }

    Eigenschaft Probe1 { get; }
    Eigenschaft Probe2 { get; }
    Eigenschaft Probe3 { get; }
  }
}
