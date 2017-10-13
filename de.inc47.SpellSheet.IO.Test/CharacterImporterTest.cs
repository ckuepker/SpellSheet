using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using de.inc47.Spells;
using NUnit.Framework;

namespace de.inc47.SpellSheet.IO.Test
{
  public class CharacterImporterTest
  {
    [Test]
    public void TestImport()
    {
      string path = TestContext.CurrentContext.TestDirectory + "/TestFiles/character.json";
      ICharacterImporter sut = new CharacterImporter();
      ICharacterInformation info = sut.Import(path);
      Assert.NotNull(info);
      Assert.AreEqual("Husein", info.Name);
      Assert.AreEqual(14, info.Mut);
      Assert.AreEqual(13, info.Klugheit);
      Assert.AreEqual(12, info.Charisma);
      Assert.AreEqual(11, info.Intuition);
      Assert.AreEqual(10, info.Konstitution);
      Assert.AreEqual(9, info.Körperkraft);
      Assert.AreEqual(8, info.Gewandheit);
      Assert.AreEqual(15, info.Fingerfertigkeit);
      Assert.AreEqual(52, info.Astralenergie);
      Assert.AreEqual(9, info.Magieresistenz);
      Assert.AreEqual(4, info.Selbstbeherrschung);
    }
  }
}
