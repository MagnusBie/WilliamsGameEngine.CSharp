using GameEngine;
using SFML.Graphics;
using SFML.System;
using SFML.Window;
using System;

namespace MyGame
{
    class Ship : GameObject
    {
        const float Speed = 0.3f;
        private const int FireDelay = 200;
        private int _fireTimer;

        private readonly Sprite _sprite = new Sprite();
        public Ship() //Creating the ship
        {
            _sprite.Texture = Game.GetTexture("Resources/ship.png");
            _sprite.Position = new Vector2f(100, 100);
        }

        public override void Draw()
        {
            Game.RenderWindow.Draw(_sprite);
        }
        public override void Update(Time elapsed)
        {
            Vector2f pos = _sprite.Position;
            float x = pos.X;
            float y = pos.Y;

            int msElapsed = elapsed.AsMilliseconds();

            int size = Convert.ToInt32(Game.RenderWindow.Size);

            if (Keyboard.IsKeyPressed(Keyboard.Key.Up) && y >= 0)         { y -= Speed * msElapsed; }
            if (Keyboard.IsKeyPressed(Keyboard.Key.Down) && y <= (size + 120))     { y += Speed * msElapsed; }
            if (Keyboard.IsKeyPressed(Keyboard.Key.Left) && x >= 0)       { x -= Speed * msElapsed; }
            if (Keyboard.IsKeyPressed(Keyboard.Key.Right) && x <= (size + 84))    { x += Speed * msElapsed; }
            _sprite.Position = new Vector2f(x, y);

            if (_fireTimer > 0) { _fireTimer -= msElapsed; }

            if (Keyboard.IsKeyPressed(Keyboard.Key.Space) && _fireTimer <= 0)
            {
                _fireTimer = FireDelay;
                FloatRect bounds = _sprite.GetGlobalBounds();
                float laserX = x + bounds.Width;
                float laserY = y + bounds.Height / 2.0f;
                Laser laser = new Laser(new Vector2f(laserX, laserY));
                Game.CurrentScene.AddGameObject(laser);
                laserX = x + bounds.Width - 36;
                laserY = y + bounds.Height;
                laser = new Laser(new Vector2f(laserX, laserY));
                Game.CurrentScene.AddGameObject(laser);
                laserX = x + bounds.Width - 36;
                laserY = y;
                laser = new Laser(new Vector2f(laserX, laserY));
                Game.CurrentScene.AddGameObject(laser);
            }
        }
    }
}
