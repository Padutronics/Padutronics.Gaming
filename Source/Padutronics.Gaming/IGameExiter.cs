namespace Padutronics.Gaming;

public interface IGameExiter
{
    bool IsExitRequested { get; }

    void RequestExit();
}