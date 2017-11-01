using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using de.inc47.Spells;
using de.inc47.SpellSheet.IO;
using de.inc47.SpellSheet.Preview.ViewModel;
using de.inc47.SpellSheet.Template;

namespace de.inc47.SpellSheet.Preview
{
  /// <summary>
  /// Interaction logic for MainWindow.xaml
  /// </summary>
  public partial class MainWindow : Window
  {
    public MainWindow()
    {
      InitializeComponent();
      ICharacterImporter cimport = new CharacterImporter();
      ICharacterInformation ci = cimport.Import("character.json");
      ISpellsImporter simport = new SpellsImporter();
      IEnumerable<ISpell> spells = simport.Import("spells.json");
      var vm = new MainWindowViewModel(spells,ci,new SpellTemplate());
      DataContext = vm;
      //Preview.Render(vm.Renderable);
    }
  }
}
