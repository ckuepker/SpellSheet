using System.Collections.Generic;
using System.Linq;
using de.inc47.Spells;
using de.inc47.Spells.Enumerations;
using NUnit.Framework;

namespace de.inc47.SpellSheet.IO.Test
{
  public class SpellsImporterTest
  {
    private IList<ISpell> _spells;

    [SetUp]
    public void SetUp()
    {
      Assert.Null(_spells);
      string path = TestContext.CurrentContext.TestDirectory + "/TestFiles/spells.json";
      ISpellsImporter sut = new SpellsImporter();
      _spells = sut.Import(path).ToList();
      Assert.AreEqual(2, _spells.Count);
    }

    [TearDown]
    public void TearDown()
    {
      _spells = null;
    }

    [Test]
    public void TestImport()
    {
      
      ISpell c = _spells[0];
      ISpell i = _spells[1];
      Assert.AreEqual("Corpofrigo", c.Name);
      Assert.AreEqual(15, c.ZfW);
      Assert.AreEqual(2, c.ZD);
      Assert.AreEqual(Zeiteinheit.AR, i.ZDEinheit);
      Assert.AreEqual(Eigenschaft.CH, c.Probe1);
      Assert.AreEqual(Eigenschaft.GE, c.Probe2);
      Assert.AreEqual(Eigenschaft.KO, c.Probe3);
      Assert.AreEqual("Ignifaxius", i.Name);
      Assert.AreEqual(11, i.ZfW);
      Assert.AreEqual(4, i.ZD);
      Assert.AreEqual(Zeiteinheit.AR, i.ZDEinheit);
      Assert.AreEqual(Eigenschaft.KL, i.Probe1);
      Assert.AreEqual(Eigenschaft.FF, i.Probe2);
      Assert.AreEqual(Eigenschaft.KO, i.Probe3);
    }
  }
}
