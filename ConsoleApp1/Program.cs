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
            
            int howManyCow = 0;
            int howManyChicken = 0;
            int howManyHorse = 0;
            int howManyPig = 0;
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
            //feed button
            Button foodButton = new Button();
            foodButton.Position.x = 100;
            foodButton.Position.y = 400;
            foodButton.height = 50;
            foodButton.width = 100;
            foodButton.btnBounds = new Rectangle(foodButton.Position.x, foodButton.Position.y, foodButton.width, foodButton.height);

            

            rl.InitWindow(screenWidth, screenHeight, "raylib [core] example - basic window");

            rl.SetTargetFPS(60);
            //--------------------------------------------------------------------------------------

            // Main game loop
            while (!rl.WindowShouldClose())    // Detect window close button or ESC key
            {
                // Update
                //----------------------------------------------------------------------------------


                // TODO: Update your variables here
                //----------------------------------------------------------------------------------
                cowButton.Update();
                if (cowButton.buttonAction && player.money >= 50)
                {
                    farmAnimals.Add(new Cow());
                    player.money -= 50;
                }
                //horse
                horseButton.Update();
                
                foreach (var i in farmAnimals)
                {
                    i.RunUpdate();
                    i.Food();
                    i.Produce();
                    player.money += (i.makingMoney / 1200);

                    i.Draw();
                }
                if (horseButton.buttonAction && player.money >= 50)
                {
                    farmAnimals.Add(new Horse());
                    player.money -= 50;
                }
                //chicken
                chickenButton.Update();
                if (chickenButton.buttonAction && player.money >= 50)
                {
                    farmAnimals.Add(new Chicken());
                    player.money -= 50;
                }
                //pig
                pigButton.Update();
                if (pigButton.buttonAction && player.money >= 50)
                {
                    farmAnimals.Add(new Pig());
                    player.money -= 50;
                }
                foodButton.Update();
                if (foodButton.buttonAction && player.money >= 10)
                {
                    foreach (var i in farmAnimals)
                    {
                        i.Food(50);
                    }
                    player.money -= 10;
                }

                // Sort
                //----------------------------------------------------------------------------------
                //Cow
                if(rl.IsKeyDown(KeyboardKey.KEY_C))
                {
                    howManyCow = 0;
                    foreach(Cow cow in farmAnimals)
                    {
                        howManyCow++;
                    }
                    rl.DrawText($"You have {howManyCow} Cows in the pin", 10, 300, 30, Color.BLACK);
                }
                //Chicken
                if (rl.IsKeyDown(KeyboardKey.KEY_K))
                {
                    howManyChicken = 0;
                    foreach (Chicken chicken in farmAnimals)
                    {
                        howManyChicken++;
                    }
                    rl.DrawText($"You have {howManyChicken} Chickens in the pin", 10, 300, 30, Color.BLACK);
                }
                //Horse
                if (rl.IsKeyDown(KeyboardKey.KEY_H))
                {
                    howManyHorse = 0;
                    foreach (Horse horse in farmAnimals)
                    {
                        howManyHorse++;
                    }
                    rl.DrawText($"You have {howManyHorse} Horses in the pin", 10, 300, 30, Color.BLACK);
                }
                //Pig
                if (rl.IsKeyDown(KeyboardKey.KEY_P))
                {
                    howManyPig = 0;
                    foreach (Pig pig in farmAnimals)
                    {
                        howManyPig++;
                    }
                    rl.DrawText($"You have {howManyPig} Pigs in the pin", 10, 300, 30, Color.BLACK);
                }
                //----------------------------------------------------------------------------------
                // Draw
                //----------------------------------------------------------------------------------
                rl.BeginDrawing();

                rl.ClearBackground(Color.GREEN);

                cowButton.Draw();
                ////horse
                horseButton.Draw();
                ////chicken
                chickenButton.Draw();
                ////Pig
                pigButton.Draw();

                foodButton.Draw();

                rl.DrawText($"You have ${player.money}", 10, 10, 30, Color.BLACK);

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
