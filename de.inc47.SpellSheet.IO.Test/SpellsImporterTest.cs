using System.Collections.Generic;
using System.Linq;
using de.inc47.Spells;
using de.inc47.Spells.Enumerations;
using NUnit.Framework;

namespace de.inc47.SpellSheet.IO.Test
{
  public class SpellsImporterTest
  {
    [Test]
    public void TestImport()
    {
      string path = TestContext.CurrentContext.TestDirectory + "/TestFiles/spells.json";
      ISpellsImporter sut = new SpellsImporter();
      IEnumerable<ISpell> spells = sut.Import(path);
      var spellList = spells.ToList();
      Assert.AreEqual(2, spellList.Count);
      ISpell c = spellList[0];
      ISpell i = spellList[1];
      Assert.AreEqual("Corpofrigo", c.Name);
      Assert.AreEqual(15, c.ZfW);
      Assert.AreEqual(2, c.ZD);
      Assert.AreEqual(Zeiteinheit.AR, i.ZDEinheit);
      Assert.AreEqual(Eigenschaft.CH, c.Probe1);
      //Assert.AreEqual(Eigenschaft.GE, c.Probe2);
      //Assert.AreEqual(Eigenschaft.KO, c.Probe3);
      Assert.AreEqual("Ignifaxius", i.Name);
      Assert.AreEqual(11, i.ZfW);
      Assert.AreEqual(4, i.ZD);
      Assert.AreEqual(Zeiteinheit.AR, i.ZDEinheit);
      Assert.AreEqual(Eigenschaft.KL, i.Probe1);
      //Assert.AreEqual(Eigenschaft.FF, i.Probe2);
      //Assert.AreEqual(Eigenschaft.KO, i.Probe3);
    }
  }
}
