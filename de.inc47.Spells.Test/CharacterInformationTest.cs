using de.inc47.Spells.Enumerations;
using NUnit.Framework;

namespace de.inc47.Spells.Test
{
  public class CharacterInformationTest
  {
    [Test]
    public void TestGetEigenschaft()
    {
      var sut = new CharacterInformation("", 1, 2, 3, 4, 5, 6, 7, 8, 0, 0, 0);
      Assert.AreEqual(1, sut.GetEigenschaft(Eigenschaft.MU));
      Assert.AreEqual(2, sut.GetEigenschaft(Eigenschaft.KL));
      Assert.AreEqual(3, sut.GetEigenschaft(Eigenschaft.IN));
      Assert.AreEqual(4, sut.GetEigenschaft(Eigenschaft.CH));
      Assert.AreEqual(5, sut.GetEigenschaft(Eigenschaft.FF));
      Assert.AreEqual(6, sut.GetEigenschaft(Eigenschaft.KK));
      Assert.AreEqual(7, sut.GetEigenschaft(Eigenschaft.KO));
      Assert.AreEqual(8, sut.GetEigenschaft(Eigenschaft.GE));
    }
  }
}
