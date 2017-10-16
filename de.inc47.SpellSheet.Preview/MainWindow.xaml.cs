using System.Windows;
using de.inc47.Spells;
using de.inc47.SpellSheet.IO;
using de.inc47.SpellSheet.Render;
using de.inc47.SpellSheet.Render.Enum;

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
      var muLabel = new Text(54,0,3,1,"MU",TextStyle.Label);
      var muContent = new Text(55,0,3,1,""+ci.Mut,TextStyle.Default);

      Preview.RenderText(muLabel);
      Preview.RenderText(muContent);
    }
  }
}
