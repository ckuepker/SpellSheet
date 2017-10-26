﻿using de.inc47.SpellSheet.Render.Enum;

namespace de.inc47.SpellSheet.Render.Builder
{
  public class RenderableBuilder : IRenderableBuilder
  {
    private int _row = 0, _column = 0, _width = 0, _height = 0;

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

    public IText Text(string content, TextStyle style)
    {
      return new Text(_row, _column, _width, _height, content, style);
    }
  }
}