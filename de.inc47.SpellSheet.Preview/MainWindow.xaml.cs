using System;
using System.Windows;
using de.inc47.Spells;
using de.inc47.SpellSheet.IO;
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
      ICharacterImporter cimport = new CharacterImporter();
      ICharacterInformation ci = cimport.Import("character.json");
      ITemplate<Tuple<ISpell,ICharacterInformation>> template = new SpellTemplate();
      var templatedBlock = template.Apply(new Tuple<ISpell, ICharacterInformation>(null, ci));
      Preview.Render(templatedBlock);
    }
  }
}
