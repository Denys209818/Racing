using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace Racing
{
    public delegate void Start(int length);
    public delegate void PlusSpeed();
    public delegate void MinusSpeed();
    public delegate void AutoEvents();

    class RacingCar
    {
        public List<Car> cars;
        Start start;
        PlusSpeed plusSpeed;
        MinusSpeed minusSpeed;
        AutoEvents events;
        public RacingCar()
        {
            this.cars = new List<Car> ();
            Random r = new Random();
            for (int i = 0; i < 5; i++) 
            {
                Car c;
                switch (r.Next(1, 4)) 
                {
                    case 1: { c = new SportCar(); break; }
                    case 2: { c = new LightCar();  break; }
                    case 3: { c = new BigCar(); break; }
                    case 4: { c = new BusCar(); break; }
                    default: { c = new LightCar(); break; }
                }
                this.cars.Add(c);
                if (i == 0)
                {
                    start = new Start(c.Start);
                    plusSpeed = new PlusSpeed(c.PlusSpeed);
                    minusSpeed = new MinusSpeed(c.MinusSpeed);
                    events = new AutoEvents(c.InRoad);
                }
                else 
                {
                    start += c.Start;
                    plusSpeed += c.PlusSpeed;
                    minusSpeed += c.MinusSpeed;
                    events += c.InRoad;
                }

                

            }
        }


        public void StartRacing(int length) 
        {
            this.start(length);
            ConsoleKeyInfo key;
            while (true) 
            {
                do
                {
                    Console.Clear();
                    Console.WriteLine("Залишилось кожному проїхати: ");

                    events();

                    int k = 0;
                    foreach (var item in this.cars) 
                    {
                        if (item.isFinished) 
                        {
                            k++;
                        }
                    }
                    if (k == 5) 
                    {
                        return;
                    }
                    
                    Thread.Sleep(200);
                }
                while (!Console.KeyAvailable);

                switch (Console.ReadKey().Key)
                {
                    case ConsoleKey.UpArrow: 
                        {
                            this.plusSpeed();
                            break;
                        }

                    case ConsoleKey.DownArrow:
                        {
                            this.minusSpeed();
                            break;
                        }

                } 
            }
        }

    }
}
