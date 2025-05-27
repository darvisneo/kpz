using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lab1SoftwareConstruction;

namespace lab_1
{
    class Warehouse
    {
        private readonly List<WarehouseItem> _items = new();

        public void ReceiveProduct(WarehouseItem item)
        {
            _items.Add(item);
        }

        public void ShowInventory()
        {
            Console.WriteLine("Інвентаризація складу:");
            foreach (var item in _items)
            {
                Console.WriteLine(item);
            }
        }

        public bool ShipProduct(string productName, int Kilkist)
        {
            foreach (var item in _items)
            {
                if (item.Product.Name == productName && item.RemoveKilkist(Kilkist))
                {
                    Console.WriteLine($"Відвантажено {Kilkist} одиниць товару '{productName}'");
                    return true;
                }
            }
            Console.WriteLine($"Не вдалося відвантажити товар '{productName}'");
            return false;
        }
    }
}
