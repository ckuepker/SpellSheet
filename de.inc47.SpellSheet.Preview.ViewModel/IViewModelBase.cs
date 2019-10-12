using System.Collections.Specialized;
using System.ComponentModel;

namespace de.inc47.SpellSheet.Preview.ViewModel
{
  public interface IViewModelBase : INotifyPropertyChanged, INotifyCollectionChanged, IWeakEventListener
  {
  }
}