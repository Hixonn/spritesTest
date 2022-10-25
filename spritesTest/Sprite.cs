using Raylib_cs;
using System;
using System.Numerics;
using System.Timers;
using System.Threading;

// Vector2 dinoPosition;
// Vector2 mousePosition;

// Vector2 direction = mousePosition - dinoPosition;

// float speed = 4;
// direction = Vector2.Normalize(direction) * speed;

// Vector2 projectilePosition;

// projectilePosition += direction;

// projectilePosition.X += direction.X;
// projectilePosition.Y += direction.Y;


namespace spritesTest
{
    public class Sprite
    {
        Texture2D pic;
        public float X { get; set; }
        public float Y { get; set; }
        int scale;
        int globalDelay;
        int onFrame;
        int dirX = 1;
        int dirY = 1;
        public Rectangle hitBox;


        public Sprite(Texture2D _pic, int _x, int _y, int _scale, int _globalDelay = 0)
        {
            pic = _pic;
            X = _x;
            Y = _y;
            scale = _scale;
            globalDelay = _globalDelay;
        }




        public bool DirectionX()
        {
            if (Raylib.IsKeyDown(KeyboardKey.KEY_A) && !Raylib.IsKeyDown(KeyboardKey.KEY_D)) { dirX = -1; return true; }
            else if (Raylib.IsKeyDown(KeyboardKey.KEY_D) && !Raylib.IsKeyDown(KeyboardKey.KEY_A)) { dirX = 1; return true; }
            else return false;
        }
        public bool DirectionY()
        {
            if (Raylib.IsKeyDown(KeyboardKey.KEY_W) && !Raylib.IsKeyDown(KeyboardKey.KEY_S)) { dirY = -1; return true; }
            else if (!Raylib.IsKeyDown(KeyboardKey.KEY_W) && Raylib.IsKeyDown(KeyboardKey.KEY_S)) { dirY = 1; return true; }
            else return false;
        }



        public void DisplayAnimFrame(Texture2D _pic, int dx, int dy, int spriteID, int w = 24, int h = 24)
        {
            int x = (spriteID % w) * w;
            int y = (spriteID / w) * w;

            DirectionX();
            DirectionY();

            Rectangle source = new Rectangle(x, y, w * dirX, h);
            Rectangle dest = new Rectangle(dx + (source.width * dirX), dy, w * scale, h * scale);
            hitBox = new Rectangle(dest.x + 50, dest.y + 40, dest.width - 100, dest.height - 55);
            Raylib.DrawTexturePro(pic, source, dest, Vector2.Zero, 0.0f, Color.WHITE);
            Raylib.DrawRectangleRec(hitBox, Color.RED);
        }

        int timesDisplayed = 0;
        bool nextFrame;
        public void AnimPlay(int startFrame, int endFrame, int _speed, int delayTimes)
        {

            if (timesDisplayed == delayTimes)
            {
                nextFrame = true;
                timesDisplayed = 0;
            }
            else if (timesDisplayed > delayTimes)
            {
                timesDisplayed = delayTimes;
            }
            else
            {
                nextFrame = false;
                timesDisplayed++;
            }


            if (startFrame == endFrame)
            {
                onFrame = startFrame;

            }
            else if (nextFrame == true)
            {
                if (onFrame < startFrame || onFrame > endFrame)
                {

                    onFrame = startFrame;


                }
                else if (onFrame < endFrame && onFrame > startFrame || onFrame == startFrame)
                {

                    onFrame++;

                }
                else if (onFrame == endFrame)
                {
                    onFrame = startFrame;

                }
            }

            if (_speed * dirX + hitBox.x >= 0 && _speed * dirX + hitBox.width + hitBox.x <= Raylib.GetScreenWidth())
            {
                if (DirectionX() == true) X += _speed * dirX;
            }
            else
            {
                if (dirX == -1)
                {
                    X += hitBox.x * dirX;
                }
                else if (dirX == 1)
                {
                    X -= hitBox.x + hitBox.width - Raylib.GetScreenWidth();
                }
            }

            if (_speed * dirY + hitBox.y >= 0 && _speed * dirY + hitBox.height + hitBox.y <= Raylib.GetScreenHeight() + 5)
            {
                if (DirectionY() == true) Y += _speed * dirY;
            }
            else
            {
                if (dirY == -1)
                {
                    Y += hitBox.y * dirY;
                }
                else if (dirY == 1)
                {
                    Y -= hitBox.y + hitBox.height - Raylib.GetScreenHeight();
                }
            }

            DisplayAnimFrame(pic, Convert.ToInt32(X), Convert.ToInt32(Y), onFrame);
        }



        public void Idle(int _speed = 0)
        {
            AnimPlay(0, 3, _speed * scale, 7);
        }
        public void Walk(int _speed = 2)
        {
            AnimPlay(4, 9, _speed + scale, globalDelay);
        }
        public void Run(int _speed = 3)
        {
            AnimPlay(18, 23, _speed + scale, 2);
        }
        public void Sneak(int _speed = 0)
        {
            AnimPlay(17, 17, _speed, globalDelay);
        }
        public void Stare(int _speed = 0)
        {
            AnimPlay(24, 24, _speed * scale, globalDelay);
        }
        public void Kick(int _speed = 0)
        {
            AnimPlay(10, 13, _speed * scale, globalDelay);
        }


    }
}