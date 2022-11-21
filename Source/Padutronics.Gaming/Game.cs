using Trace = Padutronics.Diagnostics.Tracing.Trace<Padutronics.Gaming.Game>;

namespace Padutronics.Gaming;

public sealed class Game
{
    private readonly IGameExiter gameExiter;

    public Game(IGameExiter gameExiter)
    {
        this.gameExiter = gameExiter;
    }

    public void Run()
    {
        Trace.CallStart();

        while (!gameExiter.IsExitRequested)
        {
        }

        Trace.CallEnd();
    }
}