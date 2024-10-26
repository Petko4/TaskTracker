namespace TaskTracker
{
    internal class TaskManager
    {
        private List<Task> _tasks;
        private PersistentIdGenerator _persistentIdGenerator;
        private TaskFileStorage _taskFileStorage;

        public TaskManager(PersistentIdGenerator idGenerator, TaskFileStorage taskRepository) 
        { 
            _persistentIdGenerator = idGenerator;
            _taskFileStorage = taskRepository;
            var tasks = taskRepository.LoadTasksFromJSONFile();
            _tasks = tasks != null ? tasks : new List<Task>();
        }


        public int AddTask(string description)
        {
            int id = _persistentIdGenerator.GetNewId();
            var task = new Task(id, description, Status.Todo, DateTime.Now, DateTime.Now);
            _tasks.Add(task);
            _taskFileStorage.SaveTasks(_tasks);

            return id;
        }

        public void DeleteTask(int id) 
        {

            var task = _tasks.Find(task => task.Id == id);
            if (task == null)
                throw new Exception(string.Format(Messages.TaskNotFound, id));

            _tasks.Remove(task);
            _taskFileStorage.SaveTasks(_tasks);
        }

        public void UpdateTaskDescription(int id, string descripton)
        {
            var task = _tasks.Find(task => task.Id == id);
            if (task == null)
                throw new Exception(string.Format(Messages.TaskNotFound, id));
            task.Description = descripton;
            _taskFileStorage.SaveTasks(_tasks);
        }

        public void UpdateTaskStatus(int id, Status status)
        {
            var task = _tasks.Find(task => task.Id == id);
            if (task == null) 
                throw new Exception(string.Format(Messages.TaskNotFound, id));
            task.Status = status;
            _taskFileStorage.SaveTasks(_tasks);
        }

        public List<Task> GetTasks() {
            return _tasks;
        }

        public List<Task> GetTasks(Status status)
        {
            var filterTasks = new List<Task>();

            foreach (var task in _tasks)
            {
                if (task.Status == status)
                    filterTasks.Add(task);
            }

            return filterTasks;
        }
    }
}
