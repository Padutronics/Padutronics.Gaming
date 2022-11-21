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
        while (!gameExiter.IsExitRequested)
        {
        }
    }
}