using System;
using System.Collections.Generic;
using System.Text;
using Raylib;
using rl = Raylib.Raylib;

namespace Ranching
{
    /// <summary>
    /// Makes a new cow or loads a saved one
    /// </summary>
    class Cow : Animal
    {
        Random random = new Random();
        public static Texture2D cowTexture;
        /// <summary>
        /// Make random stats for new cow
        /// </summary>
        public Cow()
        {
            age = random.Next(5);
            speed = random.Next(1, 3);
            yield = random.Next(1, 2);
            saturation = random.Next(10, 100);
            fatness = random.Next(3, 15);
            moveTime = random.Next(25, 50);
            texture = cowTexture;
            saturation *= 120;
            makingMoneyTemp = 1;
            name = "Cow";
            textureName = "cow.png";
        }
        /// <summary>
        /// Loads Cow with deturmed stats
        /// </summary>
        /// <param name="_age"></param>
        /// <param name="_speed"></param>
        /// <param name="_yield"></param>
        /// <param name="_saturation"></param>
        /// <param name="_fatness"></param>
        /// <param name="_moveTime"></param>
        /// <param name="_X"></param>
        /// <param name="_Y"></param>
        /// <param name="_makingMoney"></param>
        public Cow(int _age, int _speed, int _yield,int _saturation, int _fatness, int _moveTime, float _X, float _Y, float _makingMoney)
        {
            age = _age;
            speed = _speed;
            yield = _yield;
            saturation = _saturation;
            fatness = _fatness;
            moveTime = _moveTime;
            texture = cowTexture;
            Position.x = _X;
            Position.y = _Y;
            makingMoneyTemp = _makingMoney;
            name = "Cow";
            textureName = "cow.png";
        }

    }
    class Chicken : Animal
    {
        Random random = new Random();
        public static Texture2D chickenTexture;
        /// <summary>
        /// Makes a new Chicken with random stats
        /// </summary>
        public Chicken()
        {
            age = random.Next(3);
            speed = random.Next(1, 3);
            yield = random.Next(1, 5);
            saturation = random.Next(10, 100);
            fatness = random.Next(1, 5);
            moveTime = random.Next(25, 50);
            texture = chickenTexture;
            saturation *= 120;
            makingMoneyTemp = 10;
            name = "Chicken";
            textureName = "chicken.png";
        }
        /// <summary>
        /// Loads a chicken with deturmed stats
        /// </summary>
        /// <param name="_age"></param>
        /// <param name="_speed"></param>
        /// <param name="_yield"></param>
        /// <param name="_saturation"></param>
        /// <param name="_fatness"></param>
        /// <param name="_moveTime"></param>
        /// <param name="_X"></param>
        /// <param name="_Y"></param>
        /// <param name="_makingMoney"></param>
        public Chicken(int _age, int _speed, int _yield, int _saturation, int _fatness, int _moveTime, float _X, float _Y, float _makingMoney)
        {
            age = _age;
            speed = _speed;
            yield = _yield;
            saturation = _saturation;
            fatness = _fatness;
            moveTime = _moveTime;
            texture = chickenTexture;
            Position.x = _X;
            Position.y = _Y;
            makingMoneyTemp = _makingMoney;
            name = "Chicken";
            textureName = "chicken.png";
        }
    }
    class Horse : Animal
    {
        Random random = new Random();
        public static Texture2D horseTexture;
        /// <summary>
        /// makes a new horse with random stats
        /// </summary>
        public Horse()
        {
            age = random.Next(15);
            speed = random.Next(2, 4);
            yield = random.Next(1, 3);
            saturation = random.Next(10, 100);
            fatness = random.Next(3, 15);
            moveTime = random.Next(25, 50);
            texture = horseTexture;
            saturation *= 120;
            makingMoneyTemp = 50;
            name = "Horse";
            textureName = "horse.png";
        }
        /// <summary>
        /// Loads a horse deturmed stats
        /// </summary>
        /// <param name="_age"></param>
        /// <param name="_speed"></param>
        /// <param name="_yield"></param>
        /// <param name="_saturation"></param>
        /// <param name="_fatness"></param>
        /// <param name="_moveTime"></param>
        /// <param name="_X"></param>
        /// <param name="_Y"></param>
        /// <param name="_makingMoney"></param>
        public Horse(int _age, int _speed, int _yield, int _saturation, int _fatness, int _moveTime, float _X, float _Y, float _makingMoney)
        {
            age = _age;
            speed = _speed;
            yield = _yield;
            saturation = _saturation;
            fatness = _fatness;
            moveTime = _moveTime;
            texture = horseTexture;
            Position.x = _X;
            Position.y = _Y;
            makingMoneyTemp = _makingMoney;
            name = "Horse";
            textureName = "horse.png";
        }
    }
    class Pig : Animal
    {
        Random random = new Random();
        public static Texture2D pigTexture;
        /// <summary>
        /// Makes a new pig with random stats
        /// </summary>
        public Pig()
        {
            age = random.Next(5);
            speed = random.Next(1, 3);
            yield = random.Next(5, 10);
            saturation = random.Next(10, 100);
            fatness = random.Next(3, 10);
            moveTime = random.Next(25, 50);
            texture = pigTexture;
            saturation *= 120;
            makingMoneyTemp = 100;
            name = "Pig";
            textureName = "pig.png";
        }
        /// <summary>
        /// Loads a pig with deturmed stats
        /// </summary>
        /// <param name="_age"></param>
        /// <param name="_speed"></param>
        /// <param name="_yield"></param>
        /// <param name="_saturation"></param>
        /// <param name="_fatness"></param>
        /// <param name="_moveTime"></param>
        /// <param name="_X"></param>
        /// <param name="_Y"></param>
        /// <param name="_makingMoney"></param>
        public Pig(int _age, int _speed, int _yield, int _saturation, int _fatness, int _moveTime, float _X, float _Y, float _makingMoney)
        {
            age = _age;
            speed = _speed;
            yield = _yield;
            saturation = _saturation;
            fatness = _fatness;
            moveTime = _moveTime;
            texture = pigTexture;
            Position.x = _X;
            Position.y = _Y;
            makingMoneyTemp = _makingMoney;
            name = "Pig";
            textureName = "pig.png";
        }
    }
}

