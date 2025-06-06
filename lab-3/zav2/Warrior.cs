using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace zav2
{
    class Warrior : IHero
    {
        public string GetDescription() => "";
        public string GetHeroClass() => "Warrior";
        public int GetPower() => 10;
    }
}
