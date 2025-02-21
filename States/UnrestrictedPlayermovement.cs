using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using Raylib_cs;

namespace TilingEnvironment.States
{
    internal class UnrestrictedPlayermovement : IGameState
    {
        private Vector2 playerposition = new(Settings.FieldSize/2f, Settings.FieldSize / 2f);
        public void Update()
        {
            playerposition = Utilities.BasicMovement(playerposition);
        }

        public void Draw()
        {
            Raylib.DrawText("Back to Menu:\tESC", 10, 10, 20, Color.White);
            Raylib.DrawRectangle(Settings.Width/2 - (Settings.FieldSize / 2), Settings.Height/2 -(Settings.FieldSize/2), Settings.FieldSize, Settings.FieldSize, Color.Blue);
            Raylib.DrawLine(Settings.Width / 2,                   0, Settings.Width/ 2,     Settings.Height,Color.Black);
            Raylib.DrawLine(                 0, Settings.Height / 2, Settings.Width   , Settings.Height / 2, Color.Black);
            Raylib.DrawCircle(Settings.Width / 2 - Settings.FieldSize / 2 + (int)playerposition.X,
                Settings.Height / 2 - Settings.FieldSize / 2 + (int)playerposition.Y, 10, Color.Black);
            Raylib.DrawCircle(Settings.Width / 2 - Settings.FieldSize / 2 + (int)playerposition.X,
                Settings.Height / 2 - Settings.FieldSize / 2 + (int)playerposition.Y, 8, Color.Red);
        }
        public void Unload()
        {
        }
    }
}
