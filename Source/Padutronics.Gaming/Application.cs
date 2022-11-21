using Trace = Padutronics.Diagnostics.Tracing.Trace<Padutronics.Gaming.Application>;

namespace Padutronics.Gaming;

public sealed class Application
{
    private readonly Game game;

    public Application(Game game)
    {
        this.game = game;
    }

    public void Run()
    {
        Trace.CallStart();

        game.Run();

        Trace.CallEnd();
    }
}