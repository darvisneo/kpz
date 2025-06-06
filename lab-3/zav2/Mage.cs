using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace zav2
{
    class Mage : IHero
    {
        public string GetDescription() => "";
        public string GetHeroClass() => "Mage";
        public int GetPower() => 8;
    }
}
