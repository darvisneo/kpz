using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lab1SoftwareConstruction;

namespace lab_1
{
    class Reporting
    {
        private readonly Warehouse _warehouse;

        public Reporting(Warehouse warehouse)
        {
            _warehouse = warehouse;
        }

        public void ShowInventoryReport()
        {
            Console.WriteLine("=== Звіт по складу ===");
            _warehouse.ShowInventory();
        }
    }
}
