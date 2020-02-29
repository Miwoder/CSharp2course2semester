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
            Controller controller = new Controller();
            Person person = new Person();
            controller.SetCommand(new RunOnCommand(person));
            controller.PressButton();
            controller.SetCommand(new JumpOnCommand(person));
            controller.PressButton();
            controller.SetCommand(new FireOnCommand(person));
            controller.PressButton();
            Console.WriteLine();

            CartridgeStore cartridgestore = new CartridgeStore(Ammunation.EMPTY);
            cartridgestore.Reload();
            cartridgestore.Reload();
            cartridgestore.Reload();
            Console.WriteLine();

            Hero hero = new Hero();
            hero.Shoot(); 
            GameHistory game = new GameHistory();
            game.History.Push(hero.SaveState()); 
            hero.Shoot();
            hero.Shoot();
            hero.RestoreState(game.History.Pop());
            hero.Shoot();
            hero.Shoot();
            hero.Shoot();


            Console.ReadKey();
        }

        interface ICommand
        {
            void Execute();
        }

        class Person
        {
            public void Jump()
            {
                Console.WriteLine("Персонаж прыгнул");
            }
            public void FireGun()
            {
                Console.WriteLine("Персонаж стреляет");
            }
            public void Run()
            {
                Console.WriteLine("Персонаж бежит");
            }
        }

        class FireOnCommand : ICommand
        {
            Person person;
            public FireOnCommand(Person personSet)
            {
                person = personSet;
            }

            public void Execute()
            {
                person.FireGun();
            }
        }

        class RunOnCommand : ICommand
        {
            Person person;
            public RunOnCommand(Person personSet)
            {
                person = personSet;
            }

            public void Execute()
            {
                person.Run();
            }
        }
        class JumpOnCommand : ICommand
        {
            Person person;
            public JumpOnCommand(Person personSet)
            {
                person = personSet;
            }

            public void Execute()
            {
                person.Jump();
            }
        }

        class Controller
        {
            ICommand command;

            public Controller() { }

            public void SetCommand(ICommand com)
            {
                command = com;
            }

            public void PressButton()
            {
                command.Execute();
            }

        }
        //////////////////
        //////////////////
        /////////////////


        enum Ammunation
        {
            FULL,
            EMPTY,
            NO
        }
        class CartridgeStore
        {
            public Ammunation State { get; set; }

            public CartridgeStore(Ammunation ws)
            {
                State = ws;
            }

            public void Reload()
            {
                if (State == Ammunation.EMPTY)
                {
                    Console.WriteLine("Перезаряжаем магазин");
                    State = Ammunation.FULL;
                }
                else if (State == Ammunation.FULL)
                {
                    Console.WriteLine("Стреляем");
                    State = Ammunation.NO;
                }
                else if (State == Ammunation.NO)
                {
                    Console.WriteLine("Идем на склад за патронами");
                }
            }
           
        }
        ////////////////////////
        //////////////////////
        ///////////////////

        class Hero
        {
            private int targets = 10; 

            public void Shoot()
            {
                if (targets > 0)
                {
                    targets--;
                    Console.WriteLine("Попадание... Осталось целей: " + targets);
                }
                else
                    Console.WriteLine("Целей больше нет");
            }
            public HeroMemento SaveState()
            {
                Console.WriteLine("Сохранение игры. Осталось целей: " + targets );
                return new HeroMemento(targets);
            }

            public void RestoreState(HeroMemento memento)
            {
                this.targets = memento.Targets;
                Console.WriteLine("Восстановление игры. Целей осталось: "+ targets);
            }
        }
        class HeroMemento
        {
            public int Targets { get; private set; }

            public HeroMemento(int targets)
            {
                this.Targets = targets;
            }
        }

        class GameHistory
        {
            public Stack<HeroMemento> History { get; private set; }
            public GameHistory()
            {
                History = new Stack<HeroMemento>();
            }
        }




    }
}
