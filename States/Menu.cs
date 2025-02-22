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
            if (Raylib.IsKeyPressed(KeyboardKey.Three))
                Settings.RequestedState = GameState.TiledPlayerMovementWithMovingEnvironment;
            
        }

        public void Draw()
        {
            const int lineheight = 30;
            Raylib.DrawText("1:\tUnrestricted movement"                 
                , 10, 10                 , 20, Color.White);
            Raylib.DrawText("2:\tTiled movement"
                , 10, 10 + lineheight    , 20, Color.White);
            Raylib.DrawText("3:\tTiled movement with Moving Environment"
                , 10, 10 + lineheight * 2, 20, Color.White);
        }

        public void Unload()
        {
        }
    }
}
