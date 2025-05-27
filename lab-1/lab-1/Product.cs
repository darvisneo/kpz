using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lab1SoftwareConstruction;

namespace lab_1
{
    class Product
    {
        public string Name { get; private set; }
        public string Category { get; private set; }
        public Money Price { get; private set; }

        public Product(string name, string category, Money price)
        {
            Name = name;
            Category = category;
            Price = price;
        }

        public void DecreasePrice(decimal amount)
        {
            Price.Decrease(amount);
        }

        public override string ToString()
        {
            return $"{Name} ({Category}) - Ціна: {Price}";
        }
    }
}
