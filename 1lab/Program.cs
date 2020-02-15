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
            int n = 0;
            Cars[] car = new Cars[5];
            Console.WriteLine("Введите кол-во машин(до 5)");
            int k = Convert.ToInt32(Console.ReadLine());
            while (n < k)
            {
                Console.WriteLine("\n 1-Спорт, 2-Обычная");
                int t = Convert.ToInt32(Console.ReadLine());
                if (t == 1)
                {
                    car[n] = new Cars(new SportCar());
                    car[n].Tyype();
                    car[n].Doors();
                }
                else
                {
                    car[n] = new Cars(new SimpleCar());
                    car[n].Tyype();
                    car[n].Doors();
                }
                n++;
            }
            

            CompanyName Companyname = new CompanyName();
            Companyname.Launch("Belarus Motors");
            Console.WriteLine("Единственный поставщик: " + Companyname.Diller.Name);
            Console.WriteLine();


            Director director = new Director();
            Mechanic mechanic = new FullFixer();
            CrushedCar car1 = director.Fix(mechanic);
            Console.WriteLine(car1.ToString());
            mechanic = new InnerFixer();
            CrushedCar car2 = director.Fix(mechanic);
            Console.WriteLine(car2.ToString());
            mechanic = new OutterFixer();
            CrushedCar car3 = director.Fix(mechanic);
            Console.WriteLine(car3.ToString());


            ITank tank = new TankTiger("Tiger", 109);
            ITank clonedTank = tank.Clone();
            tank.GetInfo();
            clonedTank.GetInfo();
            tank = new TankIS("IS-7", 122, "USSR");
            clonedTank = tank.Clone();
            tank.GetInfo();
            clonedTank.GetInfo();


            Console.ReadLine();
        }

        abstract class CarType
        {
            public abstract void Tyype();
        }
        abstract class CarDoors
        {
            public abstract void Doors();
        }
        
        class Sport : CarType
        {
            public override void Tyype()
            {
                Console.WriteLine("Спорткар");
            }
        }
        class Simple : CarType
        {
            public override void Tyype()
            {
                Console.WriteLine("Простая машина");
            }
        }

        class FourDoorsCar : CarDoors
        {
            public override void Doors()
            {
                Console.WriteLine("У машины 4 двери");
            }
        }

        class TwoDoorsCar : CarDoors
        {
            public override void Doors()
            {
                Console.WriteLine("У машины 2 двери");
            }
        }

        abstract class CarFactory
        {
            public abstract CarType CreateTyype();
            public abstract CarDoors CreateDoors();
        }

        class SportCar : CarFactory
        {
            public override CarType CreateTyype()
            {
                return new Sport();
            }

            public override CarDoors CreateDoors()
            {
                return new TwoDoorsCar();
            }
        }
        class SimpleCar : CarFactory
        {
            public override CarType CreateTyype()
            {
                return new Simple();
            }

            public override CarDoors CreateDoors()
            {
                return new FourDoorsCar();
            }
        }

        class Cars
        {
            private CarDoors carDoors;
            private CarType carType;
            public Cars(CarFactory factory)
            {
                carDoors = factory.CreateDoors();
                carType = factory.CreateTyype();
            }
            public void Tyype()
            {
                carType.Tyype();
            }
            public void Doors()
            {
                carDoors.Doors();
            }

        }

        /// 
        /// 
        /// 
        class CompanyName
        {
            public Diller Diller { get; set; }
            public void Launch(string osName)
            {
                Diller = Diller.getInstance(osName);
            }
        }
        class Diller
        {
            private static Diller instance;

            public string Name { get; private set; }

            protected Diller(string name)
            {
                this.Name = name;
            }

            public static Diller getInstance(string name)
            {
                if (instance == null)
                    instance = new Diller(name);
                return instance;
            }
        }


        /// 
        /// 
        /// 
        class Seats
        {
            public string Newseats { get; set; }
        }
        class Wheels
        {
            public string Newwheels { get; set; }
        }
        class Doors
        {
            public string Newdoors { get; set; }
        }

        class CrushedCar
        {
            public Seats Seats { get; set; }
            public Doors Doors { get; set; }
            public Wheels Wheels { get; set; }

            public override string ToString()
            {
                StringBuilder sb = new StringBuilder();
                Console.WriteLine("В Машине произведены изменения: ");
                if (Seats != null)
                    sb.Append(Seats.Newseats + "\n");
                if (Doors != null)
                    sb.Append(Doors.Newdoors + "\n");
                if (Wheels != null)
                    sb.Append(Wheels.Newwheels + " \n");
                return sb.ToString();
            }
        }
        abstract class Mechanic
        {
            public CrushedCar CrushedCar { get; private set; }
            public void FixCar()
            {
                CrushedCar = new CrushedCar();
            }
            public abstract void FixWheels();
            public abstract void FixDoors();
            public abstract void FixSeats();
        }
        class Director
        {
            public CrushedCar Fix(Mechanic mechanic)
            {
                mechanic.FixCar();
                mechanic.FixWheels();
                mechanic.FixDoors();
                mechanic.FixSeats();
                return mechanic.CrushedCar;
            }
        }
        class InnerFixer : Mechanic
        {
            public override void FixSeats()
            {
                this.CrushedCar.Seats = new Seats { Newseats = "Новые сиденья" };
            }

            public override void FixWheels()
            {
                //
            }

            public override void FixDoors()
            {
                // не используется
            }
        }
        class OutterFixer : Mechanic
        {
            public override void FixSeats()
            {
                //
            }

            public override void FixWheels()
            {
                this.CrushedCar.Wheels = new Wheels { Newwheels = "Новые колеса" };
            }

            public override void FixDoors()
            {
                this.CrushedCar.Doors = new Doors { Newdoors = "Новые двери" };
            }
        }
        class FullFixer : Mechanic
        {
            public override void FixSeats()
            {
                this.CrushedCar.Seats = new Seats { Newseats = "Новые сиденья" };
            }

            public override void FixWheels()
            {
                this.CrushedCar.Wheels = new Wheels { Newwheels = "Новые колеса" };
            }

            public override void FixDoors()
            {
                this.CrushedCar.Doors = new Doors { Newdoors = "Новые двери" };
            }
        }

        ///
        ///
        ///

        interface ITank
        {
            ITank Clone();
            void GetInfo();
        }
        class TankTiger : ITank
        {
            string name;
            int calibr;
            public TankTiger(string n, int c)
            {
                name = n;
                calibr = c;
            }

            public ITank Clone()
            {
                return new TankTiger(this.name, this.calibr);
            }
            public void GetInfo()
            {
                Console.WriteLine("Танк {0} с калибром {1}", name, calibr);
            }
        }
        class TankIS : ITank
        {
            string name;
            int calibr;
            string emblem;
            public TankIS(string n, int c, string e)
            {
                name = n;
                calibr = c;
                emblem = e;
            }

            public ITank Clone()
            {
                return new TankIS(this.name, this.calibr, this.emblem);
            }
            public void GetInfo()
            {
                Console.WriteLine("Танк {0} с калибром {1} и эмблемой {2}", name, calibr, emblem);
            }
        }

    }
}
