using GameEngine;
using SFML.Graphics;
using SFML.System;
using GameEngine;
using SFML.Graphics;
using SFML.System;
using System;

namespace MyGame
{
    internal class Meteor : GameObject
    {
        private Random random = new Random();
        
        private const float Speed = 0.1f;

        private readonly Sprite _sprite = new Sprite();

        public Meteor(Vector2f pos)
        {
            _sprite.Texture = Game.GetTexture("Resources/laser.png");
            _sprite.Position = pos;
            AssignTag("laser");
        }
        public override void Draw()
        {
            Game.RenderWindow.Draw(_sprite);
        }
        public override void Update(Time elapsed)
        {
            int msElapsed = elapsed.AsMilliseconds();
            Vector2f pos = _sprite.Position;

            if (pos.X > Game.RenderWindow.Size.X)
            {
                MakeDead();
            }
            else
            {
                _sprite.Position = new Vector2f(pos.X + Speed * msElapsed, pos.Y);
            }
        }
    }
}
