using System.Collections.ObjectModel;
using de.inc47.SpellSheet.Render;

namespace de.inc47.SpellSheet.Preview.ViewModel
{
  public interface IMainWindowViewModel : IViewModelBase
  {
    ObservableCollection<string> AvailableFonts { get; }
    string SelectedFont { get; set; }
    bool ShowGrid { get; set; }
    IRenderable Renderable { get; set; }
  }
}
