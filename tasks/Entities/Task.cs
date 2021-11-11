using System;

namespace tasks.Entites
{
    public class Task
    {
        
        public Guid Id { get; set; }

        public string Tile { get; set; }

        public string Descriptione { get; set; }

        public string Tags { get; set; }

        public DateTimeOffset OnADaye { get; set; }
        public DateTimeOffset AtATime { get; set; }
        public ETaskStatus Status { get; set; }
        public ETaskRepeat Repeat { get; set; }
        public ETaskPriority Priority { get; set; }
        public string Location { get; set; }
        public string Url { get; set; }




        [Obsolete("Used only for entity binding", true)]
        public Task() { }
        
        public Task(string tile, string descriptione = "", string tags = "", DateTimeOffset onADaye = default(DateTimeOffset), DateTimeOffset atATime = default(DateTimeOffset), ETaskStatus status = ETaskStatus.None, ETaskRepeat repeat = ETaskRepeat.Never, ETaskPriority priority = ETaskPriority.None, string location = "", string url = "")
        {
            Id = Guid.NewGuid();
            Tile = tile;
            Descriptione = descriptione;
            Tags = tags;
            OnADaye = onADaye;
            AtATime = atATime;
            Status = status;
            Repeat = repeat;
            Priority = priority;
            Location = location;
            Url = url;

        }

    }
}