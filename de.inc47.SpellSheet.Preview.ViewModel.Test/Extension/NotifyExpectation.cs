using System;
using System.ComponentModel;
using NUnit.Framework;

namespace de.inc47.SpellSheet.Preview.ViewModel.Test.Extension
{
  public class NotifyExpectation<T>
    where T : INotifyPropertyChanged
  {
    private readonly T owner;
    private readonly string propertyName;
    private readonly bool eventExpected;

    public NotifyExpectation(T owner,
      string propertyName, bool eventExpected)
    {
      this.owner = owner;
      this.propertyName = propertyName;
      this.eventExpected = eventExpected;
    }

    public void When(Action<T> action)
    {
      bool eventWasRaised = false;
      this.owner.PropertyChanged += (sender, e) =>
      {
        if (e.PropertyName == this.propertyName)
        {
          eventWasRaised = true;
        }
      };
      action(this.owner);

      Assert.AreEqual(this.eventExpected,
        eventWasRaised,
        "PropertyChanged on {0}", this.propertyName);
    }
  }
}