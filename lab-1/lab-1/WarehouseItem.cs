using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lab1SoftwareConstruction;

namespace lab_1
{
    class WarehouseItem
    {
        public Product Product { get; private set; }
        public int Kilkist { get; private set; }
        public DateTime LastSupplyDate { get; private set; }

        public WarehouseItem(Product product, int kilkist, DateTime lastSupplyDate)
        {
            Product = product;
            Kilkist = kilkist;
            LastSupplyDate = lastSupplyDate;
        }

        public void AddQKilkist(int kilkist)
        {
            Kilkist += kilkist;
            LastSupplyDate = DateTime.Now;
        }

        public bool RemoveKilkist(int kilkist)
        {
            if (Kilkist >= kilkist)
            {
                Kilkist -= kilkist;
                return true;
            }
            return false;
        }

        public override string ToString()
        {
            return $"{Product} | Кількість: {Kilkist} | Останнє надходження: {LastSupplyDate:d}";
        }
    }
}
