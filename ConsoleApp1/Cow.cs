using System;
using System.Collections.Generic;
using System.Text;
using Raylib;
using rl = Raylib.Raylib;

namespace Ranching
{
    class Cow : Animal
    {
        Random random = new Random();
        static Texture2D cowTexture = rl.LoadTexture("cow.png");
        public Cow()
        {
            age = random.Next(5);
            speed = random.Next(3, 6);
            yield = random.Next(1, 10);
            saturation = random.Next(10, 100);
            fatness = random.Next(3, 15);
            moveTime = random.Next(25, 50);
            texture = cowTexture;
            saturation *= 120;
            makingMoneyTemp = 10;
        }
        
    }
    class Chicken : Animal
    {
        Random random = new Random();
        static Texture2D chickenTexture = rl.LoadTexture("chicken.png");
        public Chicken()
        {
            age = random.Next(3);
            speed = random.Next(1, 3);
            yield = random.Next(1, 10);
            saturation = random.Next(10, 100);
            fatness = random.Next(1, 5);
            moveTime = random.Next(25, 50);
            texture = chickenTexture;
            saturation *= 120;
            makingMoneyTemp = 20;
        }

    }
    class Horse : Animal
    {
        Random random = new Random();
        static Texture2D horseTexture = rl.LoadTexture("horse.png");
        public Horse()
        {
            age = random.Next(15);
            speed = random.Next(3, 12);
            yield = random.Next(1, 3);
            saturation = random.Next(10, 100);
            fatness = random.Next(3, 15);
            moveTime = random.Next(25, 50);
            texture = horseTexture;
            saturation *= 120;
            makingMoneyTemp = 30;
        }

    }
    class Pig : Animal
    {
        Random random = new Random();
        static Texture2D pigTexture = rl.LoadTexture("pig.png");
        public Pig()
        {
            age = random.Next(5);
            speed = random.Next(3, 5);
            yield = random.Next(1, 10);
            saturation = random.Next(10, 100);
            fatness = random.Next(3, 10);
            moveTime = random.Next(25, 50);
            texture = pigTexture;
            saturation *= 120;
            makingMoneyTemp = 40;
        }

    }
}
