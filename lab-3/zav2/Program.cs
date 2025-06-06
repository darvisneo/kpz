using System;
using System.Collections.Generic;
using System.Text;
using zav2;

namespace zav2
{
    interface IHero
    {
        string GetHeroClass();
        string GetDescription();
        int GetPower();
    }
    abstract class HeroDecorator : IHero
    {
        protected IHero hero;

        public HeroDecorator(IHero hero)
        {
            this.hero = hero;
        }

        public virtual string GetDescription() => hero.GetDescription();
        public virtual string GetHeroClass() => hero.GetHeroClass();
        public virtual int GetPower() => hero.GetPower();
    }
    class Sword : HeroDecorator
    {
        public Sword(IHero hero) : base(hero) { }

        public override string GetDescription() => base.GetDescription() + "Sword; ";
        public override int GetPower() => base.GetPower() + 5;
    }
    class Armor : HeroDecorator
    {
        public Armor(IHero hero) : base(hero) { }

        public override string GetDescription() => base.GetDescription() + "Armor; ";
        public override int GetPower() => base.GetPower() + 3;
    }
    class Artifact : HeroDecorator
    {
        public Artifact(IHero hero) : base(hero) { }

        public override string GetDescription() => base.GetDescription() + "Artifact; ";
        public override int GetPower() => base.GetPower() + 7;
    }
    class Program
{
    static void Main(string[] args)
    {
        IHero warrior = new Sword(new Armor(new Warrior()));
        IHero mage = new Artifact(new Mage());
        IHero palladin = new Artifact(new Sword(new Palladin()));

        Console.WriteLine("=== Герої та їх спорядження ===");

        PrintHero(warrior);
        PrintHero(mage);
        PrintHero(palladin);
    }

    static void PrintHero(IHero hero)
    {
        Console.WriteLine($"Hero: {hero.GetHeroClass()}");
        Console.WriteLine($"Inventory: {hero.GetDescription()}");
        Console.WriteLine($"Power: {hero.GetPower()}\n");
    }
}

}
