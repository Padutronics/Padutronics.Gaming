using Padutronics.Gaming.Frames.Runners;
using System.Collections.Generic;

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

    public void Run()
    {
        Trace.CallStart();

        while (!gameExiter.IsExitRequested)
        {
            foreach (IFrameRunner frameRunner in frameRunners)
            {
                frameRunner.Run();
            }
        }

        Trace.CallEnd();
    }
}