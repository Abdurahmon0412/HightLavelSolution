

namespace BackroundServices.BackroundServices;

public class BackroundServiceIHostService : IHostedLifecycleService
{
    public Task StartAsync(CancellationToken cancellationToken)
    {
        Console.WriteLine("My second servivce is start ");
        return Task.CompletedTask;
    }

    public Task StartedAsync(CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public Task StartingAsync(CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public Task StopAsync(CancellationToken cancellationToken)
    {
        Console.WriteLine("Backround service ended");

        return Task.CompletedTask;
    }

    public Task StoppedAsync(CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public Task StoppingAsync(CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
