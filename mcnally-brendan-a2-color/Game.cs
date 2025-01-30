
using System;
using System.Data;
using System.Numerics;


//██████╗░░█████╗░██╗░░░░░██╗░░░░░░█████╗░░█████╗░███╗░░██╗  ██████╗░░█████╗░██████╗░██╗
//██╔══██╗██╔══██╗██║░░░░░██║░░░░░██╔══██╗██╔══██╗████╗░██║  ██╔══██╗██╔══██╗██╔══██╗██║
//██████╦╝███████║██║░░░░░██║░░░░░██║░░██║██║░░██║██╔██╗██║  ██████╔╝██║░░██║██████╔╝██║
//██╔══██╗██╔══██║██║░░░░░██║░░░░░██║░░██║██║░░██║██║╚████║  ██╔═══╝░██║░░██║██╔═══╝░╚═╝
//██████╦╝██║░░██║███████╗███████╗╚█████╔╝╚█████╔╝██║░╚███║  ██║░░░░░╚█████╔╝██║░░░░░██╗
//╚═════╝░╚═╝░░╚═╝╚══════╝╚══════╝░╚════╝░░╚════╝░╚═╝░░╚══╝  ╚═╝░░░░░░╚════╝░╚═╝░░░░░╚═╝

// WELCOME TO BALLOON POP! MY PROTOTYPE INTERACTIVE 2D THING🎈🎈🎈
// IN THIS ACTIVITY/GAME YOU POP BALLOONS 🎈🎈🎈
namespace MohawkGame2D
{

    public class Game
    {
        // Place our variables here:

        int balloonCount = 12; // Amount of Balloons on Screen
        Vector2[] balloonPositions; // trying to make an array to store my balloons positions on the screen
        float balloonSpeed = 50.0f; // Speed for Balloons
        int highScore = 0; // Players balloons popped
        Color Skyblue = new Color(160, 217, 239); // Color for the background
        public void Setup() 
        {
            //Setting up the Window Dimensions 

            Window.SetSize(400, 400);
            Window.SetTitle("Balloon Pop!");

            float balloonSpacing = Window.Width / balloonCount;

           
            balloonCount = 12;
            balloonPositions = new Vector2[balloonCount];

            for (int i = 0; i < balloonCount; i++)
            {

                balloonPositions[i] = new Vector2(
                 Random.Float(25, Window.Width - 25),
                    Random.Float(300, Window.Height - 50)
                    );
                    
                };
            }



        ///     Update runs every frame.

        public void Update()
        {
            //Test
            // im trying to make the balloons go up🎈
            MoveBalloons();
            checkBalloonPops();
            drawBalloons();
            drawClouds();
            drawScoreboard();
        }
            
        
        // Functions to Draw
            // Moving the Balloons
            void MoveBalloons()
            {
                for (int i = 0; i < balloonPositions.Length; i++)
                {
                    balloonPositions[i].Y -= balloonSpeed * Time.DeltaTime;

                    if (balloonPositions[i].Y < -50)
                    {
                        balloonPositions[i] = new Vector2(
                            Random.Float(25, Window.Width - 25),
                            Window.Height
                            );
                    }
                }
              
            }
          
        
        // Checking the player mouse input aka Popping the Balloons
            void checkBalloonPops()
            {
                if (Input.IsMouseButtonPressed(MouseInput.Left))
                {

                    Vector2 mousepositions = new Vector2(Input.GetMouseX(), Input.GetMouseY());
                    for (int i = 0; i < balloonPositions.Length; i++)


                        if (Vector2.Distance(mousepositions, balloonPositions[i]) <30)
                    {
                        // Popping the Balloon 🎈🎈🎈🎈🎈🎈🎈🎈🎈
                        balloonPositions[i] = new Vector2(
                            Random.Float(25, Window.Width - 25),
                            Window.Height
                            );
                        highScore++; //add to score
                    }
                }
            }
         
        
        // Drawing the Balloons, High score and Background
            void drawBalloons()
            {
           

            // Clear background, probably going to change to skyblue i think
                Window.ClearBackground(Skyblue);
                
                for (int i = 0; i < balloonPositions.Length; i++)
                {
                //Drawing the Balloon strings
                Draw.LineSize = 3;
                    Draw.Line(balloonPositions[i].X, balloonPositions[i].Y + 25,
                        balloonPositions[i].X, balloonPositions[i].Y + 50);

                    //Drawing the balloons
                    Draw.FillColor = Color.Red;
                Draw.LineSize = 3;
                Draw.LineColor = Color.Black;
                    Draw.Circle(balloonPositions[i].X, balloonPositions[i].Y, 25);

                }

                // High score I still don't know how to get this on the screen properly yet, so lets figure that out next time.

                Vector2 scorePosition = new Vector2(Window.Width - 100, 10);
                

            }
        void drawClouds() // Add clouds
        {
            for (int i = 0; i < 4; i++) // Using a Loop to draw 4 clouds
            {
                int x = 50 + i * 100;
                Draw.FillColor = Color.White;
                Draw.Circle(x, Window.Height, 75);
            }
        }
               
        void drawScoreboard() // Draw Scoreboard
        {


            if (Input.IsKeyboardKeyDown(KeyboardInput.Space)) // press space to see the scoreboard
            { 
                Draw.Rectangle(320, 20, 60, 40);
                Draw.LineColor = Color.Black;
                Draw.LineSize = 3;
                
            }
            
           
        }

        }

    }




