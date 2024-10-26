using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace TaskTracker
{
    internal class Task
    {
        public int Id { get; private set; }
        public string Description { get; set; }

        private Status _status;
        public Status Status
        {
            get { return _status; }
            set { if (_status != value)
                {
                    _status = value;
                    UpdatedAt = DateTime.Now;
                }
            }
        }

        public DateTime CreatedAt { get; private set;}
        public DateTime UpdatedAt { get; private set;}

        public Task(int id, string description, Status status, DateTime CreatedAt, DateTime UpdatedAt)
        {
            Id = id;
            Description = description;
            _status = status;
            CreatedAt = DateTime.Now;
            UpdatedAt = DateTime.Now;
        }

        public override string ToString()
        {
            string status = "";
            if (Status == Status.Todo)
                status = "to-do";
            if (Status == Status.InProgress)
                status = "in-progress";
            if (Status == Status.Done)
                status = "done";

            return $"{Id}  {status}\t{Description}";
        }
    }

    enum Status
    {
        Todo,
        InProgress,
        Done,
    }
}
