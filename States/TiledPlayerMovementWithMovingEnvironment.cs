using System.Numerics;
using Raylib_cs;

namespace TilingEnvironment.States
{
    internal class TiledPlayerMovementWithMovingEnvironment : IGameState
    {
        private Vector2 playerposition = new(Settings.FieldSize * .5f, Settings.FieldSize * .5f);
        private Vector2 direction = new(0, 0);
        private int horizontalsector = 0;
        private int verticalsector = 0;
        private bool safezoneX = true;
        private bool safezoneY = true;

        private Vector2 offset00 = Vector2.Zero;
        private Vector2 offset01 = Vector2.Zero;
        private Vector2 offset10 = Vector2.Zero;
        private Vector2 offset11 = Vector2.Zero;

        public void Update()
        {
            var oldpos = playerposition;
            playerposition = Utilities.BasicMovement(playerposition);
            direction = new Vector2(Math.Sign(playerposition.X - oldpos.X), Math.Sign(playerposition.Y - oldpos.Y));

            playerposition = new Vector2((playerposition.X + Settings.FieldSize) % Settings.FieldSize
                , (playerposition.Y + Settings.FieldSize) % Settings.FieldSize);

            horizontalsector = Math.Sign(playerposition.X - Settings.FieldSize * .5f);
            verticalsector = Math.Sign(playerposition.Y - Settings.FieldSize * .5f);

            safezoneX = Settings.FieldSize *.25< playerposition.X && playerposition.X < Settings.FieldSize * .75f;
            safezoneY = Settings.FieldSize * .25 < playerposition.Y && playerposition.Y < Settings.FieldSize * .75f;

            if (safezoneX && 0 < horizontalsector)
            {
                offset00.X = 0;
                offset10.X = 0;
            }
            if (safezoneX && 0 > horizontalsector)
            {
                offset01.X = 0;
                offset11.X = 0;
            }
            if (safezoneY && 0 < verticalsector)
            {
                offset00.Y = 0;
                offset01.Y = 0;
            }
            if (safezoneY && 0 > verticalsector)
            {
                offset10.Y = 0;
                offset11.Y = 0;
            }
            if (!safezoneX && direction.X != 0)
            {
                var leftxoffset = 0 < horizontalsector //&& 0 < direction.X
                    ? Settings.FieldSize
                    : 0;

                offset00.X = leftxoffset;
                offset10.X = leftxoffset;

                var rightxoffset = 0 > horizontalsector //&& 0 > direction.X
                    ? -Settings.FieldSize
                    :0;

                offset01.X = rightxoffset;
                offset11.X = rightxoffset;
            }
            if (!safezoneY && direction.Y != 0)
            {
                var upperyoffset = 0 < verticalsector //&& 0 < direction.Y
                    ? Settings.FieldSize
                    : 0;

                offset00.Y = upperyoffset;
                offset01.Y = upperyoffset;

                var loweryoffset = 0 > verticalsector //&& 0 > direction.Y
                    ? - Settings.FieldSize
                    : 0;

                offset10.Y = loweryoffset;
                offset11.Y = loweryoffset;
            }
        }

        public void Draw()
        {
            Utilities.DrawRectangle(Settings.Width * .5f - (Settings.FieldSize * .5f) + (int)offset00.X,
                Settings.Height * .5f - (Settings.FieldSize * .5f) + (int)offset00.Y,
                Settings.FieldSize * .5f, Settings.FieldSize * .5f, Color.Blue);

            Utilities.DrawRectangle(Settings.Width * .5f + (int)offset01.X,
                Settings.Height * .5f - (Settings.FieldSize * .5f) + (int)offset01.Y,
                Settings.FieldSize * .5f, Settings.FieldSize * .5f, Color.Green);

            Utilities.DrawRectangle(Settings.Width * .5f - (Settings.FieldSize * .5f) + (int)offset10.X,
                Settings.Height * .5f + (int)offset10.Y,
                Settings.FieldSize * .5f, Settings.FieldSize * .5f, Color.Purple);

            Utilities.DrawRectangle(Settings.Width * .5f + (int)offset11.X,
                Settings.Height * .5f + (int)offset11.Y,
                Settings.FieldSize * .5f, Settings.FieldSize * .5f, Color.Pink);

            //safe zone
            Utilities.DrawRectangle(Settings.Width * .5f - (Settings.FieldSize * .25f),
                Settings.Height * .5f - (Settings.FieldSize * .25f),
                Settings.FieldSize * .5f, Settings.FieldSize * .5f, new Color(1f, 1f, 0f, 0.3f));




            Utilities.DrawLine(Settings.Width * .5f, 0, Settings.Width * .5f, Settings.Height, Color.Black);
            Utilities.DrawLine(0, Settings.Height * .5f, Settings.Width, Settings.Height * .5f, Color.Black);
            Utilities.DrawCircle(Settings.Width * .5f - Settings.FieldSize * .5f + (int)playerposition.X,
                Settings.Height * .5f - Settings.FieldSize * .5f + (int)playerposition.Y, 10, Color.Black);
            Utilities.DrawCircle(Settings.Width * .5f - Settings.FieldSize * .5f + (int)playerposition.X,
                Settings.Height * .5f - Settings.FieldSize * .5f + (int)playerposition.Y, 8, Color.Red);

            const int lineheight = 40;
            Raylib.DrawText("ESC:\tBack to Menu", 10, 10, 20, Color.White);
            //Debug Display
            //Raylib.DrawText($"position  hoz:{playerposition.X} vert:{playerposition.Y}", 10, 10 + lineheight, 20, Color.White);
            //Raylib.DrawText($"Sector    hoz:{horizontalsector} vert:{verticalsector}", 10, 10 + lineheight * 2, 20, Color.White);
            //Raylib.DrawText($"direction hoz:{direction.X} vert:{direction.Y}", 10, 10 + lineheight * 3, 20, Color.White);
            //Raylib.DrawText($"savezone hoz:{safezoneX} vert:{safezoneY}", 10, 10 + lineheight * 4, 20, Color.White);
        }
        public void Unload()
        {
        }
    }
}