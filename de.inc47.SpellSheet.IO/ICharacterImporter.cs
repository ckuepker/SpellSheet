using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Spells;

namespace de.inc47.SpellSheet.IO
{
    public interface ICharacterImporter
    {
      ICharacterInformation Import(string path);
    }
}
