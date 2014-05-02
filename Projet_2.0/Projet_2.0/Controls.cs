using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System.Threading;

namespace Projet_2._0
{
    class Controls
    {
        public Vector2 Position;
        public Vector2 Velocity;
        public Vector2 Acceleration;
        public float speed;
        public float maxspeed;
        bool hasJumped;
        KeyboardState previousKeyboardState;
        KeyboardState keyboardState;


        public Controls(Vector2 Position, Vector2 Velocity, float speed)
        {
            this.Position = Position;
            this.Velocity = Velocity;
            Acceleration = new Vector2(10, 10);
            this.speed = speed;
            maxspeed = 500f;
            hasJumped = true;
        }

        public void update(GameTime gametime)
        {
            keyboardState = Keyboard.GetState();

            int delta = gametime.ElapsedGameTime.Milliseconds;

            if ((keyboardState.IsKeyUp(Keys.A) && keyboardState.IsKeyUp(Keys.D)) || (keyboardState.IsKeyDown(Keys.A) && keyboardState.IsKeyDown(Keys.D)))
            {
                if (Velocity.X > 0)
                {
                    Velocity.X += -Acceleration.X * 3;
                    if (Velocity.X < 0)
                        Velocity.X = 0f;
                }
                else
                {
                    Velocity.X += Acceleration.X * 3;
                    if (Velocity.X > 0)
                        Velocity.X = 0f;
                }
            }
            else if (keyboardState.IsKeyDown(Keys.A))
            {
                if (Velocity.X > 0)
                    Velocity.X += -Acceleration.X * 3;
                else if (Velocity.X > -maxspeed)
                    Velocity.X += -Acceleration.X;
            }
            else if (keyboardState.IsKeyDown(Keys.D))
            {
                if (Velocity.X < 0)
                    Velocity.X += Acceleration.X * 3;
                else if (Velocity.X < maxspeed)
                    Velocity.X += Acceleration.X;
            }

            if (keyboardState.IsKeyDown(Keys.W) && hasJumped == false)
            {
                Velocity.Y += -400f;
                hasJumped = true;
            }


            if (hasJumped == true)
                Velocity.Y += Acceleration.Y;

            if (Position.Y > 350)
            {
                Position.Y = 350f;
                Velocity.Y = 0f;
                hasJumped = false;
            }
            
            previousKeyboardState = keyboardState;

            Position += Velocity * speed;
        }

        public Vector2 getPosition()
        {
            return Position;
        }

        public Vector2 getVelocity()
        {
            return Velocity;
        }

    }
}
