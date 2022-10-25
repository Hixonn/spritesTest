using System;
using Raylib_cs;

namespace spritesTest
{
    public class Projectile
    {
        public float X { get; set; }
        public float Y { get; set; }
        public float destX { get; set; }
        public float destY { get; set; }
        public float size = 20;
        public Rectangle bullet;
        public float incX;
        public float incY;
        public bool init = false;
        public bool inbound;
        public void Init(Sprite sprite)
        {
            bullet = new Rectangle(sprite.hitBox.x - sprite.hitBox.width / 2 - size / 2, sprite.hitBox.y - 20, size, size);
            destX = Raylib.GetMouseX();
            destY = Raylib.GetMouseY();



            incX = destX - bullet.x;
            incY = destY - bullet.y;

            init = true;
        }

        public void Draw()
        {
            System.Console.WriteLine($"incX :{incX} incY: {incY}");
            Raylib.DrawRectangleRec(bullet, Color.RED);
        }


        public bool Inbound()
        {
            if (bullet.x < Raylib.GetScreenWidth() && bullet.x > 0 && bullet.y < Raylib.GetScreenHeight() && bullet.y > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}