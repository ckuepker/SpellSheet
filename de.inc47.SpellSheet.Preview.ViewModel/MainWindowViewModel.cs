using System.Collections.ObjectModel;

namespace de.inc47.SpellSheet.Preview.ViewModel
{
  public class MainWindowViewModel : ViewModelBase, IMainWindowViewModel
  {
    private readonly ObservableCollection<string> _fonts = new ObservableCollection<string>
    {
      "Morpheus",
      "Unzialish"
    };

    private string _selectedFont;
    private bool _showGrid;

    public MainWindowViewModel()
    {
      SelectedFont = AvailableFonts[0];
      ShowGrid = true;
    }

    public ObservableCollection<string> AvailableFonts
    {
      get { return _fonts; }
    }

    public string SelectedFont
    {
      get { return _selectedFont; }
      set
      {
        if (!string.IsNullOrEmpty(value) && AvailableFonts.Contains(value))
        {
          _selectedFont = value;
          OnPropertyChanged("SelectedFont");
        }
      }
    }

    public bool ShowGrid
    {
      get { return _showGrid; }
      set
      {
        _showGrid = value;
        OnPropertyChanged("ShowGrid");
      }
    }
  }
}