using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Moq;
using NUnit.Framework;

namespace de.inc47.SpellSheet.Render.Test
{
  public class BlockTest
  {
    [Test]
    public void TestDimensionsAreZeroIfNoChildren()
    {
      var sut = new Block();
      Assert.NotNull(sut.Children);
      CollectionAssert.IsEmpty(sut.Children);
      Assert.AreEqual(0, sut.Row);
      Assert.AreEqual(0, sut.Column);
      Assert.AreEqual(0, sut.Width);
      Assert.AreEqual(0, sut.Height);
    }

    [Test]
    public void TestDimensions()
    {
      var e1 = new Mock<IRenderable>();
      e1.Setup(m => m.Column).Returns(1).Verifiable();
      e1.Setup(m => m.Row).Returns(2).Verifiable();
      e1.Setup(m => m.Width).Returns(3).Verifiable();
      e1.Setup(m => m.Height).Returns(4).Verifiable();
      var e2 = new Mock<IRenderable>();
      e2.Setup(m => m.Column).Returns(5).Verifiable();
      e2.Setup(m => m.Row).Returns(7).Verifiable();
      e2.Setup(m => m.Width).Returns(3).Verifiable();
      e2.Setup(m => m.Height).Returns(3).Verifiable();

      var sut = new Block("", new List<IRenderable> { e1.Object, e2.Object });
      Assert.AreEqual(2, sut.Children.Count);
      Assert.AreEqual(1, sut.Column);
      Assert.AreEqual(2, sut.Row);
      Assert.AreEqual(7, sut.Width);
      Assert.AreEqual(8, sut.Height);

      e1.Verify();
      e2.Verify();
    }
  }
}
