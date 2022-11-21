using Padutronics.Gaming.Ordering;

namespace Padutronics.Gaming.Frames.Runners;

public interface IFrameRunner
{
    Order RunOrder { get; }

    void Run();
}