using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;
using de.inc47.SpellSheet.Preview.ViewModel;
using de.inc47.SpellSheet.Render;
using de.inc47.SpellSheet.Render.Enum;

namespace de.inc47.SpellSheet.Preview
{
  /// <summary>
  /// Interaction logic for PdfPreview.xaml
  /// </summary>
  public partial class PdfPreview : UserControl, IRenderer
  {
    private readonly int _columns, _rows;
    private readonly int _gridsize = 15;

    private static readonly Random Rand = new Random();
    private IList<Rectangle> _gridRectangles;

    public PdfPreview()
    {
      DataContext = new PdfPreviewViewModel();
      InitializeComponent();
      _columns = 37; //(21 * 2) - 5
      _rows = 56; //(29 * 2) - 2;
      Width = _columns * _gridsize;
      Height = _rows * _gridsize;
      InitGrid();
    }

    private void InitGrid()
    {
      _gridRectangles = new List<Rectangle>();
      for (int i = 0; i < _rows; i++)
      {
        var rd = new RowDefinition();
        rd.Height = new GridLength(_gridsize);
        PreviewGrid.RowDefinitions.Add(rd);
        for (int j = 0; j < _columns; j++)
        {
          var cd = new ColumnDefinition();
          cd.Width = new GridLength(_gridsize);
          PreviewGrid.ColumnDefinitions.Add(cd);
          Rectangle r = new Rectangle();
          r.Width = _gridsize;
          r.Height = _gridsize;
          r.Fill = new SolidColorBrush(Colors.White);
          r.Stroke = new SolidColorBrush(Colors.HotPink);
          Grid.SetRow(r, i);
          Grid.SetColumn(r, j);
          PreviewGrid.Children.Add(r);
          _gridRectangles.Add(r);
        }
      }
    }

    public void Render(IRenderable element)
    {
      if (element is IBlock)
      {
        Render((IBlock)element);
        return;
      }
      if (element is IText)
      {
        Render((IText)element);
        return;
      }
      if (element is INumeric)
      {
        Render((INumeric)element);
        return;
      }
      throw new ArgumentException(string.Format("Unsupported type received in renderer: {0}", element.GetType().FullName));
    }

    public void Render(IBlock block)
    {
      foreach (IRenderable child in block.Children)
      {
        Render(child);
      }
    }

    public void Render(IText text)
    {
      var tb = new TextBlock();
      tb.Text = text.Content;
      switch (text.Style)
      {
        case TextStyle.Header:
          tb.Style = (Style) FindResource("HeaderTextStyle");
          break;
        case TextStyle.Label:
          tb.Style = (Style)FindResource("LabelTextStyle");
          break;
        case TextStyle.Default:
          tb.Style = (Style)FindResource("DefaultTextStyle");
          break;
        default:
          throw new ArgumentOutOfRangeException();
      }
      
      Grid.SetColumn(tb, text.Column);
      Grid.SetRow(tb, text.Row);
      Grid.SetColumnSpan(tb, text.Width);
      Grid.SetRowSpan(tb, text.Height);
      ClearGrid(text.Row, text.Column, text.Width, text.Height);
      PreviewGrid.Children.Add(tb);
    }

    public void Render(INumeric numeric)
    {
      var sp = new StackPanel();
      sp.Orientation = Orientation.Horizontal;
      for (int i = 0; i < numeric.Number; i++)
      {
        var r = new Rectangle();
        r.Style = (Style) FindResource("NumericRectangleStyle");
        sp.Children.Add(r);
      }
      if (numeric.Suffix != string.Empty)
      {
        var tb = new TextBlock();
        tb.Style = (Style) FindResource("NumericSuffixTextStyle");
        tb.Text = numeric.Suffix;
        sp.Children.Add(tb);
      }
      Grid.SetRow(sp, numeric.Row);
      Grid.SetColumn(sp, numeric.Column);
      Grid.SetRowSpan(sp, numeric.Height);
      Grid.SetColumnSpan(sp, numeric.Width);
      ClearGrid(numeric.Row, numeric.Column, numeric.Width, numeric.Height);
      PreviewGrid.Children.Add(sp);
    }

    private void ClearGrid(int row, int column, int width, int height)
    {
      var boxesToRemove = _gridRectangles.Where(c =>
        Grid.GetColumn(c) >= column
        && Grid.GetColumn(c) < column + width
        && Grid.GetRow(c) >= row
        && Grid.GetRow(c) < row + height);
      foreach (var rectangle in boxesToRemove)
      {
        PreviewGrid.Children.Remove(rectangle);
      }
    }

    private Color GetRandomColour()
    {
      byte[] bytes = new byte[3];
      Rand.NextBytes(bytes);
      return Color.FromRgb(bytes[0], bytes[1], bytes[2]);
    }
  }
}
