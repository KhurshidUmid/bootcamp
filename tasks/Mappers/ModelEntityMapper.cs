namespace tasks.Mappers
{
    public static class ModelEntityMapper
    {
        public static Entities.Task ToTaskEntity(this Models.NewTask newTask)
        {
            return new Entities.Task(
                title: newTask.Title,
                description: newTask.Description,
                tags: newTask.Tags is null ? string.Empty : string.Join(',', newTask.Tags),
                location: newTask.Location is null ? string.Empty : string.Format($"{newTask.Location.Latitude},{newTask.Location.Longitude}"),
                atATime: newTask.AtATime,
                onADay: newTask.OnADay,
                repeat: newTask.Repeat.ToEntityETaskRepeat(),
                status: newTask.Status.ToEntityETaskStatus(),
                priority: newTask.Priority.ToEntityETaskPriority(),
                url: newTask.Url

            );
        }
    }
}