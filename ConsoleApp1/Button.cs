﻿using System;
using System.Collections.Generic;
using System.Text;
using Raylib;
using rl = Raylib.Raylib;

namespace Ranching
{
    class Button
    {
        int buttonState = 0;
        public bool buttonAction = false;
        public Vector2 mousePoint = new Vector2();
        public Vector2 Position = new Vector2();
        public int height = 0;
        public int width = 0;
        public Rectangle btnBounds;
        public Color myColor = Color.BEIGE;
        public void Update()
        {
            mousePoint = rl.GetMousePosition();
            buttonAction = false;  // Button state: 0-NORMAL, 1-MOUSE_HOVER, 2-PRESSED

            // Check button state
            if (rl.CheckCollisionPointRec(mousePoint, btnBounds))
            {
                if (rl.IsMouseButtonDown(MouseButton.MOUSE_LEFT_BUTTON))
                {
                    buttonState = 2;
                    
                }
                else buttonState = 1;

                if (rl.IsMouseButtonReleased(MouseButton.MOUSE_LEFT_BUTTON))
                {
                    buttonAction = true;
                }
            }
            else buttonState = 0;

            if(buttonState == 0)
            {
                myColor = Color.BLUE;
            }
            if (buttonState == 1)
            {
                myColor = Color.ORANGE;
            }
            if (buttonState == 2)
            {
                myColor = Color.RED;
            }
            
            //if (buttonAction)
            //{


            //    // TODO: Any desired action
            //}
        }
        public void Draw()
        {


            rl.DrawRectangle((int)Position.x, (int)Position.y, width, height, myColor);
        }
    }
}