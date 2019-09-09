using System;
using System.Collections.Generic;
using System.IO;
using Raylib;
using rl = Raylib.Raylib;

namespace Ranching
{
    static class Program
    {
        static List<Animal> LoadAnimals()
        {
            List<Animal> animals = new List<Animal>();
            List<string> fileLines = new List<string>();

            using (StreamReader sr = new StreamReader("Animals.csv"))
            {
                sr.ReadLine();//skips the first line
                while (!sr.EndOfStream)
                {
                    //Adds all the lines to fileLines
                    fileLines.Add(sr.ReadLine());
                }
            }

            string[] tmpValues;

            foreach (string line in fileLines)
            {
                //Cow tmpCow = new Cow();
                //Chicken tmpChicken = new Chicken();
                //Horse tmpHorse = new Horse();
                //Pig tmpPig = new Pig();
                
                tmpValues = line.Split(',');

                int int1;
                int int2;
                int int3;
                int int4;
                int int5;
                int int6;
                float float1;
                float float2;
                float float3;

                if (tmpValues[0] == "Cow")
                {
                    int.TryParse(tmpValues[2], out int1);
                    int.TryParse(tmpValues[2], out int2);
                    int.TryParse(tmpValues[3], out int3);
                    int.TryParse(tmpValues[4], out int4);
                    int.TryParse(tmpValues[5], out int5);
                    int.TryParse(tmpValues[6], out int6);
                    float.TryParse(tmpValues[8], out float1);
                    float.TryParse(tmpValues[9], out float2);
                    float.TryParse(tmpValues[10], out float3);
                    animals.Add(new Cow(int1, int2, int3, int4, int5, int6, float1, float2, float3));
                }
                if (tmpValues[0] == "Chicken")
                {
                    int.TryParse(tmpValues[2], out int1);
                    int.TryParse(tmpValues[2], out int2);
                    int.TryParse(tmpValues[3], out int3);
                    int.TryParse(tmpValues[4], out int4);
                    int.TryParse(tmpValues[5], out int5);
                    int.TryParse(tmpValues[6], out int6);
                    float.TryParse(tmpValues[8], out float1);
                    float.TryParse(tmpValues[9], out float2);
                    float.TryParse(tmpValues[10], out float3);
                    animals.Add(new Chicken(int1, int2, int3, int4, int5, int6, float1, float2, float3));
                }
                if (tmpValues[0] == "Horse")
                {
                    int.TryParse(tmpValues[2], out int1);
                    int.TryParse(tmpValues[2], out int2);
                    int.TryParse(tmpValues[3], out int3);
                    int.TryParse(tmpValues[4], out int4);
                    int.TryParse(tmpValues[5], out int5);
                    int.TryParse(tmpValues[6], out int6);
                    float.TryParse(tmpValues[8], out float1);
                    float.TryParse(tmpValues[9], out float2);
                    float.TryParse(tmpValues[10], out float3);
                    animals.Add(new Horse(int1, int2, int3, int4, int5, int6, float1, float2, float3));
                }
                if (tmpValues[0] == "Pig")
                {
                    int.TryParse(tmpValues[2], out int1);
                    int.TryParse(tmpValues[2], out int2);
                    int.TryParse(tmpValues[3], out int3);
                    int.TryParse(tmpValues[4], out int4);
                    int.TryParse(tmpValues[5], out int5);
                    int.TryParse(tmpValues[6], out int6);
                    float.TryParse(tmpValues[8], out float1);
                    float.TryParse(tmpValues[9], out float2);
                    float.TryParse(tmpValues[10], out float3);
                    animals.Add(new Pig(int1, int2, int3, int4, int5, int6, float1, float2, float3));
                }


            }
            return animals;
        }

        static void SaveData(List<Animal> animals)
        {
            StreamWriter writer = new StreamWriter("Animals.csv");

            writer.WriteLine("Animal,age,speed,yield,saturation,fatness,moveTime,texture,positionX,positionY,makingMoneyTemp");

            foreach(var i in animals)
            {
                writer.WriteLine($"{i.name}," +
                    $"{i.age}," +
                    $"{i.speed}," +
                    $"{i.yield}," +
                    $"{i.saturation}," +
                    $"{i.fatness}," +
                    $"{i.moveTime}," +
                    $"{i.textureName}," +
                    $"{i.Position.x}," +
                    $"{i.Position.y}," +
                    $"{i.makingMoneyTemp}");
            }

            writer.Close();
        }

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

            //LoadAnimals();
            //farmAnimals = LoadAnimals();

            StreamReader reader = new StreamReader("SaveData.txt");
            while (!reader.EndOfStream)
            {
                string data = reader.ReadLine();
                float number = 0;

                float.TryParse(data, out number);
                player.money = number;
            }
            reader.Close();

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

            //LoadAnimals();
            //farmAnimals = LoadAnimals();

            Cow.cowTexture = rl.LoadTexture("cow.png");
            Chicken.chickenTexture = rl.LoadTexture("chicken.png");
            Horse.horseTexture = rl.LoadTexture("horse.png");
            Pig.pigTexture = rl.LoadTexture("pig.png");

            LoadAnimals();
            farmAnimals = LoadAnimals();
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
                    player.money -= 60;
                }
                //chicken
                chickenButton.Update();
                if (chickenButton.buttonAction && player.money >= 50)
                {
                    farmAnimals.Add(new Chicken());
                    player.money -= 70;
                }
                //pig
                pigButton.Update();
                if (pigButton.buttonAction && player.money >= 50)
                {
                    farmAnimals.Add(new Pig());
                    player.money -= 80;
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
                    foreach(var i in farmAnimals)
                    {
                        if (i.name == "Cow")
                        {
                            howManyCow++;
                            //Console.WriteLine("hi");
                        }
                    }
                    rl.DrawText($"You have {howManyCow} Cows in the pen", 10, 300, 30, Color.BLACK);
                }
                //Chicken
                if (rl.IsKeyDown(KeyboardKey.KEY_K))
                {
                    howManyChicken = 0;
                    foreach (var i in farmAnimals)
                    {
                        if (i.name == "Chicken")
                        {
                            howManyChicken++;
                        }
                    }
                    rl.DrawText($"You have {howManyChicken} Chickens in the pen", 10, 300, 30, Color.BLACK);
                }
                //Horse
                if (rl.IsKeyDown(KeyboardKey.KEY_H))
                {
                    howManyHorse = 0;
                    foreach (var i in farmAnimals)
                    {
                        if (i.name == "Horse")
                        {
                            howManyHorse++;
                        }
                    }
                    rl.DrawText($"You have {howManyHorse} Horses in the pen", 10, 300, 30, Color.BLACK);
                }
                //Pig
                if (rl.IsKeyDown(KeyboardKey.KEY_P))
                {
                    howManyPig = 0;
                    foreach (var i in farmAnimals)
                    {
                        if (i.name == "Pig")
                        {
                            howManyPig++;
                        }
                    }
                    rl.DrawText($"You have {howManyPig} Pigs in the pen", 10, 300, 30, Color.BLACK);
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

            StreamWriter writer = new StreamWriter("SaveData.txt");
            
            writer.WriteLine(player.money);

            writer.Close();
            SaveData(farmAnimals);

            rl.CloseWindow();        // Close window and OpenGL context
                                     //--------------------------------------------------------------------------------------

            return 0;
        }
    }
}
