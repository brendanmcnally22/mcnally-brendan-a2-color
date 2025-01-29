
using System;
using System.Data;
using System.Numerics;


//██████╗░░█████╗░██╗░░░░░██╗░░░░░░█████╗░░█████╗░███╗░░██╗  ██████╗░░█████╗░██████╗░██╗
//██╔══██╗██╔══██╗██║░░░░░██║░░░░░██╔══██╗██╔══██╗████╗░██║  ██╔══██╗██╔══██╗██╔══██╗██║
//██████╦╝███████║██║░░░░░██║░░░░░██║░░██║██║░░██║██╔██╗██║  ██████╔╝██║░░██║██████╔╝██║
//██╔══██╗██╔══██║██║░░░░░██║░░░░░██║░░██║██║░░██║██║╚████║  ██╔═══╝░██║░░██║██╔═══╝░╚═╝
//██████╦╝██║░░██║███████╗███████╗╚█████╔╝╚█████╔╝██║░╚███║  ██║░░░░░╚█████╔╝██║░░░░░██╗
//╚═════╝░╚═╝░░╚═╝╚══════╝╚══════╝░╚════╝░░╚════╝░╚═╝░░╚══╝  ╚═╝░░░░░░╚════╝░╚═╝░░░░░╚═╝

// WELCOME TO BALLOON POP! MY PROTOTYPE INTERACTIVE 2D THING
// IN THIS ACTIVITY/GAME YOU POP BALLOONS 
namespace MohawkGame2D
{

    public class Game
    {
        // Place our variables here:

        int balloonCount = 0;
        Vector2[] balloonPositions; // trying to make an array to store my balloons positions on the screen
        float balloonSpeed = 50.0f;
        
        public void Setup() 
        {
            //Setting up the Window Dimensions 

            Window.SetSize(400, 400);
            Window.SetTitle("Balloon Pop!");

            balloonCount = 5;
            balloonPositions = new Vector2[balloonCount];

            for (int i = 0; i < balloonCount; i++)
            {
                balloonPositions[i] = new Vector2(Random.Float(50, 350), Random.Float(300, 400));
            }

        }


        ///     Update runs every frame.

        public void Update()
        {
            DrawBalloon();
            // im trying to make the balloons go up

            for (int i = 0; i < balloonPositions.Length; i++)
            {
                balloonPositions[i].Y -= balloonSpeed * Time.DeltaTime;

                // ok now if the balloon goes off the screen it will reset to the bottom

                if (balloonPositions[i].Y < -50)
                {
                    balloonPositions[i] = new Vector2(Random.Float(50, 350), 400);
                }
            }

            // now lets make sure  when the mouse clicks it pops the balloon 

            if (Input.IsMouseButtonPressed(MouseInput.Left))
            {
                {
                    Vector2 mousePosition = new Vector2(Input.GetMouseX(), Input.GetMouseY());
                    for (int i = 0; i < balloonPositions.Length; i++)
                    {
                        if (Vector2.Distance(mousePosition, balloonPositions[i]) < 30)
                        {

                            // POP!

                            balloonPositions[i] += new Vector2(MohawkGame2D.Random.Float(50, 350), 400);
                        }
                    }

                }
            }
            // Functions to Draw 
            void DrawBalloon()
            {

                Window.ClearBackground(Color.OffWhite);

                Draw.FillColor = Random.Color(); // random balloon colors

                for (int i = 0; i < balloonPositions.Length; i++)
                {
                    Draw.Circle(balloonPositions[i].X, balloonPositions[i].Y, 25);
                }
            }


        }

    }
}



