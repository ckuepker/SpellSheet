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
      IRenderable target = new Text(2, 4 - 2, 5, 2, "", TextStyle.Default);
      IText sut = new RenderableBuilder().Below(target).Text("", TextStyle.Default);
      Assert.AreEqual(4, sut.Row);
      Assert.AreEqual(2, sut.Column);
      Assert.AreEqual(0, sut.Width);
      Assert.AreEqual(0, sut.Height);
    }
    
    [Test]
    public void RightOf()
    {
      IRenderable target = new Text(2,4,5,2,"",TextStyle.Default);
      IText sut = new RenderableBuilder().RightOf(target).Text("", TextStyle.Default);
      Assert.AreEqual(2, sut.Row);
      Assert.AreEqual(9, sut.Column);
      Assert.AreEqual(0, sut.Width);
      Assert.AreEqual(0, sut.Height);
    }
    
  }
}
