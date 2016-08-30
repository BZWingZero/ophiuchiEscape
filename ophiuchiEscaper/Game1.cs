using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;

namespace ophiuchiEscaper
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        private Tile tileMapTiles, tileMapGround;

        private int[,] level = new int[,]
        {
            {0,0,0,0,0,0,0,0,0,0,0,0 },
            {0,0,0,0,0,0,0,0,0,0,0,0 },
            {0,0,0,0,0,0,0,0,0,0,0,0 },
            {0,0,0,0,0,0,0,0,0,0,0,0 },
            {0,0,0,0,0,0,0,0,0,0,0,0 },
            {0,0,0,0,0,0,0,0,0,0,0,0 },
            {0,0,0,0,0,0,0,0,0,0,0,0 },
            {0,0,0,0,0,0,0,0,0,0,0,0 }
        };

        private const int TILE_SIZE = 64;
        static int TILE_HEIGHT = 128;
        static int TILE_WIDTH = 128;

        static int SCREEN_HEIGHT = 720;
        static int SCREEN_WIDTH = SCREEN_HEIGHT / 9 * 16;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";

            //Sets the size to 720p;
            graphics.PreferredBackBufferHeight = SCREEN_HEIGHT;
            graphics.PreferredBackBufferWidth = SCREEN_WIDTH;

            IsMouseVisible = true;
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
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);

            //Loads all of the spritesheets needed
            Texture2D tiles = Content.Load<Texture2D>(@"spritesheet\spritesheet_tiles");
            Texture2D ground = Content.Load<Texture2D>(@"spritesheet\spritesheet_ground");

            //Defines the rows and columns for the maps
            tileMapTiles = new Tile(tiles, 16, 8);
            tileMapGround = new Tile(ground, 16, 8);
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
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            tileMapTiles.Update();
            tileMapGround.Update();

            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            for( int i = 0; i < 5; i++) //rows
            {
                for( int j = 0; j < 10; j++) //columns
                {
                    //tileMapGround.Draw(spriteBatch, new Vector2(j * TILE_SIZE, i * TILE_SIZE), 0);
                    tileMapGround.Draw(spriteBatch, new Vector2(j * TILE_SIZE, i * TILE_SIZE), level[i, j]);
                }
            }

            base.Draw(gameTime);
        }
    }
}
