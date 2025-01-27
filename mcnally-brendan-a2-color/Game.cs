
using System;
using System.Data;
using System.Numerics;
//  _____ _    _          _____  ______    _____ _    _ _____ ______ _______ ______ _____  
//  / ____| |  | |   /\   |  __ \|  ____|  / ____| |  | |_   _|  ____|__   __|  ____|  __ \ 
// | (___ | |__| |  /  \  | |__) | |__    | (___ | |__| | | | | |__     | |  | |__  | |__) |
//  \___ \|  __  | / /\ \ |  ___/|  __|    \___ \|  __  | | | |  __|    | |  |  __| |  _  / 
//  ____) | |  | |/ ____ \| |    | |____   ____) | |  | |_| |_| |       | |  | |____| | \ \ 
// |_____/|_|  |_/_/    \_\_|    |______| |_____/|_|  |_|_____|_|       |_|  |______|_|  \_\
                                                                                          
              
// WELCOME TO SHAPE SHIFTER, MY INTERACTIVE DRAWING GAME 
// I WILL MAKE THIS CODE SUPER READABLE :) :) :) :): - )


namespace MohawkGame2D
{

    public class Game
    {
        // Place our variables here:

        public void Setup()
        {
            //Setting up the Window Dimensions 

            Window.SetSize(400, 400);
            Window.SetTitle("SHAPESHIFTER");


        }


        ///     Update runs every frame.

        public void Update()
        {

            float r = Input.GetMouseX() / Window.Height;
            float b = Input.GetMouseY() / Window.Width;
            float g = 0.3f;

            ColorF bgColor = new ColorF(r, g, b);
            Window.ClearBackground(bgColor);

            if (Input.IsKeyboardKeyDown(KeyboardInput.One))
            {
                DrawCircle();
                Draw.FillColor = (bgColor);
            }

            // Adding the option to change shapes! SHAPESHIFTER! 
            if (Input.IsKeyboardKeyDown(KeyboardInput.Two))
            {
                DrawTriangle();
                Draw.FillColor = (bgColor);
            }

            if (Input.IsKeyboardKeyDown(KeyboardInput.Three))
            {
                DrawRectangle();
                Draw.FillColor = (bgColor);
            }

        }
        // Functions to Draw 
      
         
        void DrawCircle()
        {
            // I LOVE TO DRAW CIRCLES
            Draw.Circle(200, 200, 50);
            Draw.LineSize = 3;
            Draw.LineColor = Color.Black;
            Draw.FillColor = Color.Red;
        }
        void DrawTriangle()
        {
            // I LIKE RED TRIANGLES! I LOVE RED! LETS DRAW A TRIANGLE! WOO!
            Draw.Triangle(200, 140, 150, 260, 250, 260);
            Draw.LineSize = 3;
            Draw.LineColor = Color.Black;
            Draw.FillColor = Color.Red;
        }
        void DrawRectangle()
        {

            // I LOVE RECTANGLES AND GUESS WHAT! ITS GONNA BE RED AGAIN! WOO! 

            Draw.Rectangle(200, 200, 200, 200);
            Draw.LineSize = 3;
            Draw.LineColor = Color.Black;
            Draw.FillColor = Color.Red;
        }
    }


}

