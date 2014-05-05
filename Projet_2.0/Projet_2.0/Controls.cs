using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System.Threading;
using Microsoft.Xna.Framework.Content;

namespace Projet_2._0
{
    public class Controls
    {
        public Vector2 Position, previousPosition;
        public Vector2 Velocity;
        public Vector2 Acceleration;
        public float speed;
        public float maxspeed;
        bool hasJumped, isontop;
        KeyboardState previousKeyboardState;
        KeyboardState keyboardState;
        Keys Up, Left, Right;
        Level1 level1;
        //Casper casper;


        public Controls(Vector2 Position, Vector2 Velocity, float speed, Keys Up, Keys Left, Keys Right)
        {
            this.Up = Up;
            this.Left = Left;
            this.Right = Right;
            this.Position = Position;
            this.Velocity = Velocity;
            Acceleration = new Vector2(10, 10);
            this.speed = speed;
            maxspeed = 500f;
            hasJumped = true;
            level1 = new Level1(new Vector2(0, 0));
            previousPosition = Position;
        }

        public void update(GameTime gametime, Casper casper)
        {
            keyboardState = Keyboard.GetState();
            int delta = gametime.ElapsedGameTime.Milliseconds;
            if (keyboardState.IsKeyDown(Keys.S) && previousKeyboardState.IsKeyUp(Keys.S) || keyboardState.IsKeyDown(Keys.Down) && previousKeyboardState.IsKeyUp(Keys.Down))
                hasJumped = true;

            if ((keyboardState.IsKeyUp(Left) && keyboardState.IsKeyUp(Right)) || (keyboardState.IsKeyDown(Left) && keyboardState.IsKeyDown(Right)))
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
            else if (keyboardState.IsKeyDown(Left))
            {
                if (Velocity.X > 0)
                    Velocity.X += -Acceleration.X * 3;
                else if (Velocity.X > -maxspeed)
                    Velocity.X += -Acceleration.X;
            }
            else if (keyboardState.IsKeyDown(Right))
            {
                if (Velocity.X < 0)
                    Velocity.X += Acceleration.X * 3;
                else if (Velocity.X < maxspeed)
                    Velocity.X += Acceleration.X;
            }

            if (keyboardState.IsKeyDown(Up) && hasJumped == false)
            {
                SoundManager.jump.Play();
                Velocity.Y += -500;
                hasJumped = true;
            }

            if (hasJumped == true)
            {
                Velocity.Y += Acceleration.Y;
            }
           
            
            if (Position.Y > 1015)
            {
                Position.Y = 1015f;
                Velocity.Y = 0f;
                hasJumped = false;
            }

            previousKeyboardState = keyboardState;
            //Position = Collision(casper.Hitbox, level1.getList());
            Velocity = Collision(casper.Hitbox, level1.getList());
            Position += Velocity * speed;
            //Velocity.Y = -3;
            //Position = Collision(casper.Hitbox, level1.getList());
            previousPosition = Position;
            
        }

        public Vector2 Collision(Rectangle casperHitbox, List<Rectangle> level1)
        {
            foreach (Rectangle rect in level1)
            {
                if (casperHitbox.Intersects(rect))
                {
                    if (Velocity.Y < 700)
                    {
                        if (casperHitbox.Bottom <= rect.Top + 7 && casperHitbox.Bottom >= rect.Top)
                        {
                            Position.Y = rect.Top - 35;
                            Velocity.Y = 0f;
                            hasJumped = false;
                        }
                    }
                    else
                    {
                        if (casperHitbox.Bottom <= rect.Top + 50 && casperHitbox.Bottom >= rect.Top)
                        {
                            Position.Y = rect.Top - 35;
                            Velocity.Y = 0f;
                            hasJumped = false;
                        }
                    }
                    if (casperHitbox.Right <= rect.Left + 10 && casperHitbox.Right >= rect.Left)
                    {
                        Position.X = rect.X - 17;
                        Velocity.X = - Acceleration.X;
                    }
                    if (casperHitbox.Left >= rect.Right - 10 && casperHitbox.Left <= rect.Right)
                    {
                        Position.X = rect.Right + 1;
                        Velocity.X = + Acceleration.X;
                    }
                    if (casperHitbox.Top >= rect.Bottom - 10 && casperHitbox.Top <= rect.Bottom)
                    {
                        Position.Y = rect.Bottom + 1;
                        Velocity.Y = 0f;
                    }
                }
                
                
            }
            return Velocity;
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
