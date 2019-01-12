using System.Threading;
using System.Threading.Tasks;

namespace Dau.Services.TaskSchedular.Scheduling
{
    public interface IScheduledTask
    {
        string Schedule { get; }
        Task ExecuteAsync(CancellationToken cancellationToken);
    }
}