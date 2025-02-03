
using System;
using System.Data;
using System.Numerics;


//██████╗░░█████╗░██╗░░░░░██╗░░░░░░█████╗░░█████╗░███╗░░██╗  ██████╗░░█████╗░██████╗░██╗
//██╔══██╗██╔══██╗██║░░░░░██║░░░░░██╔══██╗██╔══██╗████╗░██║  ██╔══██╗██╔══██╗██╔══██╗██║
//██████╦╝███████║██║░░░░░██║░░░░░██║░░██║██║░░██║██╔██╗██║  ██████╔╝██║░░██║██████╔╝██║
//██╔══██╗██╔══██║██║░░░░░██║░░░░░██║░░██║██║░░██║██║╚████║  ██╔═══╝░██║░░██║██╔═══╝░╚═╝
//██████╦╝██║░░██║███████╗███████╗╚█████╔╝╚█████╔╝██║░╚███║  ██║░░░░░╚█████╔╝██║░░░░░██╗
//╚═════╝░╚═╝░░╚═╝╚══════╝╚══════╝░╚════╝░░╚════╝░╚═╝░░╚══╝  ╚═╝░░░░░░╚════╝░╚═╝░░░░░╚═╝

// WELCOME TO BALLOON POP! MY PROTOTYPE INTERACTIVE 2D GAME🎈🎈🎈
// IN THIS ACTIVITY/GAME YOU POP BALLOONS 🎈🎈🎈
namespace MohawkGame2D
{

    public class Game
    {
        // Place our variables here:

        int balloonCount = 12; // Amount of Balloons on Screen 
        Vector2[] balloonPositions; // Vector2 Array for Balloon Positions :) 
        float balloonSpeed = 50.0f; // Speed for Balloons
        int highScore = 0; // Players balloons popped
        Color Skyblue = new Color(160, 217, 239); // Color for the background
        public void Setup() 
        {
            //Setting up the Window Dimensions 

            Window.SetSize(400, 400);
            Window.SetTitle("Balloon Pop!"); // Welcome to Balloon Pop!

            float balloonSpacing = Window.Width / balloonCount; // Spacing the Balloons on the screen

           
            balloonCount = 12; // Max amount of balloons on screen
            balloonPositions = new Vector2[balloonCount]; // Using Vector2 Array to store balloon positions

            for (int i = 0; i < balloonCount; i++)
            {

                balloonPositions[i] = new Vector2( // Array for Balloon positions
                 Random.Float(25, Window.Width - 25),
                    Random.Float(300, Window.Height - 50)
                    );

                    
                };
            }



        ///     Update runs every frame.

        public void Update()
        {
            // USING FUNCTIONS TO KEEP THE CODE CLEAN
            moveBalloons(); // Using functions to move the balloons on the screen
            checkBalloonPops(); // Using functions to draw if the balloons are popped
            drawBalloons(); // Using functions to draw the Balloons on the screen
            drawClouds(); // Using functions to draw the clouds
            drawScoreboard(); // Using functions to draw the scoreboard
        }
            
        
        // Functions to Draw
            // Moving the Balloons
            void moveBalloons() // Function to move the Balloons
            {
                for (int i = 0; i < balloonPositions.Length; i++)  // For loop to move the balloons on the screen
            {
                    balloonPositions[i].Y -= balloonSpeed * Time.DeltaTime;

                    if (balloonPositions[i].Y < -50)
                    {
                        balloonPositions[i] = new Vector2(
                            Random.Float(25, Window.Width - 25), // Making sure it isn't going off the screen 
                            Window.Height
                            );
                    }
                }
              
            }
          
        
        // Checking the player mouse input aka Popping the Balloons
            void checkBalloonPops()
            {
                if (Input.IsMouseButtonPressed(MouseInput.Left)) // If the player clicks the balloon with the left mouse button, it will POP!
                {

                    Vector2 mousepositions = new Vector2(Input.GetMouseX(), Input.GetMouseY()); // Using a vector 2 Array to store the mouse positions
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
           

            // Clear background with the color Skyblue. 
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
                Draw.Rectangle(320, 20, 60, 40); // Drawing the Scoreboard 
                Draw.LineColor = Color.Black;
                Draw.LineSize = 3;

                Vector2 scorePosition = new Vector2(330, 30);
                Text.Color = Color.Black;
                Text.Draw($"{highScore}", scorePosition);
            }
            
           
        }

        }

    }




