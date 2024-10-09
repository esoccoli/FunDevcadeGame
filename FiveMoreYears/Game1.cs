using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Devcade;

// MAKE SURE YOU RENAME ALL PROJECT FILES FROM DevcadeGame TO YOUR YOUR GAME NAME
namespace FiveMoreYears
{

    /// <summary>
    /// Enum storing the different possible states the game can be in
    /// This can be used for making a game menu
    /// Feel free to modify this as needed
    /// </summary>
    public enum GameStates
    {
        Menu,
        Playing,
        Paused,
        Win,
        GameOver
    }

    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;

        /// <summary>
        /// Stores the window dimensions in a rectangle object for easy use
        /// </summary>
        private Rectangle windowSize;

        public Texture2D frogTexture;

        public Rectangle frogBox;

        /// <summary>
        /// Game constructor
        /// </summary>
        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = false;
        }

        /// <summary>
        /// Performs any setup that doesn't require loaded content before the first frame.
        /// </summary>
        protected override void Initialize()
        {
            // Sets up the input library
            Input.Initialize();

            // Set window size if running debug (in release it will be fullscreen)
            #region
#if DEBUG
			_graphics.PreferredBackBufferWidth = 420;
			_graphics.PreferredBackBufferHeight = 980;
			_graphics.ApplyChanges();
#else
            _graphics.PreferredBackBufferWidth = GraphicsDevice.DisplayMode.Width;
            _graphics.PreferredBackBufferHeight = GraphicsDevice.DisplayMode.Height;
            _graphics.ApplyChanges();
#endif
            #endregion

            // TODO: Add your initialization logic here

            windowSize = GraphicsDevice.Viewport.Bounds;

            base.Initialize();
        }

        /// <summary>
        /// Performs any setup that requires loaded content before the first frame.
        /// </summary>
        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            // TODO: use this.Content to load your game content here
            // ex:
            // texture = Content.Load<Texture2D>("fileNameWithoutExtension");
            frogTexture = Content.Load<Texture2D>("frog");

            frogBox = new Rectangle(
                (windowSize.Width / 2) - (frogTexture.Width / 2),
                (windowSize.Height / 2) - (frogTexture.Height / 2),
                frogTexture.Width,
                frogTexture.Height
            );
        }

        /// <summary>
        /// Your main update loop. This runs once every frame, over and over.
        /// </summary>
        /// <param name="gameTime">This is the gameTime object you can use to get the time since last frame.</param>
        protected override void Update(GameTime gameTime)
        {
            Input.Update(); // Updates the state of the input library

            // Exit when both menu buttons are pressed (or escape for keyboard debugging)
            // You can change this but it is suggested to keep the keybind of both menu
            // buttons at once for a graceful exit.
            if (Keyboard.GetState().IsKeyDown(Keys.Escape) ||
                (Input.GetButton(1, Input.ArcadeButtons.Menu) &&
                Input.GetButton(2, Input.ArcadeButtons.Menu)))
            {
                Exit();
            }

            if (Keyboard.GetState().IsKeyDown(Keys.W) ||
                Input.GetButton(1, Input.ArcadeButtons.StickUp))
            {
                frogBox.Y -= 3;
            }
            if (Keyboard.GetState().IsKeyDown(Keys.S) ||
                Input.GetButton(1, Input.ArcadeButtons.StickDown))
            {
                frogBox.Y += 3;
            }
            if (Keyboard.GetState().IsKeyDown(Keys.A) ||
                Input.GetButton(1, Input.ArcadeButtons.StickLeft))
            {
                frogBox.X -= 3;
            }
            if (Keyboard.GetState().IsKeyDown(Keys.D) ||
                Input.GetButton(1, Input.ArcadeButtons.StickRight))
            {
                frogBox.X += 3;
            }
            // TODO: Add your update logic here

            base.Update(gameTime);
        }

        /// <summary>
        /// Your main draw loop. This runs once every frame, over and over.
        /// </summary>
        /// <param name="gameTime">This is the gameTime object you can use to get the time since last frame.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // Batches all the draw calls for this frame, and then performs them all at once
            _spriteBatch.Begin();
            // TODO: Add your drawing code here
            _spriteBatch.Draw(frogTexture, frogBox, Color.White);

            _spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}