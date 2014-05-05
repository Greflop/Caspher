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
        public Vector2 Position;
        public Vector2 Velocity;
        public Vector2 Acceleration;
        public GameType gametype;
        public float speed;
        public float maxspeed;
        bool hasJumped;
        KeyboardState previousKeyboardState;
        KeyboardState keyboardState;
        Keys Up, Left, Right, Down;


        public Controls(Vector2 Position, Vector2 Velocity, float speed, Keys Up, Keys Left, Keys Right,Keys Down)
        {
            this.Up = Up;
            this.Left = Left;
            this.Right = Right;
            this.Down = Down;
            this.Position = Position;
            this.Velocity = Velocity;
            Acceleration = new Vector2(10, 10);
            this.speed = speed;
            maxspeed = 500f;
            hasJumped = true;
        }

        public void update(GameTime gametime, GameType gametype)
        {
            keyboardState = Keyboard.GetState();

            int delta = gametime.ElapsedGameTime.Milliseconds;

            if (gametype == GameType.Menu_Play_Solo_world1_lvl1 || gametype == GameType.Menu_Play_Solo_world1_lvl2 || gametype == GameType.Menu_Play_Solo_world1_lvl3 || gametype == GameType.Menu_Play_Multi_Type)
            {
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
                    Velocity.Y += -400;
                    hasJumped = true;
                }

                if (hasJumped == true)
                {
                    Velocity.Y += Acceleration.Y;
                }

                if (Position.Y > 350)
                {
                    Position.Y = 350f;
                    Velocity.Y = 0f;
                    hasJumped = false;
                }

                previousKeyboardState = keyboardState;

                Position += Velocity * speed;
            }
            else if (gametype == GameType.Menu_Play_Solo_world2_lvl1)
            {
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

                if ((keyboardState.IsKeyUp(Up) && keyboardState.IsKeyUp(Down)) || (keyboardState.IsKeyDown(Up) && keyboardState.IsKeyDown(Down)))
                {
                    if (Velocity.Y > 0)
                    {
                        Velocity.Y += -Acceleration.Y * 3;
                        if (Velocity.Y < 0)
                            Velocity.Y = 0f;
                    }
                    else
                    {
                        Velocity.Y += Acceleration.Y * 3;
                        if (Velocity.Y > 0)
                            Velocity.Y = 0f;
                    }
                }
                else if (keyboardState.IsKeyDown(Up))
                {
                    if (Velocity.Y > 0)
                        Velocity.Y += -Acceleration.Y * 3;
                    else if (Velocity.Y > -maxspeed)
                        Velocity.Y += -Acceleration.Y;
                }
                else if (keyboardState.IsKeyDown(Down))
                {
                    if (Velocity.Y < 0)
                        Velocity.Y += Acceleration.Y * 3;
                    else if (Velocity.Y < maxspeed)
                        Velocity.Y += Acceleration.Y;
                }

                previousKeyboardState = keyboardState;

                Position += Velocity * speed;
            }
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
