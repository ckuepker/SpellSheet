using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spells
{
  public interface ICharacterInformation
  {
    string Name { get; }
    int Mut { get; }
    int Klugheit { get; }
    int Intuition { get; }
    int Charisma { get; }
    int Fingerfertigkeit { get; }
    int Körperkraft { get; }
    int Konstitution { get; }
    int Gewandheit { get; }
    int Magieresistenz { get; }
    int Selbstbeherrschung { get; }
    int Astralenergie { get; }
  }
}
