using TaskTracker;

const string ID_FILE_PATH = "lastId.txt";
const string TASKS_FILE_PATH = "tasks.json";

PersistentIdGenerator idGenerator = new PersistentIdGenerator(ID_FILE_PATH);
TaskFileStorage taskRepository = new TaskFileStorage(TASKS_FILE_PATH);

TaskManager taskManager = new TaskManager(idGenerator, taskRepository);
ArgumentProcessor argumentProcessor = new ArgumentProcessor(taskManager);

argumentProcessor.HandleCommandArgumens(args);
