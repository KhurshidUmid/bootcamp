namespace tasks.Mappers
{
    public static class EnumMappers
    {
        
        public static Entities.ETaskPriority ToEntityETaskPriority(this Models.ETaskPriority? priority)
        {
            return priority switch
            {
                Models.ETaskPriority.High => Entities.ETaskPriority.High,
                Models.ETaskPriority.Mid => Entities.ETaskPriority.Mid,
                Models.ETaskPriority.Low => Entities.ETaskPriority.Low,
                _ => Entities.ETaskPriority.None
            };
        }
        
        public static Entities.ETaskStatus ToEntityETaskStatus(this Models.ETaskStatus? status)
        {
            return status switch
            {
                Models.ETaskStatus.Completed => Entities.ETaskStatus.Completed,
                Models.ETaskStatus.InProgress => Entities.ETaskStatus.InProgress,
                Models.ETaskStatus.Postponed => Entities.ETaskStatus.Postponed,
                _ => Entities.ETaskStatus.None
            };
        }
        
        public static Entities.ETaskRepeat ToEntityETaskRepeat(this Models.ETaskRepeat? repeat)
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








        // public static Models.ETaskPriority ToModelETaskPriority(this Entities.ETaskPriority? priority)
        public static Models.ETaskPriority ToModelETaskPriority(this Entities.ETaskPriority? priority)
        {
            return priority switch
            {
                Entities.ETaskPriority.High => Models.ETaskPriority.High,
                Entities.ETaskPriority.Mid  => Models.ETaskPriority.Mid,
                Entities.ETaskPriority.Low  => Models.ETaskPriority.Low,
                _ => Models.ETaskPriority.None
            };
        }
        // public static Models.ETaskStatus ToModelETaskStatus(this Entities.ETaskStatus? status)
        public static Models.ETaskStatus ToModelETaskStatus(this Entities.ETaskStatus? status)
        {
            return status switch
            {
                Entities.ETaskStatus.Completed => Models.ETaskStatus.Completed,
                Entities.ETaskStatus.InProgress => Models.ETaskStatus.InProgress,
                Entities.ETaskStatus.Postponed => Models.ETaskStatus.Postponed,
                _ => Models.ETaskStatus.None
            };
        }
        // public static Models.ETaskRepeat ToModelETaskRepeat(this Entities.ETaskRepeat? repeat)
        public static Models.ETaskRepeat ToModelETaskRepeat(this Entities.ETaskRepeat? repeat)
        {
            return repeat switch
            {
                Entities.ETaskRepeat.Hourly  =>  Models.ETaskRepeat.Hourly,
                Entities.ETaskRepeat.Daily   =>  Models.ETaskRepeat.Daily,
                Entities.ETaskRepeat.Weekly  =>  Models.ETaskRepeat.Weekly,
                Entities.ETaskRepeat.Monthly =>  Models.ETaskRepeat.Monthly,
                Entities.ETaskRepeat.Yearly  =>  Models.ETaskRepeat.Yearly,
                _ => Models.ETaskRepeat.Never
            };
        }
        
    }
}