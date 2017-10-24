using de.inc47.Spells.Enumerations;
using NUnit.Framework;

namespace de.inc47.Spells.Test
{
  public class SpellTest
  {
    private class SpellBuilder
    {
      private string _name = "";
      private int _zfw = 0;
      private int _zd = 0;
      private Zeiteinheit _zdEinheit = Zeiteinheit.AR;
      private string _probe1 = "";
      private string _probe2 = "";
      private string _probe3 = "";
      private int _reichweite = 0;
      private DistanzEinheit _reichweiteEinheit = DistanzEinheit.Schritt;

      internal ISpell Build()
      {
        return new Spell(_name, _zfw, _zd, _zdEinheit, _probe1, _probe2, _probe3, _reichweite, _reichweiteEinheit);
      }
    }

    //[Test]
    //public void TestKosten()
    //{
    //  ISpell sut = new SpellBuilder().WithKosten(9).Build();
    //  Assert.AreEqual(9, sut.Kosten);
    //  Assert.AreEqual(Wert.AsP, sut.KostenEinheit);
    //  Assert.Null(sut.KostenBezug);
    //  Assert.AreEqual(9, sut.MinimalKosten);
    //  Assert.AreEqual(9, sut.MaximalKosten);
    //}

    //[Test]
    //public void TestKostenWithBezugSP()
    //{
    //  ISpell sut = new SpellBuilder().WithKosten(1).WithKostenBezug(Wert.SP).Build();
    //  Assert.AreEqual(1, sut.Kosten);
    //  Assert.AreEqual(Wert.AsP, sut.KostenEinheit);
    //  Assert.AreEqual(Wert.SP, sut.KostenBezug);
    //  Assert.AreEqual(4, sut.MinimalKosten);
    //  Assert.AreEqual(66, sut.MaximalKosten);
    //}
  }
}
