/* Template: Nathan Bean
 * Author: Bethany Weddle
 * CIS580 Project 1
 * */
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;

namespace MonoGameWindowsStarter
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        // Whether the game is over or has started
        bool beginGame;
        bool endGame;
        bool spacebarPressed;

        // To keep track of screen dimensions
        float screenWidth; 
        float screenHeight;

        // For background/start page and to keep track of score
        Texture2D backgroundStart;
        SpriteFont scoreFont;
        SpriteFont stateFont;
        float score;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            base.Initialize();

            score = 0;
            endGame = false;
            beginGame = false;
            spacebarPressed = false;

            screenWidth = 1042;
            screenHeight = 768;           
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);
            backgroundStart = Content.Load<Texture2D>("background");
            scoreFont = Content.Load<SpriteFont>("Score");
            stateFont = Content.Load<SpriteFont>("GameState");

            // TODO: use this.Content to load your game content here
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// game-specific content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {

            KeyboardActions();
            
            // TODO: Add your update logic here

            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);
            spriteBatch.DrawString(scoreFont, score.ToString(), new Vector2(screenWidth - 100, 50), Color.Black);
            // TODO: Add your drawing code here


            // Got this code from https://docs.microsoft.com/en-us/windows/uwp/get-started/get-started-tutorial-game-mg2d
            // { from here 
            if (!beginGame)
            { 
                // Fill the screen with black before the game starts
                spriteBatch.Draw(backgroundStart, new Rectangle(0, 0,
                (int)screenWidth, (int)screenHeight), Color.White);

                String title = "Game 1.0";
                String pressSpace = "Press Space to start";

                // Measure the size of text in the given font
                Vector2 titleSize = stateFont.MeasureString(title);
                Vector2 pressSpaceSize = stateFont.MeasureString(pressSpace);

                // Draw the text horizontally centered
                spriteBatch.DrawString(stateFont, title,
                new Vector2(screenWidth / 2 - titleSize.X / 2, screenHeight / 3),
                Color.ForestGreen);
                spriteBatch.DrawString(stateFont, pressSpace,
                new Vector2(screenWidth / 2 - pressSpaceSize.X / 2,
                screenHeight / 2), Color.White);
            }
            // } to here 

            base.Draw(gameTime);
        }

        void KeyboardActions()
        {
            // Got code from https://docs.microsoft.com/en-us/windows/uwp/get-started/get-started-tutorial-game-mg2d
            // { From here 
            KeyboardState keyboardState = Keyboard.GetState();

            // Quit the game if Escape is pressed.
            if (keyboardState.IsKeyDown(Keys.Escape)) Exit();

            // Start the game if Space is pressed.
            // Exit the keyboard handler method early, preventing the dino from jumping on the same keypress.
            if (!beginGame)
            {
                if (keyboardState.IsKeyDown(Keys.Space))
                {
                    // reset anything
                    beginGame = true;
                    spacebarPressed = true;
                    endGame = false;
                }
                return;
            }

            // Restart the game if Enter is pressed
            if (endGame)
            {
                if (keyboardState.IsKeyDown(Keys.Enter))
                {
                    // reset anything
                    endGame = false;
                }
            }

            // } to here
        }
    }
}
