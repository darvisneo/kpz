using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab_1
{
    class Money
    {
        public int WholePart { get; private set; }
        public int Kopika { get; private set; }

        public Money(int wholePart = 0, int kopika = 0)
        {
            SetAmount(wholePart, kopika);
        }

        public void SetAmount(int wholePart, int kopika)
        {
            if (kopika >= 100)
            {
                wholePart += kopika / 100;
                kopika = kopika % 100;
            }
            WholePart = wholePart;
            Kopika = kopika;
        }

        public override string ToString()
        {
            return $"{WholePart}.{Kopika:D2} грн";
        }

        public void Decrease(decimal amount)
        {
            int totalKopika = WholePart * 100 + Kopika;
            int decreaseKopika = (int)(amount * 100);
            totalKopika = Math.Max(0, totalKopika - decreaseKopika);
            SetAmount(totalKopika / 100, totalKopika % 100);
        }
    }
}
