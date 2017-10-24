using System;
using de.inc47.Spells.Enumerations;

namespace de.inc47.Spells
{
  public class Spell : ISpell
  {
    public Spell(string name, int zfW, int zd, Zeiteinheit zdEinheit, string probe1, string probe2, string probe3, int reichweite, DistanzEinheit reichweiteEinheit)
    {
      Name = name;
      ZfW = zfW;
      ZD = zd;
      ZDEinheit = zdEinheit;
      Reichweite = reichweite;
      ReichweiteEinheit = reichweiteEinheit;
      Probe1 = GetEigenschaftFromString(probe1);
      Probe2 = GetEigenschaftFromString(probe2);
      Probe3 = GetEigenschaftFromString(probe3);
    }

    private Eigenschaft GetEigenschaftFromString(string eigenschaft)
    {
      if (eigenschaft.Length == 2)
      {
        if (eigenschaft == "KL")
          return Eigenschaft.KL;
        if (eigenschaft == "MU")
          return Eigenschaft.MU;
        if (eigenschaft == "IN")
          return Eigenschaft.IN;
        if (eigenschaft == "CH")
          return Eigenschaft.CH;
        if (eigenschaft == "FF")
          return Eigenschaft.FF;
        if (eigenschaft == "GE")
          return Eigenschaft.GE;
        if (eigenschaft == "KO")
          return Eigenschaft.KO;
        if (eigenschaft == "KK")
          return Eigenschaft.KK;
      }
      throw new ArgumentException();
    }

    public string Name { get; }
    public int ZfW { get; }
    public int ZD { get; }
    public Zeiteinheit ZDEinheit { get; }
    public Eigenschaft Probe1 { get; }
    public Eigenschaft Probe2 { get; }
    public Eigenschaft Probe3 { get; }
    public int Reichweite { get; }
    public DistanzEinheit ReichweiteEinheit { get; }
  }
}