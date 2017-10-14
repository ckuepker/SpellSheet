using System;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace de.inc47.SpellSheet.Preview.ViewModel
{
  public abstract class ViewModelBase : IViewModelBase
  {
    public event NotifyCollectionChangedEventHandler CollectionChanged;

    public bool ReceiveWeakEvent(Type managerType, object sender, EventArgs e)
    {
      if (managerType == typeof(CollectionChangedEventManager))
      {
        ReceiveCollectionChangedEvent(sender, (NotifyCollectionChangedEventArgs) e);
      }
      else if (managerType == typeof(PropertyChangedEventManager))
      {
        OnReceivePropertyChangedEvent(sender, (PropertyChangedEventArgs) e);
      }
      return true;
    }

    protected void OnReceivePropertyChangedEvent(object sender, PropertyChangedEventArgs args)
    {
      
    }

    protected void ReceiveCollectionChangedEvent(object sender, NotifyCollectionChangedEventArgs args)
    {
      
    }

    public event PropertyChangedEventHandler PropertyChanged;

    protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
    {
      PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
  }
}