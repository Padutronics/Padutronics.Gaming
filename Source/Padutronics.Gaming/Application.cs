using Padutronics.Gaming.Bootstrapping;
using System.Collections.Generic;

using Trace = Padutronics.Diagnostics.Tracing.Trace<Padutronics.Gaming.Application>;

namespace Padutronics.Gaming;

public sealed class Application
{
    private readonly IEnumerable<IBootstrapper> bootstrappers;
    private readonly Game game;

    public Application(Game game, IEnumerable<IBootstrapper> bootstrappers)
    {
        this.bootstrappers = bootstrappers;
        this.game = game;
    }

    public void Run()
    {
        Trace.CallStart();

        foreach (IBootstrapper bootstrapper in bootstrappers)
        {
            bootstrapper.Run();
        }

        game.Run();

        Trace.CallEnd();
    }
}