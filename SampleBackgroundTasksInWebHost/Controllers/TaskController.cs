using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace SampleBackgroundTasksInWebHost.Controllers
{
    //[Route("task")]
    public class TaskController: Controller
    {
        //[Route("addtask")]
        public string addTask(){
            /*
            Queue.QueueBackgroundWorkItem(async token =>
            {
                var guid = Guid.NewGuid().ToString();

                using (var scope = _serviceScopeFactory.CreateScope())
                {
                    var scopedServices = scope.ServiceProvider;
                    var db = scopedServices.GetRequiredService<AppDbContext>();

                    for (int delayLoop = 1; delayLoop < 4; delayLoop++)
                    {
                        try
                        {
                            db.Messages.Add(
                                new Message() 
                                { 
                                    Text = $"Queued Background Task {guid} has " +
                                        $"written a step. {delayLoop}/3"
                                });
                            await db.SaveChangesAsync();
                        }
                        catch (Exception ex)
                        {
                            _logger.LogError(ex, 
                                "An error occurred writing to the " +
                                $"database. Error: {ex.Message}");
                        }

                        await Task.Delay(TimeSpan.FromSeconds(5), token);
                    }
                }

                _logger.LogInformation(
                    $"Queued Background Task {guid} is complete. 3/3");
            });
             */
            return "add success";
        }
    }
}