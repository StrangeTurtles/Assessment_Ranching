using System;
using System.Collections.Generic;
using System.IO;
using Raylib;
using rl = Raylib.Raylib;

namespace Ranching
{
    static class Program
    {
        /// <summary>
        /// This will load saved animals
        /// </summary>
        /// <returns></returns>
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
                //checks if the name (which is what animal it is) is Cow
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
                //checks if the name (which is what animal it is) is Chicken
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
                //checks if the name (which is what animal it is) is Horse
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
                //checks if the name (which is what animal it is) is Pig
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
        /// <summary>
        /// This will save all the Animals
        /// that you buy in the game, 
        /// when you exit the game.
        /// </summary>
        /// <param name="animals"></param>
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
        /// <summary>
        /// Genrates a random int between 50 to 150
        /// </summary>
        /// <returns></returns>
        static int NewRandNum()
        {
            Random random = new Random();
            int randNum = 0;
            randNum = random.Next(50, 150);
            return randNum;
        }

        public static int Main()
        {
            // Initialization
            //--------------------------------------------------------------------------------------
            //The Animal class does not have this so if you change this then 
            //you have to change it in the animal class to
            //######################################################################################
            int screenWidth = 800;
            int screenHeight = 450;
            //######################################################################################
            Player player = new Player();
            player.money = 0.0;
            List<Animal> farmAnimals = new List<Animal>();
            //Varables that hold a int of how many <Animals>
            int howManyCow = 0;
            int howManyChicken = 0;
            int howManyHorse = 0;
            int howManyPig = 0;
            int howManyAnimals = 0;
            int howManyHungry = 0;
            //Varables that hold the cost
            int foodCost = 1;
            int cowCost = 5;
            int chickenCost = 50;
            int horseCost = 500;
            int pigCost = 5000;
            
            
            //Loads the cost and player money
            StreamReader reader = new StreamReader("SaveData.txt");
            while (!reader.EndOfStream)
            {
                string data = reader.ReadLine();
                double number = 0;
                //int number1 = 0;
                int number2 = 0;
                int number3 = 0;
                int number4 = 0;

                double.TryParse(data, out number);
                player.money = number;
                data = reader.ReadLine();
                int.TryParse(data, out cowCost);
                //cowCost = number1;
                data = reader.ReadLine();
                int.TryParse(data, out number2);
                chickenCost = number2;
                data = reader.ReadLine();
                int.TryParse(data, out number3);
                horseCost = number3;
                data = reader.ReadLine();
                int.TryParse(data, out number4);
                pigCost = number4;
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
            //"Sell" button 
            Button sellButton = new Button();
            sellButton.Position.x = 125;
            sellButton.Position.y = 150;
            sellButton.height = 50;
            sellButton.width = 50;
            sellButton.btnBounds = new Rectangle(sellButton.Position.x, sellButton.Position.y, sellButton.width, sellButton.height);


            rl.InitWindow(screenWidth, screenHeight, "raylib [core] example - basic window");

            rl.SetTargetFPS(60);

            
            //The Textures of the saved animals
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
                howManyAnimals = 0;
                howManyHungry = 0;
                // TODO: Update your variables here
                //----------------------------------------------------------------------------------
                foreach (var i in farmAnimals)
                {
                    i.RunUpdate();
                    i.Food();
                    i.Produce();
                    player.money += (i.makingMoney / 1200);
                    if(i.hungry)
                    {
                        howManyHungry++;
                    }
                    howManyAnimals++;
                    i.Draw();
                }

                foodCost = howManyHungry * 2;
                howManyAnimals = 0;
                //Buttons check if the button is active
                //Cow
                cowButton.Update();
                if (cowButton.buttonAction && player.money >= cowCost)
                {
                    farmAnimals.Add(new Cow());
                    player.money -= cowCost;
                    cowCost += 1;
                }
                //chicken
                chickenButton.Update();
                if (chickenButton.buttonAction && player.money >= chickenCost)
                {
                    farmAnimals.Add(new Chicken());
                    player.money -= chickenCost;
                    chickenCost += 10;
                }
                //horse
                horseButton.Update();
                if (horseButton.buttonAction && player.money >= horseCost)
                {
                    farmAnimals.Add(new Horse());
                    player.money -= horseCost;
                    horseCost += 50;
                }
                //pig
                pigButton.Update();
                if (pigButton.buttonAction && player.money >= pigCost)
                {
                    farmAnimals.Add(new Pig());
                    player.money -= pigCost;
                    pigCost += 500;
                }
                //food
                foodButton.Update();
                if (foodButton.buttonAction && player.money >= foodCost)
                {
                    foreach (var i in farmAnimals)
                    {
                        //NewRandNum();
                        if (i.hungry)
                        {
                            i.Food(NewRandNum());
                            i.hungry = false;
                        }
                    }
                    player.money -= foodCost;
                    foodCost = 0;
                }
                //sell
                sellButton.Update();
                if(sellButton.buttonAction)
                {
                    player.money += 0.1;
                }
                //This is for rounding the player's money 
                //to two places after the decimal
                double tmpmoney;
                tmpmoney = player.money;
                tmpmoney *= 100;
                tmpmoney = Math.Floor(tmpmoney);
                tmpmoney /= 100;

                

                // Sort
                //----------------------------------------------------------------------------------
                //if a key is pressed then show how many animals there are
                //Cow
                if(rl.IsKeyDown(KeyboardKey.KEY_C))
                {
                    howManyCow = 0;
                    foreach(var i in farmAnimals)
                    {
                        if (i.name == "Cow")
                        {
                            howManyCow++;
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
                

                //Cow
                cowButton.Draw();
                //chicken
                chickenButton.Draw();
                //horse
                horseButton.Draw();
                //Pig
                pigButton.Draw();
                //Feed 
                foodButton.Draw();

                sellButton.Draw();

                
                rl.DrawText($"You have ${tmpmoney}", 10, 10, 30, Color.BLACK);
                rl.DrawText($"Cow: ${cowCost}", 600, 75, 30, Color.BLACK);
                rl.DrawText($"Chicken: ${chickenCost}", 600, 175, 30, Color.BLACK);
                rl.DrawText($"Horse: ${horseCost}", 600, 275, 30, Color.BLACK);
                rl.DrawText($"Pig: ${pigCost}", 600, 375, 30, Color.BLACK);
                rl.DrawText($"Feed All: ${foodCost}", 100, 375, 30, Color.BLACK);
                rl.EndDrawing();
                //----------------------------------------------------------------------------------
            }

            // De-Initialization
            //--------------------------------------------------------------------------------------
            //saves the cost and players money
            StreamWriter writer = new StreamWriter("SaveData.txt");
            
            writer.WriteLine(player.money);
            writer.WriteLine(cowCost);
            writer.WriteLine(chickenCost);
            writer.WriteLine(horseCost);
            writer.WriteLine(pigCost);

            writer.Close();
            SaveData(farmAnimals);

            rl.CloseWindow();        // Close window and OpenGL context
                                     //--------------------------------------------------------------------------------------

            return 0;
        }
    }
}
