using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace de.inc47.SpellSheet.Preview.Controls
{
  /// <summary>
  /// Interaction logic for PageControl.xaml
  /// </summary>
  public partial class PageControl : UserControl
  {
    public static readonly DependencyProperty ItemsProperty = DependencyProperty.Register(
      "Items", typeof(IEnumerable<object>), typeof(PageControl), new PropertyMetadata(default(IEnumerable<object>)));

    public IEnumerable<object> Items
    {
      get { return (IEnumerable<object>)GetValue(ItemsProperty); }
      set { SetValue(ItemsProperty, value); }
    }

    public static readonly DependencyProperty SelectedItemProperty = DependencyProperty.Register(
      "SelectedItem", typeof(object), typeof(PageControl), new FrameworkPropertyMetadata(default(object))
      {
        BindsTwoWayByDefault = true
      });

    public object SelectedItem
    {
      get { return (object)GetValue(SelectedItemProperty); }
      set { SetValue(SelectedItemProperty, value); }
    }

    public PageControl()
    {
      InitializeComponent();
    }
    
    private void Button_OnClick(object sender, RoutedEventArgs e)
    {
      Button b = sender as Button;
      if (b != null)
      {
        if (b == FirstButton)
        {
          SelectedItem = Items.First();
        }
        if (b == PreviousButton)
        {
          var itemsList = Items.ToList();
          SelectedItem = itemsList[itemsList.IndexOf(SelectedItem) - 1];
        }
        if (b == NextButton)
        {
          var itemsList = Items.ToList();
          SelectedItem = itemsList[itemsList.IndexOf(SelectedItem) + 1];
        }
        if (b == LastButton)
        {
          SelectedItem = Items.Last();
        }
        e.Handled = true;
      }
    }

    protected override void OnPropertyChanged(DependencyPropertyChangedEventArgs e)
    {
      base.OnPropertyChanged(e);
      if (e.Property == ItemsProperty)
      {
        SelectedItem = Items.FirstOrDefault();
        UpdateButtonStates();
      }
      if (e.Property == SelectedItemProperty)
      {
        UpdateButtonStates();
      }
    }

    private void UpdateButtonStates()
    {
      FirstButton.IsEnabled = Items != null && Items.FirstOrDefault() != SelectedItem;
      PreviousButton.IsEnabled = FirstButton.IsEnabled;
      LastButton.IsEnabled = Items != null && Items.LastOrDefault() != SelectedItem;
      NextButton.IsEnabled = LastButton.IsEnabled;
    }
  }
}
