using System;

namespace Adapter.Conceptual
{
    // Целевой класс объявляет интерфейс, с которым может работать клиентский код.
    public interface ITarget
    {
        string GetRequest();
    }

    // Адаптируемый класс содержит некоторое полезное поведение, но его
    // интерфейс несовместим с существующим клиентским кодом. Адаптируемый
    // класс нуждается в некоторой доработке, прежде чем клиентский код сможет его использовать.


    class Respons
    {
        public int Id { get; set; }
        public  string SomeText { get; set; }
        public bool Err { get; set; }
        public string TextErr { get; set; }
    }
    class Adaptee
    {
        public Respons GetSpecificRequest()
        { 
            Random rand = new Random();
            Respons respons = new Respons()
            {
                Id = rand.Next(0, 1000),
                SomeText = "SomeText ",
                Err = false
            };
            return respons;
        }
    }

    // Адаптер делает интерфейс Адаптируемого класса совместимым с целевым интерфейсом.
    class Adapter : ITarget
    {
        private Adaptee _adaptee;

        public Adapter(Adaptee adaptee)
        {
            _adaptee = adaptee;
        }

        public string GetRequest()
        {
            var req = _adaptee.GetSpecificRequest();
            return $"This is adapted {req.Id} {req.SomeText}";
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Adaptee adaptee = new Adaptee();
            ITarget target = new Adapter(adaptee);

            Console.WriteLine("Adaptee interface is incompatible with the client.");
            Console.WriteLine("But with adapter client can call it's method.");
            Console.WriteLine(target.GetRequest());
        }
    }
}