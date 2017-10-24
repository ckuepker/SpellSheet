using System;
using System.Collections.Generic;
using de.inc47.Spells.Enumerations;

namespace de.inc47.Spells
{
  public class CharacterInformation : ICharacterInformation
  {
    public CharacterInformation(string name, int mut, int klugheit, int intuition, int charisma, int fingerfertigkeit, int körperkraft, int konstitution, int gewandheit, int magieresistenz, int selbstbeherrschung, int astralenergie)
    {
      Name = name;
      Mut = mut;
      Klugheit = klugheit;
      Intuition = intuition;
      Charisma = charisma;
      Fingerfertigkeit = fingerfertigkeit;
      Körperkraft = körperkraft;
      Konstitution = konstitution;
      Gewandheit = gewandheit;
      Magieresistenz = magieresistenz;
      Selbstbeherrschung = selbstbeherrschung;
      Astralenergie = astralenergie;
    }

    private static readonly Dictionary<Eigenschaft, Func<ICharacterInformation, int>> EigenschaftToPropertyMap = new Dictionary<Eigenschaft, Func<ICharacterInformation, int>> {
      {Eigenschaft.CH, i => i.Charisma},
      {Eigenschaft.FF, i => i.Fingerfertigkeit},
      {Eigenschaft.GE, i => i.Gewandheit},
      {Eigenschaft.IN, i => i.Intuition},
      {Eigenschaft.KK, i => i.Körperkraft},
      {Eigenschaft.KL, i => i.Klugheit},
      {Eigenschaft.KO, i => i.Konstitution},
      {Eigenschaft.MU, i => i.Mut},
    };


    public string Name { get; }
    public int Mut { get; }
    public int Klugheit { get; }
    public int Intuition { get; }
    public int Charisma { get; }
    public int Fingerfertigkeit { get; }
    public int Körperkraft { get; }
    public int Konstitution { get; }
    public int Gewandheit { get; }
    public int Magieresistenz { get; }
    public int Selbstbeherrschung { get; }
    public int Astralenergie { get; }
    public int GetEigenschaft(Eigenschaft e)
    {
      return EigenschaftToPropertyMap[e](this);
    }
  }
}