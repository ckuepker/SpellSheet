using System;
using de.inc47.SpellSheet.Render.Enum;

namespace de.inc47.SpellSheet.Render.Builder
{
  public class RenderableBuilder : IRenderableBuilder
  {
    private int _row = 0, _column = 0, _width = 1, _height = 1;

    public IRenderableBuilder Below(IRenderable target)
    {
      _row = target.Row + target.Height;
      _column = target.Column;
      return this;
    }

    public IRenderableBuilder RightOf(IRenderable target)
    {
      _row = target.Row;
      _column = target.Column + target.Width;
      return this;
    }

    public IRenderableBuilder Above(IRenderable target)
    {
      _row = target.Row - _height;
      _column = target.Column;
      if (_row < 0)
      {
        throw new ArgumentException(string.Format("Element with height {0} cannot be built left of {1} because it would exceed the grid to row {2}", _height, target, _row));
      }
      return this;
    }

    public IRenderableBuilder LeftOf(IRenderable target)
    {
      _row = target.Row;
      _column = target.Column - _width;
      if (_column < 0)
      {
        throw new ArgumentException(string.Format("Element with width {0} cannot be built left of {1} because it would exceed the grid to column {2}",_width,target,_column));
      }
      return this;
    }

    public IText Text(string content = "", TextStyle style = TextStyle.Default)
    {
      return new Text(_row, _column, _width, _height, content, style);
    }
  }
}