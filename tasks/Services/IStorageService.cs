using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace tasks.Services
{
    public interface IStorageService
    {
        Task<(bool IsSuccess, Exception exception)> InsertTaskAsync(Entities.Task task);

        Task<List<Entities.Task>> GetTasksAsync(Guid id = default(Guid),
            string title = default(string),
            string description = default(string),
            string tags = default(string),
            Entities.ETaskPriority? priority = null,
            Entities.ETaskRepeat? repeat = null,
            Entities.ETaskStatus? status = null,
            DateTimeOffset onADay = default(DateTimeOffset),
            DateTimeOffset atATime = default(DateTimeOffset),
            string location = default(string),
            string url = default(string));
    }
}