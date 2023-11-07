using System;

namespace Factory
{
    class Program
    {
        static void Main(string[] args)
        {
            Developer dev = new PanelDeveloper("ООО КирпичСтрой");
            dev.Show();
            dev.Create();
            
            
            dev = new WoodDeveloper();
            //dev = new WoodDeveloper("Частный застройщик");
            dev.Show();
            dev.Create();

            dev = new PentDeveloper("3AO MMM");
            dev.Show();
            dev.Create();
        }
    }

    // абстрактный класс строительной компании
    abstract class Developer
    {
        public string Name { get; set; }

        public Developer(string name)
        {
            Name = name;
        }
        // фабричный метод
        abstract public House Create();

        abstract public void Show();
    }
    // строит панельные дома
    class PanelDeveloper : Developer
    {
        public PanelDeveloper(string name) : base(name)
        { }

        public override House Create()
        {
            return new PanelHouse();
        }

        public override void Show()
        {
            Console.WriteLine(Name + "\n");
        }
    }

    // строит деревянные дома
    class WoodDeveloper : Developer
    {
        public WoodDeveloper(string name = "WoodDeveloper") : base(name)
        { 
            Name = name; 
        }

        public override House Create()
        {
            return new WoodHouse();
        }

        public override void Show()
        {
            Console.WriteLine("\n"+Name);
        }
    }

    // пентхаус
    class PentDeveloper : Developer
    {
        public PentDeveloper(string name) : base(name)
        { }

        public override House Create()
        {
            return new PentHouse();
        }

        public override void Show()
        {
            Console.WriteLine("\n"+Name+"\n");
        }
    }

    abstract class House
    { }

    class PanelHouse : House
    {
        public PanelHouse()
        {
            Console.WriteLine("Панельный дом построен");
        }
    }
    class WoodHouse : House
    {
        public WoodHouse()
        {
            Console.WriteLine("Деревянный дом построен");
        }
    }

    class PentHouse : House
    {
        public PentHouse()
        {
            Console.WriteLine("Нафиг панельный и деревянный, строим Пентхаус");
        }
    }

}
