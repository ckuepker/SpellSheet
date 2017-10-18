using System;
using de.inc47.Spells;
using de.inc47.Spells.Enumerations;
using Moq;
using NUnit.Framework;

namespace de.inc47.SpellSheet.Template.Test
{
  public class SpellTemplateTest
  {
    [Test]
    public void TestApplyGetEigenschaften()
    {
      var spellMock = new Mock<ISpell>();
      var characterMock = new Mock<ICharacterInformation>();
      characterMock.Setup(c => c.GetEigenschaft(It.IsAny<Eigenschaft>())).Returns(0).Verifiable();

      var sut = new SpellTemplate();
      var iblock = sut.Apply(new Tuple<ISpell, ICharacterInformation>(spellMock.Object, characterMock.Object));

      foreach (Eigenschaft e in Enum.GetValues(typeof(Eigenschaft)))
      {
        characterMock.Verify(c => c.GetEigenschaft(e), Times.Once);
      }
    }

    [Test]
    public void TestApplyGetSpellName()
    {
      var spellMock = new Mock<ISpell>();
      var characterMock = new Mock<ICharacterInformation>();
      spellMock.Setup(s => s.Name).Returns("SpellName").Verifiable();

      var sut = new SpellTemplate();
      var iblock = sut.Apply(new Tuple<ISpell, ICharacterInformation>(spellMock.Object, characterMock.Object));
      
      spellMock.Verify(s => s.Name, Times.Once);
    }
  }
}
