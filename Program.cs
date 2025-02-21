using Raylib_cs;
using TilingEnvironment;
using TilingEnvironment.States;

Raylib.SetConfigFlags(ConfigFlags.Msaa4xHint);
Raylib.InitWindow(Settings.Width, Settings.Height, "Tiling World");
Raylib.SetExitKey(KeyboardKey.Null);
Raylib.SetTargetFPS(Settings.TargetFPS);

var states = new Dictionary<GameState, IGameState>
{
    { GameState.Menu, new Menu() },
    { GameState.UnrestrictedPlayerMovement, new UnrestrictedPlayermovement() },
    { GameState.TiledPlayerMovement, new TiledPlayerMovement() },
};

var exit = false;
Settings.RequestedState = GameState.Menu;
while (!exit)
{
    if (Raylib.WindowShouldClose() || (Settings.RequestedState == GameState.Menu && Raylib.IsKeyPressed(KeyboardKey.Escape)))
        exit = true;
    else if (Raylib.IsKeyPressed(KeyboardKey.Escape))
        Settings.RequestedState = GameState.Menu;

    var currentState = states[Settings.RequestedState];

    currentState.Update();
    Raylib.BeginDrawing();
    Raylib.ClearBackground(Color.Gray);
    currentState.Draw();
    Raylib.EndDrawing();
}
foreach (var state in states.Values)
    state.Unload();
Raylib.CloseWindow();

