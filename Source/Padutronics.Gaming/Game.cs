using Padutronics.Gaming.Frames.Runners;
using System.Collections.Generic;
using System.Linq;

using Trace = Padutronics.Diagnostics.Tracing.Trace<Padutronics.Gaming.Game>;

namespace Padutronics.Gaming;

public sealed class Game
{
    private readonly IEnumerable<IFrameRunner> frameRunners;
    private readonly IGameExiter gameExiter;

    public Game(IGameExiter gameExiter, IEnumerable<IFrameRunner> frameRunners)
    {
        this.frameRunners = frameRunners;
        this.gameExiter = gameExiter;
    }

    private IEnumerable<IFrameRunner> OrderFrameRunners(IEnumerable<IFrameRunner> frameRunners)
    {
        Trace.CallStart($"Ordering {frameRunners.Count()} frame runners.");

        IEnumerable<IFrameRunner> orderedFrameRunners = frameRunners
            .OrderBy(frameRunner => frameRunner.RunOrder)
            .ToList();

        Trace.CallEnd($"Frame runners in order: {string.Join(", ", orderedFrameRunners.Select(frameRunner => frameRunner.GetType()))}.");

        return orderedFrameRunners;
    }

    public void Run()
    {
        Trace.CallStart();

        IEnumerable<IFrameRunner> orderedFrameRunners = OrderFrameRunners(frameRunners);

        while (!gameExiter.IsExitRequested)
        {
            foreach (IFrameRunner frameRunner in orderedFrameRunners)
            {
                frameRunner.Run();
            }
        }

        Trace.CallEnd();
    }
}