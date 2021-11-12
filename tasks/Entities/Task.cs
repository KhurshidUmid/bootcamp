using System;

namespace tasks.Entities
{
    public class Task
    {
        
        public Guid Id { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public string Tags { get; set; }

        public DateTimeOffset OnADay { get; set; }
        public DateTimeOffset AtATime { get; set; }
        public ETaskStatus? Status { get; set; }
        public ETaskRepeat? Repeat { get; set; }
        public ETaskPriority? Priority { get; set; }
        public string Location { get; set; }
        public string Url { get; set; }




        [Obsolete("Used only for entity binding", true)]
        public Task() { }
        
        public Task(string title, string description = "", string tags = "", DateTimeOffset onADay = default(DateTimeOffset), DateTimeOffset atATime = default(DateTimeOffset), ETaskStatus status = ETaskStatus.None, ETaskRepeat repeat = ETaskRepeat.Never, ETaskPriority priority = ETaskPriority.None, string location = "", string url = "")
        {
            Id = Guid.NewGuid();
            Title = title;
            Description = description;
            Tags = tags;
            OnADay = onADay;
            AtATime = atATime;
            Status = status;
            Repeat = repeat;
            Priority = priority;
            Location = location;
            Url = url;

        }

    }
}