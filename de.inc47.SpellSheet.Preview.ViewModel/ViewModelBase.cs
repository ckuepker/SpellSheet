using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace de.inc47.SpellSheet.Preview.ViewModel
{
  public abstract class ViewModelBase : IViewModelBase
  {
    public event PropertyChangedEventHandler PropertyChanged;

    protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
    {
      PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
  }
}