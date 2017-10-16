using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;
using de.inc47.SpellSheet.Preview.ViewModel;
using de.inc47.SpellSheet.Render;

namespace de.inc47.SpellSheet.Preview
{
  /// <summary>
  /// Interaction logic for PdfPreview.xaml
  /// </summary>
  public partial class PdfPreview : UserControl, IRenderer
    {
    private readonly int _columns, _rows;
    private readonly int _gridsize = 15;

    public PdfPreview()
    {
      DataContext = new PdfPreviewViewModel();
      InitializeComponent();
      _columns =  (21 * 2) - 5;
      _rows = (29 * 2) - 2;
      Width = _columns * _gridsize;
      Height = _rows * _gridsize;
      InitGrid();
    }

    private void InitGrid()
    {
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
          r.Stroke = new SolidColorBrush(Colors.Gray);
          Grid.SetRow(r, i);
          Grid.SetColumn(r, j);
          PreviewGrid.Children.Add(r);
        }
      }
    }

      public void Render(IRenderable element)
      {
        throw new System.NotImplementedException();
      }

      public void RenderBlock(IBlock block)
      {
        throw new System.NotImplementedException();
      }

      public void RenderText(IText text)
      {
        throw new System.NotImplementedException();
      }

      public void RenderNumeric(INumeric numeric)
      {
        throw new System.NotImplementedException();
      }
    }
}
