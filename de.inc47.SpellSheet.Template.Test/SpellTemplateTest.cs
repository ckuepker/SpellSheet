using System;
using System.Linq;
using de.inc47.Spells;
using de.inc47.Spells.Enumerations;
using de.inc47.SpellSheet.Render;
using Moq;
using NUnit.Framework;

namespace de.inc47.SpellSheet.Template.Test
{
  public class SpellTemplateTest
  {
    [Test]
    public void TestApplyZfW()
    {
      var spellMock = new Mock<ISpell>();
      var characterMock = new Mock<ICharacterInformation>();
      spellMock.Setup(m => m.ZfW).Returns(15).Verifiable();

      ITemplate<Tuple<ISpell,ICharacterInformation>> sut = new SpellTemplate();
      IBlock block = sut.Apply(new Tuple<ISpell, ICharacterInformation>(spellMock.Object, characterMock.Object));

      spellMock.Verify(m => m.ZfW, Times.AtLeastOnce);
      Assert.IsTrue(block.ContainsChild(r => r.Id == "ZfW"));
    }

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
        characterMock.Verify(c => c.GetEigenschaft(e), Times.AtLeastOnce);
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

    [Test]
    public void TestApplyProbe()
    {
      var spellMock = new Mock<ISpell>();
      spellMock.Setup(s => s.Probe1).Returns(Eigenschaft.CH).Verifiable();
      spellMock.Setup(s => s.Probe2).Returns(Eigenschaft.KL).Verifiable();
      spellMock.Setup(s => s.Probe3).Returns(Eigenschaft.FF).Verifiable();
      var characterMock = new Mock<ICharacterInformation>();
      characterMock.Setup(c => c.GetEigenschaft(Eigenschaft.CH)).Returns(14).Verifiable();
      characterMock.Setup(c => c.GetEigenschaft(Eigenschaft.KL)).Returns(15).Verifiable();
      characterMock.Setup(c => c.GetEigenschaft(Eigenschaft.FF)).Returns(12).Verifiable();

      var sut = new SpellTemplate();
      var iblock = sut.Apply(new Tuple<ISpell, ICharacterInformation>(spellMock.Object, characterMock.Object));

      spellMock.Verify(s => s.Probe1,Times.AtLeastOnce);
      spellMock.Verify(s => s.Probe2, Times.AtLeastOnce);
      spellMock.Verify(s => s.Probe3, Times.AtLeastOnce);

      characterMock.Verify(c => c.GetEigenschaft(Eigenschaft.CH), Times.AtLeastOnce);
      characterMock.Verify(c => c.GetEigenschaft(Eigenschaft.KL), Times.AtLeastOnce);
      characterMock.Verify(c => c.GetEigenschaft(Eigenschaft.FF), Times.AtLeastOnce);
    }

    [Test]
    public void TestApplyAllBlocksNamed()
    {
      var spellMock = new Mock<ISpell>();
      var characterMock = new Mock<ICharacterInformation>();

      ITemplate<Tuple<ISpell,ICharacterInformation>> sut = new SpellTemplate();
      var iblock = sut.Apply(new Tuple<ISpell, ICharacterInformation>(spellMock.Object, characterMock.Object));

      bool AssertBlockIdsRecursively(IBlock block)
      {
        return !string.IsNullOrEmpty(block.Id) && block.Children.OfType<IBlock>().All(AssertBlockIdsRecursively);
      }

      Assert.IsTrue(AssertBlockIdsRecursively(iblock));
    }
  }
}
