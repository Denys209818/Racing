using System;
using System.Collections.Generic;
using System.Text;

namespace Racing
{
    abstract class Car
    {
        public int speed;
        public int accelerationPlus;
        public int accelerationMinus;
        public int maxSpeed;
        public int minSpeed;
        public int lengthSize;
        public bool isFinished;
        public bool isBreakDown;
        public Car(int speed, int accelerationPlus, int accelerationMinus, int maxSpeed, int minSpeed)
        {
            this.speed = speed;
            this.minSpeed = minSpeed;
            this.maxSpeed = maxSpeed;
            this.accelerationMinus = accelerationMinus;
            this.accelerationPlus = accelerationPlus;
            this.isBreakDown = false;
        }

        public void Start(int length)
        { 
            this.lengthSize = length;
            speed += accelerationPlus;
        }

        public void InRoad() 
        {
            if (speed <= 0)
            {
                this.ToDieDown();
                return;
            } 
            else if (speed > maxSpeed || isBreakDown) 
            {
                isBreakDown = true;
                this.BreakDown();
                return;
            }


            if (this.lengthSize - speed > 0)
            {
                string title = "";
                switch (this.maxSpeed) 
                {
                    case 200: 
                        {
                            title = "Sport Car";
                            break;
                        }
                    case 150:
                        {
                            title = "Light Car";
                            break;
                        }
                    case 100:
                        {
                            title = "Big Car";
                            break;
                        }
                    case 120:
                        {
                            title = "Bus Car";
                            break;
                        }
                }
                Console.WriteLine(title + ": " +this.lengthSize);
                this.lengthSize -= speed;
            }
            else 
            {
                this.Finish();
            }
            
        }

        public void PlusSpeed() 
        {
            this.speed += this.accelerationPlus;
            if (this.speed > maxSpeed) 
            {
                this.BreakDown();
            }
        }

        public void MinusSpeed() 
        {
            if (this.speed-accelerationMinus > 0)
            {
                this.speed -= accelerationMinus;
            }
            else 
            {
                this.speed = 0;
                this.ToDieDown();
            }
        }

        public void BreakDown() 
        {
            Console.WriteLine("break down");
        }

        public void ToDieDown() 
        {
            Console.WriteLine("To die down");
        }

        public void Finish() 
        {
            this.isFinished = true;
            Console.WriteLine("Finish!");
        }
    }

    class SportCar : Car
    {
        public SportCar() : base(0, 10, 3, 200, 0)
        {

        }
   
    }

    class LightCar : Car
    {
        public LightCar() : base(0, 5, 2, 150, 0)
        {

        }
    }

    class BigCar : Car 
    {
        public BigCar() : base(0, 2, 1, 100, 0)
        {

        }
    }

    class BusCar : Car
    {
        public BusCar() : base(0, 3, 2, 120, 0)
        {

        }
    }
}
