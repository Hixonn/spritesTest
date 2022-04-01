using Raylib_cs;
using System.Numerics;

namespace spritesTest
{
    class Program
    {
        static void Main(string[] args)
        {
            Texture2D sheet = Raylib.LoadTexture(@"mort.png");

            Sprite player = new Sprite(sheet, 100, 100);



            Raylib.InitWindow(1920 / 2, 1080 / 2, "spritesTest");
            Raylib.SetTargetFPS(5);

            while (Raylib.WindowShouldClose() == false)
            {

                Raylib.BeginDrawing();
                Raylib.ClearBackground(Color.BLACK);

                player.Idle();

                Raylib.EndDrawing();
            }
        }
    }
}