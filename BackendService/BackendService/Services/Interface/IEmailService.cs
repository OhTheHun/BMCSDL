using System.Threading;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace BackendService.Services.Interface
{
    public interface IEmailService
    {
        Task SendAsync(string to, string subject, string html, List<string>? files = null, CancellationToken cancellationToken = default);
    }
}
