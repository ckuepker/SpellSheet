using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using de.inc47.Spells;
using de.inc47.SpellSheet.IO;
using de.inc47.SpellSheet.Preview.ViewModel;
using de.inc47.SpellSheet.Render;
using de.inc47.SpellSheet.Render.Enum;
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
      var vm = new MainWindowViewModel();
      DataContext = vm;
      ICharacterImporter cimport = new CharacterImporter();
      ICharacterInformation ci = cimport.Import("character.json");
      ISpellsImporter simport = new SpellsImporter();
      IEnumerable<ISpell> spells = simport.Import("spells.json");
      vm.Spells = spells;
      ITemplate<Tuple<ISpell,ICharacterInformation>> template = new SpellTemplate();
      var templatedBlock = template.Apply(new Tuple<ISpell, ICharacterInformation>(spells.FirstOrDefault(), ci));
      Preview.Render(templatedBlock);
    }
  }
}
