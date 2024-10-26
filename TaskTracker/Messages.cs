namespace TaskTracker
{
    internal static class Messages
    {
        public const string HelpMessage = "Task Tracker Help\n\n " +
            "   Actions \t\t\tArguments\n" +
            " --------------------------------------------------------------------\n" +
            " - Add task  \t\t\tadd \"<task description>\"\n" +
            " - Update task description\tupdate <id> \"<new descripton>\"\n" +
            " - Delete task  \t\tdelete <id>\n" +
            " - Update task status  \t\tmark-<in-progress | todo | done> <id>\n" +
            " - List all tasks  \t\tlist\n" +
            " - List tasks by status  \tlist <todo | in-progress | done>";

        public const string TaskAddSuccessMessage = "Task added successfully (ID: {0}).";
        public const string TaskDeletedSuccessMessage = "Task deleted successfully.";
        public const string TaskNotFound = "Task with ID: {0} not found.";
        public const string NotValidStatus = "This is not valid status.";
        public const string TaskStatusUpdateSuccessMessage = "Task status has been updated.";
        public const string TaskUpdateSuccesMessage = "Task has been updated.";
        public const string NoTasks = "There are not any tasks";
    }
}
