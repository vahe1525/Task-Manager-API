
using Task_Manager_API.Services;

namespace Task_Manager_API.Background
{
    public class TTLService : IHostedService
    {
        private readonly IServiceScopeFactory _scope;
        public TTLService(IServiceScopeFactory scope)
        {
            _scope = scope;
        }
        public async Task StartAsync(CancellationToken cancellationToken)
        {
            await Task.Factory.StartNew(async () =>
            {
                while (!cancellationToken.IsCancellationRequested)
                {
                    using var scope = _scope.CreateScope();
                    var taskServie = scope.ServiceProvider.GetRequiredService<TaskService>();
                    var tasks = await taskServie.GetAllTasksAsync();
                    foreach (var task in tasks)
                    {
                        if ((DateTime.UtcNow - task.DeadLine) > TimeSpan.FromSeconds(1) && task.Status!=Models.StatusItem.Completed)
                        {
                            await taskServie.CompleteTaskAsync(task.Id);
                        }
                    }
                    await Task.Delay(1000);
                }
            });
        }

        public async Task StopAsync(CancellationToken cancellationToken)
        {
        }
    }
}
