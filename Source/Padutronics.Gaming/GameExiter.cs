using Trace = Padutronics.Diagnostics.Tracing.Trace<Padutronics.Gaming.GameExiter>;

namespace Padutronics.Gaming;

public sealed class GameExiter : IGameExiter
{
    public bool IsExitRequested { get; private set; }

    public void RequestExit()
    {
        Trace.Call();

        IsExitRequested = true;
    }
}