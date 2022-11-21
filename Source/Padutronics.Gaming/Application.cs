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
        game.Run();
    }
}