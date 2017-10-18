using de.inc47.SpellSheet.Preview.ViewModel.Test.Extension;
using NUnit.Framework;

namespace de.inc47.SpellSheet.Preview.ViewModel.Test
{
  public class MainWindowViewModelTest
  {
    [Test]
    public void TestGetAvailableFonts()
    {
      var sut = new MainWindowViewModel();
      var fonts = sut.AvailableFonts;
      Assert.AreEqual(2, fonts.Count);
      Assert.AreEqual("Morpheus",fonts[0]);
      Assert.AreEqual("Unzialish",fonts[1]);
    }

    [Test]
    public void TestGetSelectedFont()
    {
      var sut = new MainWindowViewModel();
      
      Assert.AreEqual("Morpheus", sut.SelectedFont, "Morpheus is default font family");
      Assert.IsTrue(sut.AvailableFonts.Contains(sut.SelectedFont));
    }

    [Test]
    public void TestSetSelectedFont()
    {
      var sut = new MainWindowViewModel();

      sut.ShouldNotifyOn(s => s.SelectedFont).When(s => sut.SelectedFont = "Unzialish");
      Assert.AreEqual("Unzialish", sut.SelectedFont);
    }

    [Test]
    public void TestSetSelectedFontToInvalid()
    {
      var sut = new MainWindowViewModel();
      string expectedFont = sut.SelectedFont;
      sut.ShouldNotNotifyOn(s => s.SelectedFont).When(s => sut.SelectedFont = "Invented font");
      Assert.AreEqual(expectedFont, sut.SelectedFont);
    }
  }
}
