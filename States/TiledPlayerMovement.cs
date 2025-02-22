using System.Numerics;
using Raylib_cs;

namespace TilingEnvironment.States
{
    internal class TiledPlayerMovement : IGameState
    {
        private Vector2 playerposition = new(Settings.FieldSize / 2f, Settings.FieldSize / 2f);
        public void Update()
        {
            playerposition = Utilities.BasicMovement(playerposition);
            playerposition = new Vector2((playerposition.X + Settings.FieldSize )% Settings.FieldSize
                , (playerposition.Y + Settings.FieldSize) % Settings.FieldSize);
        }

        public void Draw()
        {
            Raylib.DrawRectangle(Settings.Width / 2 - (Settings.FieldSize / 2),
                Settings.Height / 2 - (Settings.FieldSize / 2),
                Settings.FieldSize, Settings.FieldSize, Color.Blue);
            Raylib.DrawLine(Settings.Width / 2, 0, Settings.Width / 2, Settings.Height, Color.Black);
            Raylib.DrawLine(0, Settings.Height / 2, Settings.Width, Settings.Height / 2, Color.Black);
            Raylib.DrawCircle(Settings.Width / 2 - Settings.FieldSize/2 + (int)playerposition.X,
                Settings.Height / 2 - Settings.FieldSize / 2 + (int)playerposition.Y, 10, Color.Black);
            Raylib.DrawCircle(Settings.Width / 2 - Settings.FieldSize / 2 + (int)playerposition.X,
                Settings.Height / 2 - Settings.FieldSize / 2 + (int)playerposition.Y, 8, Color.Red);
            Raylib.DrawText("ESC:\tBack to Menu", 10, 10, 20, Color.White);
        }
        public void Unload()
        {
        }
    }
}

