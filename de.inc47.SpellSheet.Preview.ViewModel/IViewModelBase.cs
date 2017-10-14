using System.Collections.Specialized;
using System.ComponentModel;
using System.Windows;

namespace de.inc47.SpellSheet.Preview.ViewModel
{
  public interface IViewModelBase : INotifyPropertyChanged, INotifyCollectionChanged, IWeakEventListener
  {
  }
}