using System.Security.Cryptography.X509Certificates;
using de.inc47.SpellSheet.Render.Builder;
using de.inc47.SpellSheet.Render.Enum;
using NUnit.Framework;

namespace de.inc47.SpellSheet.Render.Test.Builder
{
  public class RenderableBuilderTest
  {
    [Test]
    public void TestDefaultDimensions()
    {
      IText sut = new RenderableBuilder().Text();
      Assert.AreEqual(1, sut.Height);
      Assert.AreEqual(1, sut.Width);
    }

    [Test]
    public void TestTextDefaults()
    {
      IText sut = new RenderableBuilder().Text();
      Assert.AreEqual(string.Empty, sut.Content);
      Assert.AreEqual(TextStyle.Default, sut.Style);
    }

    [Test]
    public void TestBelow()
    {
      IRenderable target = new Text(2, 4 - 2, 5, 2, "", TextStyle.Default);
      IText sut = new RenderableBuilder().Below(target).Text();
      Assert.AreEqual(4, sut.Row);
      Assert.AreEqual(2, sut.Column);
    }

    [Test]
    public void TestRightOf()
    {
      IRenderable target = new Text(2, 4, 5, 2, "", TextStyle.Default);
      IText sut = new RenderableBuilder().RightOf(target).Text();
      Assert.AreEqual(2, sut.Row);
      Assert.AreEqual(9, sut.Column);
    }

    [Test]
    public void TestAbove()
    {
      IRenderable target = new Text(1, 2, 3, 4, "", TextStyle.Default);
      IText sut = new RenderableBuilder().Above(target).Text();
      Assert.AreEqual(0, sut.Row);
      Assert.AreEqual(2, sut.Column);
    }
  }
}
