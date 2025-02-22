using Raylib_cs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace TilingEnvironment
{
    internal static class Utilities
    {
        public static  Vector2 BasicMovement(Vector2 playerposition)
        {
            if (Raylib.IsKeyDown(KeyboardKey.Up) || Raylib.IsKeyDown(KeyboardKey.W))
                playerposition -= Vector2.UnitY * Settings.TargetSpeed;
            if (Raylib.IsKeyDown(KeyboardKey.Down) || Raylib.IsKeyDown(KeyboardKey.S))
                playerposition += Vector2.UnitY * Settings.TargetSpeed;
            if (Raylib.IsKeyDown(KeyboardKey.Left) || Raylib.IsKeyDown(KeyboardKey.A))
                playerposition -= Vector2.UnitX * Settings.TargetSpeed;
            if (Raylib.IsKeyDown(KeyboardKey.Right) || Raylib.IsKeyDown(KeyboardKey.D))
                playerposition += Vector2.UnitX * Settings.TargetSpeed;
            return playerposition;
        }

        public static void DrawRectangle(float x, float y, float width, float height, Color color)
        {
            Raylib.DrawRectangle((int)x,(int)y,(int)width,(int)height,color);
        }

        public static void DrawCircle(float x, float y, float radius, Color color)
        {
            Raylib.DrawCircle((int)x, (int)y,radius, color);
        }

        public static void DrawLine(float x, float y, float endposx, float endposy, Color color)
        {
            Raylib.DrawLine((int)x, (int)y, (int)endposx, (int)endposy, color);
        }

    }
}
