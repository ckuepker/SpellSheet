using de.inc47.SpellSheet.Render.Enum;

namespace de.inc47.SpellSheet.Render
{
  public interface INumeric : IRenderable
  {
    NumericStyle Style { get; }
    int Number { get; }
    string Suffix { get; }
  }

  public class Numeric : Renderable, INumeric
  {
    public Numeric(int row, int column, int width, int height, NumericStyle style, int number, string suffix = "", string id = "") : base(row, column, width, height, id)
    {
      Style = style;
      Number = number;
      Suffix = suffix;
    }

    public NumericStyle Style { get; }
    public int Number { get; }
    public string Suffix { get; }
  }
}
