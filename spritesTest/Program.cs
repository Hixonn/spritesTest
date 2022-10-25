using Raylib_cs;
using System.Numerics;

namespace spritesTest
{
    class Program
    {

        static void Main(string[] args)
        {
            Raylib.InitWindow(1920 / 2, 1080 / 2, "spritesTest");
            Raylib.SetTargetFPS(60);

            int scale = 5;

            Texture2D mort = Raylib.LoadTexture(@"mort.png");
            Sprite player = new Sprite(mort, 200, 100, scale, 4);

            Slider slider = new Slider(player.X, player.Y, 200, 70, 10, 5);

            while (Raylib.WindowShouldClose() == false)
            {
                Raylib.BeginDrawing();
                Raylib.ClearBackground(Color.BLUE);

                Action(player);

                slider.Bar = new Rectangle(player.hitBox.x - player.hitBox.width / 2 - 150, player.Y - 50, 300, 50);
                slider.Update();
                slider.Draw();


                Raylib.EndDrawing();
            }

            void Action(Sprite sprite, KeyboardKey right = KeyboardKey.KEY_A, KeyboardKey left = KeyboardKey.KEY_D, KeyboardKey up = KeyboardKey.KEY_W, KeyboardKey down = KeyboardKey.KEY_S)
            {
                if (Raylib.IsKeyDown(right) && !Raylib.IsKeyDown(left) || !Raylib.IsKeyDown(right) && Raylib.IsKeyDown(left) || (Raylib.IsKeyDown(down) && !Raylib.IsKeyDown(up) || !Raylib.IsKeyDown(down) && Raylib.IsKeyDown(up)))
                {
                    if (Raylib.IsKeyDown(KeyboardKey.KEY_LEFT_SHIFT))
                    {
                        sprite.Run();
                    }
                    else
                    {
                        sprite.Walk();
                    }
                }
                else
                {
                    sprite.Idle();
                }
            }
        }



    }
}