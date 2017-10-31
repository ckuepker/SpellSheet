using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using de.inc47.Spells;
using de.inc47.SpellSheet.Render;
using de.inc47.SpellSheet.Template;

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
    private readonly ISpellTemplate _template;

    public MainWindowViewModel(IEnumerable<ISpell> spells = null, ICharacterInformation character = null, ISpellTemplate template = null)
    {
      SelectedFont = AvailableFonts[0];
      ShowGrid = true;
      _characterInformation = character;
      Spells = spells;
      _template = template;
      if (Spells != null && Spells.Any() && CharacterInformation != null)
      {
        SelectedSpell = Spells.FirstOrDefault();
      }
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
        if (_template != null)
        {
          Renderable = _template.Apply(SelectedSpell, CharacterInformation);
        }
      }
    }

    public ICharacterInformation CharacterInformation
    {
      get { return _characterInformation; }
      set
      {
        _characterInformation = value;
        OnPropertyChanged("CharacterInformation");
        if (_template != null)
        {
          Renderable = _template.Apply(SelectedSpell, CharacterInformation);
        }
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