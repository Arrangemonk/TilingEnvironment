using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Raylib_cs;
using TilingEnvironment.States;



namespace TilingEnvironment
{
    enum GameState
    {
        Menu,
        UnrestrictedPlayerMovement,
        TiledPlayerMovement,
        TiledPlayerMovementWithMovingEnvironment,

    };
    internal class Settings
    {
        public static int Width { get; } = 800;
        public static int Height { get; } = 600;
        public static int TargetFPS { get; } = 60;
        public static int TargetSpeed { get; } = 5;

        public static int FieldSize = 400;
        public static GameState RequestedState { get; set; }

    }
}
