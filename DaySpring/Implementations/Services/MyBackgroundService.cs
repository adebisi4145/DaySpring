using DaySpring.Interfaces.Services;
using DaySpring.Models;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace DaySpring.Implementations.Services
{
    public class MyBackgroundService: BackgroundService
    {
        private readonly IServiceScopeFactory _serviceScopefactory;
        public MyBackgroundService(IServiceScopeFactory serviceScopefactory)
        {
            _serviceScopefactory = serviceScopefactory;
        }
        protected async override Task ExecuteAsync(CancellationToken token)
        {
            using var scope = _serviceScopefactory.CreateScope();
            var context = scope.ServiceProvider.GetRequiredService<DaySpringDbContext>();
            var announcementDueDate = scope.ServiceProvider.GetRequiredService<IAnnouncementService>();
            await announcementDueDate.DeleteAnnouncements();
            System.Console.WriteLine("Successfully Deleted");
            await Task.CompletedTask;
        }
    }
}
