using System;
using System.Collections.Generic;
using System.Text;
using lab_1;

namespace Lab1SoftwareConstruction
{
    class Program
    {
        static void Main()
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            var priceLaptop = new Money(150, 75);
            var laptop = new Product("Ноутбук", "Електроніка", priceLaptop);
            var priceCoffee = new Money(25, 50);
            var coffee = new Product("Кава", "Напої", priceCoffee);

            Console.WriteLine("== Створення продуктів ==");
            Console.WriteLine(laptop);
            Console.WriteLine(coffee);
            Console.WriteLine();
            var itemLaptop = new WarehouseItem(laptop, 3, DateTime.Now);
            var itemCoffee = new WarehouseItem(coffee, 20, DateTime.Now);

            var warehouse = new Warehouse();
            warehouse.ReceiveProduct(itemLaptop);
            warehouse.ReceiveProduct(itemCoffee);

            Console.WriteLine("== Додавання на склад ==");
            warehouse.ShowInventory();
            Console.WriteLine();

            Console.WriteLine("== Відвантаження кави 10 штук ==");
            warehouse.ShipProduct("Кава", 10);
            Console.WriteLine();

            Console.WriteLine("== Зниження ціни на ноутбун ==");
            laptop.DecreasePrice(20);
            Console.WriteLine(laptop);
            Console.WriteLine();

            Console.WriteLine("== Звіт по складу ==");
            var reporting = new Reporting(warehouse);
            reporting.ShowInventoryReport();

            Console.WriteLine("\n== Спроба відвантажити 10 кави ==");
            warehouse.ShipProduct("Кава", 10);
            Console.WriteLine("\n== Спроба відвантажити 10 кави ==");
            warehouse.ShipProduct("Кава", 10);
        }

    }
}
