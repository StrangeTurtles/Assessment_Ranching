using System;
using System.Collections.Generic;
using System.Text;
using Raylib;
using rl = Raylib.Raylib;

namespace Ranching
{
    
    public class Animal
    {
        public Vector2 mousePoint = new Vector2();
        public Vector2 Position = new Vector2();
        public int age; // if it gets to old it will die
        public int speed; //How "fast" it can go
        public int yield; // How much it will give
        public int fatness; // how fat it is
        public int saturation; // How full it is
        public bool male; // is it a male
        public bool hungry = false; // if it is hungry
        public string name = "NotListed";
        public float makingMoney;
        public float makingMoneyTemp;
        public Texture2D texture;
        public string textureName;
        public bool buttonAction = false;
        //public  btnBounds;
        Random random = new Random();
        int tempX;
        int tempY;
        public int moveTime = 10;
        bool start = true;
        int screenWidth = 800;
        int screenHeight = 450;
        int buttonState = 0;

        
        /// <summary>
        /// Makes a random int that will be used to deturmen where the animal will move
        /// </summary>
        public void NewRand()
        {
            tempX = random.Next(3);
            tempY = random.Next(3);
        }
        public void RunUpdate()
        {
            mousePoint = rl.GetMousePosition();
            //buttonAction = false;
            // gives a random deriton to start
            if (start)
            {
                NewRand();
                start = false;
            }
            if (rl.CheckCollisionCircles(mousePoint,1f, new Vector2(Position.x + 20,Position.y + 20), 10f))
            {
                if (rl.IsMouseButtonDown(MouseButton.MOUSE_LEFT_BUTTON))
                {
                    buttonState = 2;
                    buttonAction = true;
                }
                else buttonState = 1;

                if (rl.IsMouseButtonReleased(MouseButton.MOUSE_LEFT_BUTTON))
                {
                    buttonAction = false;
                }
            }
            else buttonState = 0;
            //Screen Wrap
            if (Position.x > screenWidth)
            {
                Position.x = -30;
            }
            if (Position.x < -30)
            {
                Position.x = screenWidth;
            }
            if (Position.y > screenHeight)
            {
                Position.y = -30;
            }
            if (Position.y < -30)
            {
                Position.y = screenHeight;
            }
            //if the time is not up, and
            //the animal is not hungry
            //then the animal can move 
            if (moveTime > 0 && saturation > 0)
            {
                
                if (tempY == 2)
                {
                    //up
                    Position.y -= speed;
                }
                if (tempY == 1)
                {
                    //down
                    Position.y += speed;
                }
                if (tempX == 2)
                {
                    //left
                    Position.x -= speed;
                }
                if (tempX == 1)
                {
                    //right
                    Position.x += speed;
                }

            }
            //if not then change drection and give a new time
            else
            {
                NewRand();
                moveTime = random.Next(25, 50);
            }
            moveTime--;
            if(buttonAction)
            {
                Position = new Vector2(mousePoint.x-20,mousePoint.y-20);
            }
        }
        /// <summary>
        /// if food is not given then remove saturation
        /// </summary>
        public void Food()
        {
            saturation--;
        }
        /// <summary>
        /// if it is feed then give saturation
        /// </summary>
        /// <param name="food"></param>
        /// <returns></returns>
        public int Food(int food)
        {
            food *= 120;
            saturation += food;
            fatness++;
            return saturation;
        }
        /// <summary>
        /// gives money if the animal is not hungry
        /// </summary>
        public void Produce()
        {
            if(saturation > 0)
            {
                makingMoney = makingMoneyTemp * yield;
            }
            //stops making money and becomes hungry
            else
            {
                makingMoney = 0;
                saturation = 0;
                rl.DrawText("An Animal is hungry", 10, 350, 30, Color.BLACK);
                hungry = true;
            }
        }
        /// <summary>
        /// Draws the animal
        /// </summary>
        public void Draw()
        {
            rl.DrawTextureEx(texture, Position, 0f, 0.3f, Color.WHITE);
            //rl.DrawCircle((int) Position.x + 20, (int) Position.y + 20, 5f, Color.RED);
        }
    }
}
