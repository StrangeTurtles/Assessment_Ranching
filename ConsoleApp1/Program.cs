using System;
using System.Collections.Generic;
using Raylib;
using rl = Raylib.Raylib;

namespace Ranching
{
    static class Program
    {
        public static int Main()
        {
            // Initialization
            //--------------------------------------------------------------------------------------
            int screenWidth = 800;
            int screenHeight = 450;
            Player player = new Player();
            player.money = 500;
            List<Animal> farmAnimals = new List<Animal>();
            //Cow's button
            Button cowButton = new Button();
            cowButton.Position.x = 600;
            cowButton.Position.y = 100;
            cowButton.height = 50;
            cowButton.width = 100;
            cowButton.btnBounds = new Rectangle(cowButton.Position.x, cowButton.Position.y, cowButton.width, cowButton.height);
            //chicken's button
            Button chickenButton = new Button();
            chickenButton.Position.x = 600;
            chickenButton.Position.y = 200;
            chickenButton.height = 50;
            chickenButton.width = 100;
            chickenButton.btnBounds = new Rectangle(chickenButton.Position.x, chickenButton.Position.y, chickenButton.width, chickenButton.height);
            //horse's button
            Button horseButton = new Button();
            horseButton.Position.x = 600;
            horseButton.Position.y = 300;
            horseButton.height = 50;
            horseButton.width = 100;
            horseButton.btnBounds = new Rectangle(horseButton.Position.x, horseButton.Position.y, horseButton.width, horseButton.height);
            //pig's button
            Button pigButton = new Button();
            pigButton.Position.x = 600;
            pigButton.Position.y = 400;
            pigButton.height = 50;
            pigButton.width = 100;
            pigButton.btnBounds = new Rectangle(pigButton.Position.x, pigButton.Position.y, pigButton.width, pigButton.height);
            rl.InitWindow(screenWidth, screenHeight, "raylib [core] example - basic window");

            rl.SetTargetFPS(60);
            //--------------------------------------------------------------------------------------

            // Main game loop
            while (!rl.WindowShouldClose())    // Detect window close button or ESC key
            {
                // Update
                //----------------------------------------------------------------------------------
                //foreach (Cow cow in farmAnimals)
                //{
                //    cow.texture = rl.LoadTexture("cow.png");
                //}

                // TODO: Update your variables here
                //----------------------------------------------------------------------------------
                cowButton.Update();
                //foreach (Cow cow in farmAnimals)
                //{
                //    cow.RunUpdate();
                //}
                if (cowButton.buttonAction)
                {
                    farmAnimals.Add(new Cow());
                }
                //horse
                horseButton.Update();
                
                foreach (var i in farmAnimals)
                {
                    i.RunUpdate();
                    i.Draw();
                }
                if (horseButton.buttonAction)
                {
                    farmAnimals.Add(new Horse());
                }
                //chicken
                chickenButton.Update();
                //foreach (Chicken chicken in farmAnimals)
                //{
                //    chicken.RunUpdate();
                //}
                if (chickenButton.buttonAction)
                {
                    farmAnimals.Add(new Chicken());
                }
                //pig
                pigButton.Update();
                //foreach (Pig pig in farmAnimals)
                //{
                //    pig.RunUpdate();
                //}
                if (pigButton.buttonAction)
                {
                    farmAnimals.Add(new Pig());
                }
                // Draw
                //----------------------------------------------------------------------------------
                rl.BeginDrawing();

                rl.ClearBackground(Color.RAYWHITE);

                cowButton.Draw();
                //foreach(Cow cow in farmAnimals)
                //{
                //    cow.Draw();
                //}
                ////horse
                horseButton.Draw();
                //foreach (Horse horse in farmAnimals)
                //{
                //    horse.Draw();
                //}
                ////chicken
                chickenButton.Draw();
                //foreach (Chicken chicken in farmAnimals)
                //{
                //    chicken.Draw();
                //}
                ////Pig
                pigButton.Draw();
                //foreach (Pig pig in farmAnimals)
                //{
                //    pig.Draw();
                //}
                //rl.DrawText("Congrats! You created your first window!", 190, 200, 20, Color.LIGHTGRAY);

                rl.EndDrawing();
                //----------------------------------------------------------------------------------
            }

            // De-Initialization
            //--------------------------------------------------------------------------------------
            rl.CloseWindow();        // Close window and OpenGL context
                                     //--------------------------------------------------------------------------------------

            return 0;
        }
    }
}
