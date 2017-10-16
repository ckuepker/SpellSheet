using de.inc47.SpellSheet.Render.Enum;

namespace de.inc47.SpellSheet.Render
{
  public interface INumeric : IRenderable
  {
    NumericStyle Style { get; }
  }
}
