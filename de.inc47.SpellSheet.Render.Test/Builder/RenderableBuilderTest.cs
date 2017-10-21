using de.inc47.SpellSheet.Render.Builder;
using de.inc47.SpellSheet.Render.Enum;
using NUnit.Framework;

namespace de.inc47.SpellSheet.Render.Test.Builder
{
  public class RenderableBuilderTest
  {
    [Test]
    public void TestBelow()
    {
      int expectedRow = 2;
      int expectedColumn = 4;
      IRenderable target = new Text(2, 4 - 2, 5, 2, "", TextStyle.Default);
      IText sut = new RenderableBuilder().Below(target).Text("", TextStyle.Default);
      Assert.AreEqual(4, sut.Row);
      Assert.AreEqual(2, sut.Column);
    }

    [Test]
    public void TestAbove()
    {

    }

    [Test]
    public void TestAfter()
    {

    }

    public void TestBefore()
    {

    }
  }
}
