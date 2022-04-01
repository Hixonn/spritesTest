using Raylib_cs;
using System.Numerics;

namespace spritesTest
{
    public class Sprite
    {
        Texture2D pic;
        int x;
        int y;
        int startFrame;
        int endFrame;
        int onFrame;

        public Sprite(Texture2D _pic, int _x, int _y)
        {
            pic = _pic;
            x = _x;
            y = _y;
        }

        public void DisplayAnimFrame(Texture2D pic, int dx, int dy, int spriteID, int w = 24, int h = 24)
        {
            int x = (spriteID % w) * w;
            int y = (spriteID / w) * w;
            Rectangle source = new Rectangle(x, y, w, h);
            Rectangle dest = new Rectangle(dx, dy, w, h);
            Raylib.DrawTexturePro(pic, source, dest, Vector2.Zero, 0.0f, Color.WHITE);
        }

        public void AnimPlay(int startFrame, int endFrame)
        {
            onFrame = startFrame;

            if (onFrame < endFrame)
            {
                onFrame++;
            }
            else
            {
                onFrame = startFrame;
            }
            DisplayAnimFrame(pic, x, y, onFrame);
        }

        public void Idle()
        {
            AnimPlay(0, 3);
        }
        public void Run()
        {
            AnimPlay(4, 10);
        }


    }
}