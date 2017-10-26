using System;
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

    [Test]
    public void TestLeftOf()
    {
      IRenderable target = new Text(1, 2, 3, 4, "", TextStyle.Default);
      IText sut = new RenderableBuilder().LeftOf(target).Text();
      Assert.AreEqual(1, sut.Row);
      Assert.AreEqual(1, sut.Column);
    }

    [Test]
    public void TestLeftOfThrowsExceptionOnExceedLimits()
    {
      IRenderable target = new Text(1, 0, 3, 4, "", TextStyle.Default);
      IRenderableBuilder sut = new RenderableBuilder();
      Assert.Throws<ArgumentException>(() => sut.LeftOf(target));
    }

    [Test]
    public void TestAboveThrowsExceptionOnExceedLimits()
    {
      IRenderable target = new Text(0, 2, 3, 4, "", TextStyle.Default);
      IRenderableBuilder sut = new RenderableBuilder();
      Assert.Throws<ArgumentException>(() => sut.Above(target));
    }

    [Test]
    public void TestDefaultPosition()
    {
      IRenderable sut = new RenderableBuilder().Text();
      Assert.AreEqual(0, sut.Row);
      Assert.AreEqual(0, sut.Column);
    }
  }
}
