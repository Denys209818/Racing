using System;

namespace Racing
{
    class Program
    {
        //  Можливі проблеми з перекладом
        //  To Die Down - машина заглохла
        //  Break Down - машина зломалася
        static void Main()
        {
            RacingCar racing = new RacingCar();

            racing.StartRacing(100000);
        }
    }
}
