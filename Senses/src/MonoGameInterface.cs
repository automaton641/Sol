using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Senses
{
    public class MonoGameInterface : Game
    {
        internal Window window;
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        internal Size size;
        internal Texture2D texture;
        internal uint[] pixels;
        MouseState mouseState;
        public MonoGameInterface()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            graphics.PreferredBackBufferWidth = size.width;
            graphics.PreferredBackBufferHeight = size.height;
            graphics.ApplyChanges();
            size.width = GraphicsDevice.PresentationParameters.BackBufferWidth;
            size.height = GraphicsDevice.PresentationParameters.BackBufferHeight;
            texture = new Texture2D(GraphicsDevice, size.width, size.height, false, SurfaceFormat.Color);
            pixels = new uint[size.width * size.height];
            window.pixelDrawer = new PixelDrawer(pixels, size.width, size.height);
            
        
            base.Initialize();
        }

        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);

            // TODO: use this.Content to load your game content here
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here
            mouseState = Mouse.GetState();
            if (window.mouseState.dictionary[Button.LeftMouse] == SButtonState.Released)
            {
                if (mouseState.LeftButton == ButtonState.Pressed)
                {
                    window.MouseStateUpdate(Button.LeftMouse, SButtonState.Pressed);
                }
            }
            else
            {
                if (mouseState.LeftButton == ButtonState.Released)
                {
                    window.MouseStateUpdate(Button.LeftMouse, SButtonState.Released);
                }
            }

            if (window.mouseState.dictionary[Button.RightMouse] == SButtonState.Released)
            {
                if (mouseState.RightButton == ButtonState.Pressed)
                {
                    window.MouseStateUpdate(Button.RightMouse, SButtonState.Pressed);
                }
            }
            else
            {
                if (mouseState.RightButton == ButtonState.Released)
                {
                    window.MouseStateUpdate(Button.RightMouse, SButtonState.Released);
                }
            }
            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            // TODO: Add your drawing code here
            if (window.shouldPaint)
            {
                window.Draw();
                texture.SetData<uint>(pixels, 0, size.width * size.height);
                spriteBatch.Begin();
                spriteBatch.Draw(texture, new Rectangle(0, 0, size.width, size.height), Color.White);
                spriteBatch.End();
                window.shouldPaint = false;
            }

            base.Draw(gameTime);
        }
    }
}