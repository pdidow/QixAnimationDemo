using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;

namespace QixAnimationDemo
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        float t;
        static readonly int NUM_LINES = 5;

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
            _graphics.PreferredBackBufferWidth = 500;
            _graphics.PreferredBackBufferHeight = 500;
            _graphics.IsFullScreen = true;
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here

            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            // TODO: use this.Content to load your game content here
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            t += 0.05f;

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            _spriteBatch.Begin();
            for (int i = 0; i < NUM_LINES; i++)
            {
                Vector2 start = new Vector2(x1(t+i), y1(t+i));
                Vector2 end = new Vector2(x2(t+i), y2(t+i));
                DrawLine(start, end, Color.White, 5);
                
            }
            t += 0.05f;
            _spriteBatch.End();

            base.Draw(gameTime);
        }
        public void DrawLine(Vector2 start, Vector2 end, Color color, float thickness = 1)
        {
            var distance = Vector2.Distance(start, end);
            var angle = (float)Math.Atan2(end.Y - start.Y, end.X - start.X);
            Texture2D lineTexturePoint;
            lineTexturePoint = new Texture2D(_graphics.GraphicsDevice, 1, 1);
            lineTexturePoint.SetData(new Color[] { Color.Red });
            _spriteBatch.Draw(lineTexturePoint, start, null, color, angle, Vector2.Zero, new Vector2(distance, thickness), SpriteEffects.None, 0);
        }
        //public void DrawLineWithFade(Vector2 start, Vector2 end, Color color, float thickness = 1)
        //{
        //    color.A = (byte)(255 / NUM_LINES * (NUM_LINES - thickness));
        //    var distance = Vector2.Distance(start, end);
        //    var angle = (float)Math.Atan2(end.Y - start.Y, end.X - start.X);
        //    Texture2D lineTexturePoint;
        //    lineTexturePoint = new Texture2D(_graphics.GraphicsDevice, 1, 1);
        //    lineTexturePoint.SetData(new Color[] { Color.Red });
        //    _spriteBatch.Draw(lineTexturePoint, start, null, color, angle, Vector2.Zero, new Vector2(distance, thickness), SpriteEffects.None, 0);
        //}
        //float x1(float t)
        //{
        //    return (float)(Math.Sin(t / 10) * 100 + Math.Sin(t / 5) * 20 + 200);
        //}

        //float y1(float t)
        //{
        //    return (float)(Math.Cos(t / 10) * 100 + 200);
        //}

        //float x2(float t)
        //{
        //    return (float)(Math.Sin(t / 10) * 200 + Math.Sin(t) * 2 + 200);
        //}

        //float y2(float t)
        //{
        //    return (float)(Math.Cos(t / 20) * 200 + Math.Cos(t / 12) * 20 + 200);
        //}
        float x1(float t)
        {
            return (float)(Math.Sin(t / 5) * 100 + 200);
        }

        float y1(float t)
        {
            return (float)(Math.Cos(t / 5) * 100 + 200);
        }

        float x2(float t)
        {
            return (float)(Math.Sin(t / 2) * 200 + 200);
        }
        float y2(float t)
        {
            return (float)(Math.Cos(t / 10) * (200 + 100 * Math.Sin(t / 2)) + 200);
        }

    }
}