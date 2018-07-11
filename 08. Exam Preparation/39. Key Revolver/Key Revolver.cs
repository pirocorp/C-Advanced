namespace _39._Key_Revolver
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class KeyRevolver
    {
        public static void Main()
        {
            //Read Input
            var priceOfBullet = int.Parse(Console.ReadLine());
            var sizeOfGunBarrel = int.Parse(Console.ReadLine());

            var bullets = new Queue<int>(Console.ReadLine()
                .Split(new[] {" "}, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .Reverse()
                .ToArray());

            var initialNumberOfBullets = bullets.Count;

            var locks = new Queue<int>(Console.ReadLine()
                .Split(new[] { " " }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray());

            var valueOfInteligence = int.Parse(Console.ReadLine());

            //Proccessing Data
            var currentBarrel = sizeOfGunBarrel;

            while (bullets.Count > 0 && locks.Count > 0)
            {
                var currentBullet = bullets.Dequeue();
                var currentLock = locks.Peek();

                if (currentBullet <= currentLock)
                {
                    Console.WriteLine($"Bang!");
                    currentLock = locks.Dequeue();
                }
                else
                {
                    Console.WriteLine($"Ping!");
                }

                currentBarrel--;

                if (currentBarrel <= 0 && bullets.Count > 0)
                {
                    Console.WriteLine($"Reloading!");
                    currentBarrel = sizeOfGunBarrel;
                }
            }

            //Printing Output
            if (locks.Count <= 0)
            {
                var bulletsShot = initialNumberOfBullets - bullets.Count;
                var bulletsCost = bulletsShot * priceOfBullet;
                Console.WriteLine($"{bullets.Count} bullets left. Earned ${valueOfInteligence - bulletsCost}");
            }
            else if (bullets.Count <= 0)
            {
                Console.WriteLine($"Couldn't get through. Locks left: {locks.Count}");
            }
        }
    }
}
