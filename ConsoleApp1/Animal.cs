﻿using System;
using System.Collections.Generic;
using System.Text;
using Raylib;
using rl = Raylib.Raylib;

namespace Ranching
{
    
    public class Animal
    {
        public Vector2 Position = new Vector2();
        public int age; // if it gets to old it will die
        public int speed; //How "fast" it can go
        public int yield; // How much it will give
        public int fatness; // how fat it is
        public int saturation; // How full it is
        public bool male; // is it a male
        public string name = "NotListed";
        public Texture2D texture;
        Random random = new Random();
        int tempX;
        int tempY;
        public int moveTime = 10;
        bool start = true;
        int screenWidth = 800;
        int screenHeight = 450;

        public void NewRand()
        {
            tempX = random.Next(3);
            tempY = random.Next(3);
        }
        public void RunUpdate()
        {
            if(start)
            {
                NewRand();
                start = false;
            }
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
            if (moveTime > 0)
            {
                if (tempY == 2)
                {
                    Position.y--;
                }
                if (tempY == 1)
                {
                    Position.y++;
                }
                if (tempX == 2)
                {
                    Position.x--;
                }
                if (tempX == 1)
                {
                    Position.x++;
                }
            }
            else
            {
                NewRand();
                moveTime = random.Next(25, 50);
            }
            moveTime--;
        }
        public void Food()
        {
            saturation--;
        }
        public int Food(int food)
        {
            saturation += food;
            return saturation;
        }
        public void Draw()
        {
            rl.DrawTextureEx(texture, Position, 0f, 0.3f, Color.WHITE);
        }
    }
}