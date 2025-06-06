using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace zav2
{
    class Palladin : IHero
    {
        public string GetDescription() => "";
        public string GetHeroClass() => "Palladin";
        public int GetPower() => 9;
    }
}
