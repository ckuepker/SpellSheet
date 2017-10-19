using System;
using de.inc47.Spells;
using de.inc47.Spells.Enumerations;
using de.inc47.SpellSheet.Render;
using de.inc47.SpellSheet.Render.Enum;

namespace de.inc47.SpellSheet.Template
{
  public class SpellTemplate : ITemplate<Tuple<ISpell, ICharacterInformation>>
  {
    public IBlock Apply(Tuple<ISpell, ICharacterInformation> data)
    {
      var spell = data.Item1;
      var info = data.Item2;
      var root = new Block();

      root.Children.Add(RenderEigenschaften(info));
      root.Children.Add(RenderSpellName(spell.Name));
      root.Children.Add(RenderProbe(spell, info));
      return root;
    }

    private IRenderable RenderProbe(ISpell spell, ICharacterInformation info)
    {
      IBlock b = new Block();
      string probe = string.Format("{0}/{1}/{2}", spell.Probe1.ToString(), spell.Probe2.ToString(),
        spell.Probe3.ToString());
      b.Children.Add(new Text(4,0,4,1,probe,TextStyle.Label));
      string probenWerte = string.Format("{0}/{1}/{2}{3}{4}",
        info.GetEigenschaft(spell.Probe1),
        info.GetEigenschaft(spell.Probe2),
        info.GetEigenschaft(spell.Probe3),
        spell.ZfW > 0 ? "+" : "-",
        spell.ZfW);
      b.Children.Add(new Text(5,0,4,1,probenWerte,TextStyle.Default));
      return b;
    }

    private IRenderable RenderSpellName(string spellName)
    {
      return new Text(0,0,37,3, spellName, TextStyle.Header);
    }

    private Block RenderEigenschaften(ICharacterInformation character)
    {
      var block = new Block();
      int columnOffset = 0;
      int width = 3;
      foreach (Eigenschaft e in Enum.GetValues(typeof(Eigenschaft)))
      {
        var eigenschaftsBlock = new Block();
        var label = new Text(54, 6 + columnOffset, width, 1, e.ToString(), TextStyle.Label);
        var text = new Text(55, 6 + columnOffset, width, 1, character.GetEigenschaft(e).ToString(), TextStyle.Default);
        eigenschaftsBlock.Children.Add(label);
        eigenschaftsBlock.Children.Add(text);
        block.Children.Add(eigenschaftsBlock);
        columnOffset += width;
      }
      return block;
    }
  }
}