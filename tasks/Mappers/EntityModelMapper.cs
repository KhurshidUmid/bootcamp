using System;

namespace tasks.Mappers
{
    public static class EntityModelMapper
    {
        // public static Models.Task ToTaskModel(this Entities.Task task)
        // {
        //     return new Models.Task(
        //         title: task.Title,
        //         description: task.Description,
        //         tags: task.Tags is null ? string.Empty : string.Split(',', StringSplitOptions.RemoveEmptyEntries, task.Tags),
        //         location: task.Location is null ? string.Empty : string.Format($"{task.Location.Latitude},{task.Location.Longitude}"),
        //         atATime: task.AtATime,
        //         onADay: task.OnADay,
        //         repeat: task.Repeat.ToModelETaskRepeat(),
        //         status: task.Status.ToModelETaskStatus(),
        //         priority: task.Priority.ToModelETaskPriority(),
        //         url: task.Url

        //     );
        // }
    }
}