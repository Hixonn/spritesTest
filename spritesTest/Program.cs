using Raylib_cs;
using System.Numerics;

namespace spritesTest
{
    class Program
    {
        static void Main(string[] args)
        {



            Raylib.InitWindow(1920 / 2, 1080 / 2, "spritesTest");
            Raylib.SetTargetFPS(10);

            Texture2D poo = Raylib.LoadTexture(@"mort.png");
            Sprite player = new Sprite(poo, 200, 100);

            while (Raylib.WindowShouldClose() == false)
            {

                Raylib.BeginDrawing();
                Raylib.ClearBackground(Color.BLACK);


                if (Raylib.IsKeyDown(KeyboardKey.KEY_RIGHT) && !Raylib.IsKeyDown(KeyboardKey.KEY_LEFT) || !Raylib.IsKeyDown(KeyboardKey.KEY_RIGHT) && Raylib.IsKeyDown(KeyboardKey.KEY_LEFT))
                {
                    if (Raylib.IsKeyDown(KeyboardKey.KEY_LEFT_SHIFT))
                    {
                        player.Run();
                    }
                    else
                    {
                        player.Walk();
                    }
                }
                else if (Raylib.IsKeyDown(KeyboardKey.KEY_RIGHT) && Raylib.IsKeyDown(KeyboardKey.KEY_LEFT))
                {
                    player.Stare();
                }
                else
                {
                    player.Idle();
                }




                Raylib.EndDrawing();
            }
        }


    }
}