using System.Collections.Generic;
using System.Collections.ObjectModel;
using de.inc47.Spells;
using de.inc47.SpellSheet.Render;

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
    private IRenderable _renderable;
    private ISpell _selectedSpell;
    private ICharacterInformation _characterInformation;

    public MainWindowViewModel(IEnumerable<ISpell> spells = null, ICharacterInformation character = null)
    {
      SelectedFont = AvailableFonts[0];
      ShowGrid = true;
      CharacterInformation = character;
      Spells = spells;
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

    public IEnumerable<ISpell> Spells { get; set; }

    public ISpell SelectedSpell
    {
      get { return _selectedSpell; }
      set
      {
        _selectedSpell = value;
        OnPropertyChanged("SelectedSpell");
        
      }
    }

    public ICharacterInformation CharacterInformation
    {
      get { return _characterInformation; }
      set
      {
        _characterInformation = value;
        OnPropertyChanged("CharacterInformation");
      }
    }

    public IRenderable Renderable
    {
      get { return _renderable; }
      set
      {
        _renderable = value;
        OnPropertyChanged("Renderable");
      }
    }
  }
}