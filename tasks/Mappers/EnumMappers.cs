namespace tasks.Mappers
{
    public static class EnumMappers
    {
        // public static Entities.ETaskPriority ToEntityETaskPriority(this Models.ETaskPriority? priority)
        public static Entities.ETaskPriority ToEntityETaskPriority(this Models.ETaskPriority priority)
        {
            return priority switch
            {
                Models.ETaskPriority.High => Entities.ETaskPriority.High,
                Models.ETaskPriority.Mid => Entities.ETaskPriority.Mid,
                Models.ETaskPriority.Low => Entities.ETaskPriority.Low,
                _ => Entities.ETaskPriority.None
            };
        }
        // public static Entities.ETaskStatus ToEntityETaskStatus(this Models.ETaskStatus? status)
        public static Entities.ETaskStatus ToEntityETaskStatus(this Models.ETaskStatus status)
        {
            return status switch
            {
                Models.ETaskStatus.Completed => Entities.ETaskStatus.Completed,
                Models.ETaskStatus.InProgress => Entities.ETaskStatus.InProgress,
                Models.ETaskStatus.Postponed => Entities.ETaskStatus.Postponed,
                _ => Entities.ETaskStatus.None
            };
        }
        // public static Entities.ETaskRepeat ToEntityETaskRepeat(this Models.ETaskRepeat? repeat)
        public static Entities.ETaskRepeat ToEntityETaskRepeat(this Models.ETaskRepeat repeat)
        {
            return repeat switch
            {
                Models.ETaskRepeat.Hourly  =>  Entities.ETaskRepeat.Hourly,
                Models.ETaskRepeat.Daily   =>  Entities.ETaskRepeat.Daily,
                Models.ETaskRepeat.Weekly  =>  Entities.ETaskRepeat.Weekly,
                Models.ETaskRepeat.Monthly =>  Entities.ETaskRepeat.Monthly,
                Models.ETaskRepeat.Yearly  =>  Entities.ETaskRepeat.Yearly,
                _ => Entities.ETaskRepeat.Never
            };
        }
        
    }
}