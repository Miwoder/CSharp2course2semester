using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            Driver driver = new Driver();
            Sport auto = new Sport();
            driver.Travel(auto);
            Simple simple = new Simple();
            ISportcar simpleCar = new SimpleToSportAdapter(simple);
            driver.Travel(simpleCar);
            Console.WriteLine();


            TransportTicket ticket1 = new TicketPerMonth();
            ticket1 = new ForBus(ticket1);
            Console.WriteLine(ticket1.Name + " Цена: " +ticket1.GetCost());
            TransportTicket ticket2 = new TicketForTrips();
            ticket2 = new ForBus(ticket2);
            ticket2 = new ForTrain(ticket2);
            Console.WriteLine(ticket2.Name + " Цена: " + ticket2.GetCost());
            Console.WriteLine();


            River ocean = new Ocean("Мировой океан");
            River drut = new Ocean("Река Друть");
            River lake1 = new Fish("Озеро 1");
            River lake2 = new Fish("Озеро 2");
            drut.Add(lake1);
            drut.Add(lake2);
            ocean.Add(lake2);
            ocean.Add(drut);
            ocean.Print();
            Console.WriteLine();



            var book1 = new Map { Title = "Book first" };
            book1.AddComponent(new MapComponent { Title = "Part 1" });
            book1.AddComponent(new MapComponent { Title = "Part 2" });
            var book2 = new Map { Title = "Nottty" };
            book2.AddComponent(book1);
            book2.Draw();
            var house = book2.Find("Part 1");
            house.Draw();

            Console.ReadLine();
        }
    }


    interface ISportcar
    {
        void Drive();
    }

    class Sport : ISportcar
    {
        public void Drive()
        {
            Console.WriteLine("Водитель участвует в гонке");
        }
    }
    class Driver
    {
        public void Travel(ISportcar sportcar)
        {
            sportcar.Drive();
        }
    }

    interface ISimplecar
    {
        void Move();
    }

    class Simple : ISimplecar
    {
        public void Move()
        {
            Console.WriteLine("Водитель едет по городу");
        }
    }

    class SimpleToSportAdapter : ISportcar
    {
        Simple simple;
        public SimpleToSportAdapter(Simple c)
        {
            simple = c;
        }

        public void Drive()
        {
            simple.Move();
        }
    }






    abstract class TransportTicket
    {
        public TransportTicket(string n)
        {
            this.Name = n;
        }
        public string Name { get; protected set; }
        public abstract int GetCost();
    }

    class TicketPerMonth : TransportTicket
    {
        public TicketPerMonth() : base("Проездной на месяц на метро")
        { }
        public override int GetCost()
        {
            return 10;
        }
    }
    class TicketForTrips : TransportTicket
    {
        public TicketForTrips()
            : base("Проездной на 10 поездок на метро")
        { }
        public override int GetCost()
        {
            return 8;
        }
    }

    abstract class TicketDecorator : TransportTicket
    {
        protected TransportTicket transportTicket;
        public TicketDecorator(string n, TransportTicket transportTicket) : base(n)
        {
            this.transportTicket = transportTicket;
        }
    }

    class ForBus : TicketDecorator
    {
        public ForBus(TransportTicket p)
            : base(p.Name + ", на автобусы", p)
        { }

        public override int GetCost()
        {
            return transportTicket.GetCost() + 3;
        }
    }

    class ForTrain : TicketDecorator
    {
        public ForTrain(TransportTicket p)
            : base(p.Name + ", на трамвай", p)
        { }

        public override int GetCost()
        {
            return transportTicket.GetCost() + 5;
        }
    }




    abstract class River
    {
        protected string name;

        public River(string name)
        {
            this.name = name;
        }

        public virtual void Add(River fish) { }

        public virtual void Remove(River fish) { }

        public virtual void Print()
        {
            Console.WriteLine(name);
        }
    }
    class Ocean : River
    {
        
        private List<River> components = new List<River>();

        public Ocean(string name)
            : base(name)
        {
        }

        public override void Add(River component)
        {
            components.Add(component);
        }

        public override void Remove(River component)
        {
            components.Remove(component);
        }

        public override void Print()
        {
            Console.WriteLine("Водоем: " + name);
            Console.WriteLine("Втекаеют:");
            for (int i = 0; i < components.Count; i++)
            {
                components[i].Print();
            }

        }
    }

    class Fish : River
    {
        public Fish(string name)
                : base(name)
        { }
    }






    public interface IComponent
    {
        string Title
        {
            get; set;
        }
        void Draw();
        IComponent Find(string title);
    }
    public class MapComponent : IComponent
    {
        public string Title
        {
            get; set;
        }
        public void Draw()
        {
            Console.WriteLine(Title);
        }
        public IComponent Find(string title)
        {
            return Title == title ? this : null;
        }
    }
    public class Map : IComponent
    {
        private readonly List<IComponent> _map = new List<IComponent>();
        public string Title { get; set; }
        public void AddComponent(IComponent component)
        {
            _map.Add(component);
        }
        public void Draw()
        {
            Console.WriteLine(Title);
            foreach (var component in _map)
            {
                component.Draw();
            }
        }
        public IComponent Find(string title)
        {
            if (Title == title)
            {
                return this;
            }
            foreach (var component in _map)
            {
                var found = component.Find(title);
                if (found != null)
                {
                    return found;
                }
            }
            return null;
        }
    }


}
