using Raylib_cs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace TilingEnvironment
{
    internal class Utilities
    {
        public static  Vector2 BasicMovement(Vector2 playerposition)
        {
            if (Raylib.IsKeyDown(KeyboardKey.Up) || Raylib.IsKeyDown(KeyboardKey.W))
                playerposition = playerposition - Vector2.UnitY * 5;
            if (Raylib.IsKeyDown(KeyboardKey.Down) || Raylib.IsKeyDown(KeyboardKey.S))
                playerposition = playerposition + Vector2.UnitY * 5;
            if (Raylib.IsKeyDown(KeyboardKey.Left) || Raylib.IsKeyDown(KeyboardKey.A))
                playerposition = playerposition - Vector2.UnitX * 5;
            if (Raylib.IsKeyDown(KeyboardKey.Right) || Raylib.IsKeyDown(KeyboardKey.D))
                playerposition = playerposition + Vector2.UnitX * 5;
            return playerposition;
        }
    }
}
