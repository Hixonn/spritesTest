using Raylib_cs;
using System.Numerics;
using System.Timers;
using System.Threading;

namespace spritesTest
{
    public class Sprite
    {
        Texture2D pic;
        int x;
        int y;
        int onFrame;
        int f = 1;


        public Sprite(Texture2D _pic, int _x, int _y)
        {
            pic = _pic;
            x = _x;
            y = _y;
        }

        public void DisplayAnimFrame(Texture2D _pic, int dx, int dy, int spriteID, int w = 24, int h = 24)
        {
            if (Raylib.IsKeyDown(KeyboardKey.KEY_LEFT)) f = -1;
            else if (Raylib.IsKeyDown(KeyboardKey.KEY_RIGHT)) f = 1;


            int x = (spriteID % w) * w;
            int y = (spriteID / w) * w;
            Rectangle source = new Rectangle(x, y, w * f, h);
            Rectangle dest = new Rectangle(dx, dy, w * 20, h * 20);
            Raylib.DrawTexturePro(pic, source, dest, Vector2.Zero, 0.0f, Color.WHITE);
        }

        public void AnimPlay(int startFrame, int endFrame)
        {
            if (startFrame == endFrame)
            {
                onFrame = startFrame;
                System.Console.WriteLine(onFrame);
            }
            else if (onFrame < startFrame || onFrame > endFrame)
            {
                onFrame = startFrame;
                System.Console.WriteLine(onFrame);
            }
            else if (onFrame < endFrame && onFrame > startFrame || onFrame == startFrame)
            {
                onFrame++;
                System.Console.WriteLine(onFrame);
            }
            else if (onFrame == endFrame)
            {
                onFrame = startFrame;
                System.Console.WriteLine(onFrame);
            }
            DisplayAnimFrame(pic, x, y, onFrame);
        }


        public void Idle()
        {
            AnimPlay(0, 3);
        }
        public void Walk()
        {
            AnimPlay(4, 9);
        }

        public void Run()
        {
            AnimPlay(18, 23);
        }
        public void Stare()
        {
            AnimPlay(24, 24);
        }
    }
}