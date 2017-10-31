using System;
using System.Collections.Generic;
using de.inc47.Spells;
using de.inc47.SpellSheet.Preview.ViewModel.Test.Extension;
using de.inc47.SpellSheet.Render;
using de.inc47.SpellSheet.Render.Enum;
using de.inc47.SpellSheet.Template;
using Moq;
using NUnit.Framework;

namespace de.inc47.SpellSheet.Preview.ViewModel.Test
{
  public class MainWindowViewModelTest
  {
    [Test]
    public void TestGetAvailableFonts()
    {
      IMainWindowViewModel sut = new MainWindowViewModel();
      var fonts = sut.AvailableFonts;
      Assert.AreEqual(2, fonts.Count);
      Assert.AreEqual("Morpheus",fonts[0]);
      Assert.AreEqual("Unzialish",fonts[1]);
    }

    [Test]
    public void TestGetSelectedFont()
    {
      IMainWindowViewModel sut = new MainWindowViewModel();
      
      Assert.AreEqual("Morpheus", sut.SelectedFont, "Morpheus is default font family");
      Assert.IsTrue(sut.AvailableFonts.Contains(sut.SelectedFont));
    }

    [Test]
    public void TestSetSelectedFont()
    {
      IMainWindowViewModel sut = new MainWindowViewModel();

      sut.ShouldNotifyOn(s => s.SelectedFont).When(s => sut.SelectedFont = "Unzialish");
      Assert.AreEqual("Unzialish", sut.SelectedFont);
    }

    [Test]
    public void TestSetSelectedFontToInvalid()
    {
      IMainWindowViewModel sut = new MainWindowViewModel();
      string expectedFont = sut.SelectedFont;
      sut.ShouldNotNotifyOn(s => s.SelectedFont).When(s => sut.SelectedFont = "Invented font");
      Assert.AreEqual(expectedFont, sut.SelectedFont);
    }

    [Test]
    public void TestShowGrid()
    {
      IMainWindowViewModel sut = new MainWindowViewModel();
      Assert.IsTrue(sut.ShowGrid, "ShowGrid by default");

      sut.ShouldNotifyOn(s => s.ShowGrid).When(s => sut.ShowGrid = false);
    }

    [Test]
    public void TestRenderable()
    {
      IMainWindowViewModel sut = new MainWindowViewModel();
      Assert.Null(sut.Renderable);
      sut.ShouldNotifyOn(s => s.Renderable).When(s => s.Renderable = new Text(0,0,0,0,"",TextStyle.Default));
    }

    [Test]
    public void TestSelectedSpell()
    {
      IMainWindowViewModel sut = new MainWindowViewModel();
      ISpell spell = new Mock<ISpell>().Object;
      sut.ShouldNotifyOn(model => model.SelectedSpell).When(model => model.SelectedSpell = spell);
      Assert.AreEqual(spell, sut.SelectedSpell);
    }

    [Test]
    public void TestSelectedSpellNotifiesRenderableOnChange()
    {
      var templateMock = new Mock<ISpellTemplate>();
      IMainWindowViewModel sut = new MainWindowViewModel(template: templateMock.Object);
      ISpell spell = new Mock<ISpell>().Object;
      sut.ShouldNotifyOn(model => model.Renderable).When(model => model.SelectedSpell = spell);
      templateMock.Verify(t => t.Apply(It.IsAny<ISpell>(), It.IsAny<ICharacterInformation>()), Times.Once);
    }

    [Test]
    public void TestCharacterInformation()
    {
      IMainWindowViewModel sut = new MainWindowViewModel();
      var c = new Mock<ICharacterInformation>().Object;
      sut.ShouldNotifyOn(model => model.CharacterInformation).When(model => model.CharacterInformation = c);
      Assert.AreEqual(c, sut.CharacterInformation);
    }

    [Test]
    public void TestCharacterInformationNotifiesRenderableOnChange()
    {
      var templateMock = new Mock<ISpellTemplate>();
      IMainWindowViewModel sut = new MainWindowViewModel(template: templateMock.Object);
      var c = new Mock<ICharacterInformation>().Object;
      sut.ShouldNotifyOn(model => model.Renderable).When(model => model.CharacterInformation = c);
      templateMock.Verify(t => t.Apply(It.IsAny<ISpell>(), It.IsAny<ICharacterInformation>()), Times.Once);
    }

    [Test]
    public void TestMainWindowViewModel()
    {
      IEnumerable<ISpell> spells = new List<ISpell>
      {
        new Mock<ISpell>().Object,
        new Mock<ISpell>().Object
      };
      ICharacterInformation c = new Mock<ICharacterInformation>().Object;
      var templateMock = new Mock<ISpellTemplate>();
      templateMock.Setup(m => m.Apply(It.IsAny<ISpell>(), It.IsAny<ICharacterInformation>()))
        .Returns(new Block("TestId"));
      IMainWindowViewModel sut = new MainWindowViewModel(spells, c, templateMock.Object);

      CollectionAssert.AreEqual(spells, sut.Spells);
      Assert.AreEqual(c, sut.CharacterInformation);
      templateMock.Verify(t => t.Apply(It.IsAny<ISpell>(),It.IsAny<ICharacterInformation>()), Times.Once);
      Assert.NotNull(sut.Renderable);
      Assert.AreEqual("TestId",sut.Renderable.Id);
    }
  }
}
