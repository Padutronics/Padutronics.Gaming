using Padutronics.Gaming.Bootstrapping;
using System.Collections.Generic;
using System.Linq;

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

    private IEnumerable<IBootstrapper> OrderBootstrappers(IEnumerable<IBootstrapper> bootstrappers)
    {
        Trace.CallStart($"Ordering {bootstrappers.Count()} bootstrappers.");

        IEnumerable<IBootstrapper> orderedBootstrappers = bootstrappers
            .OrderBy(bootstrapper => bootstrapper.RunOrder)
            .ToList();

        Trace.CallEnd($"Bootstrappers in order: {string.Join(", ", orderedBootstrappers.Select(bootstrapper => bootstrapper.GetType()))}.");

        return orderedBootstrappers;
    }

    public void Run()
    {
        Trace.CallStart();

        IEnumerable<IBootstrapper> orderedBootstrappers = OrderBootstrappers(bootstrappers);
        foreach (IBootstrapper bootstrapper in orderedBootstrappers)
        {
            bootstrapper.Run();
        }

        game.Run();

        Trace.CallEnd();
    }
}