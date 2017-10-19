using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace de.inc47.SpellSheet.Preview.ViewModel
{
  public interface IMainWindowViewModel : IViewModelBase
  {
    ObservableCollection<string> AvailableFonts { get; }
    string SelectedFont { get; set; }
    bool ShowGrid { get; set; }
  }
}
