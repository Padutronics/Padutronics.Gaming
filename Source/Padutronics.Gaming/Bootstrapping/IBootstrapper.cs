using Padutronics.Gaming.Ordering;

namespace Padutronics.Gaming.Bootstrapping;

public interface IBootstrapper
{
    Order RunOrder { get; }

    void Run();
}