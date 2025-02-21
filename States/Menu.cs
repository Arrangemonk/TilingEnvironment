using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Raylib_cs;

namespace TilingEnvironment.States
{
    internal class Menu : IGameState
    {
        public void Update()
        {
            if (Raylib.IsKeyPressed(KeyboardKey.One))
                Settings.RequestedState = GameState.UnrestrictedPlayerMovement;
            if (Raylib.IsKeyPressed(KeyboardKey.Two))
                Settings.RequestedState = GameState.TiledPlayerMovement;
        }

        public void Draw()
        {
            Raylib.DrawText("Unrestricted movevemt:\t1",10,10,20,Color.White);
            Raylib.DrawText("Tiled movement:\t2", 10, 40, 20, Color.White);
        }

        public void Unload()
        {
        }
    }
}
