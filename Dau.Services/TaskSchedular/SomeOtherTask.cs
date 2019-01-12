using Dau.Services.Email;
using Dau.Services.TaskSchedular.Scheduling;
using System;
using System.Net;
using System.Net.Mail;
using System.Threading;
using System.Threading.Tasks;

namespace Dau.Services.TaskSchedular
{
    public class SomeOtherTask : IScheduledTask
    {
        private readonly IEmailService _emailService;

        public SomeOtherTask(IEmailService emailService)
        {
            _emailService = emailService;
        }

        public string Schedule => "*/1 * * * *";

        public async Task ExecuteAsync(CancellationToken cancellationToken)
        {

            _emailService.SendTestEmail();
              

        //    await Task.Delay(1, cancellationToken);
        }
    }
}