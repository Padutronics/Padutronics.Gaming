namespace Padutronics.Gaming;

public sealed class GameExiter : IGameExiter
{
    public bool IsExitRequested { get; private set; }

    public void RequestExit()
    {
        IsExitRequested = true;
    }
}