using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace TaskTracker
{
    internal class ArgumentProcessor
    {
        private TaskManager _taskManager;
        public ArgumentProcessor(TaskManager taskManager) {
            _taskManager = taskManager;
        }


       
        public void HandleCommandArgumens(string[] args)
        {

            if (args.Length == 1)
            {
                if (args[0] == "list")
                {
                    ProcessListArgument();     
                    return;  
                }
            }
            
            if (args.Length == 2)
            {
                if (args[0] == "add" && args[1] is string)
                {
                    ProcessAddArgument(args[1]);
                    return;
                }

                int id;
                if (args[0] == "delete" && int.TryParse(args[1], out id) )
                {
                    ProcessDeleteArgument(id);
                    return;
                }
                if (args[0].StartsWith("mark-") && int.TryParse(args[1], out id))
                {
                    ProcessUpdateStatusArgument(args[0], id);
                    return;
                }
                if (args[0] == "list")
                {
                    ProcessListFilterArgument(args[1]);
                    return;
                }
            }

            if (args.Length == 3)
            {
                int id;
                if (args[0] == "update" &&  int.TryParse(args[1], out id) && args[2] is string)
                {
                    ProcessUpdateDescriptionArgument(id, args[2]);
                    return;
                }
            }

            Console.WriteLine(Messages.HelpMessage);
            return;

        }


        private void ProcessListArgument()
        {
            var tasks = _taskManager.GetTasks();
            if (tasks.Count == 0)
                Console.WriteLine(Messages.NoTasks);
            else
            {
                foreach (var task in tasks)
                    Console.WriteLine(task);
            }
        }

        private void ProcessAddArgument(string description)
        {
            int newId = _taskManager.AddTask(description);
            Console.WriteLine(string.Format(Messages.TaskAddSuccessMessage, newId));
        }

        private void ProcessDeleteArgument(int id)
        {
            try
            {
                _taskManager.DeleteTask(id);
                Console.WriteLine(Messages.TaskDeletedSuccessMessage);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

    private void ProcessUpdateStatusArgument(string statusArgument, int id)
    {
        string[] splittedStatusArgument = statusArgument.Split("mark-");
        if (splittedStatusArgument.Length < 2)
        {
            Console.WriteLine(Messages.NotValidStatus);
            return;
        }
        string inputStatus = splittedStatusArgument[1];
        Status status;
        if (inputStatus == "to-do")
            status = Status.Todo;
        else if (inputStatus == "in-progress")
            status = Status.InProgress;
        else if (inputStatus == "done")
            status = Status.Done;
        else
        {
            Console.WriteLine(Messages.NotValidStatus);
            return;
        }

        try
        {
            _taskManager.UpdateTaskStatus(id, status);
            Console.WriteLine(Messages.TaskStatusUpdateSuccessMessage);
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message, e);
        }
        return;
    }

        private void ProcessListFilterArgument(string statusArgument)
        {
            List<Task>? filteredTasks = null;
            if (statusArgument == "todo")
                filteredTasks = _taskManager.GetTasks(Status.Todo);
            if (statusArgument == "in-progress")
                filteredTasks = _taskManager.GetTasks(Status.InProgress);
            if (statusArgument == "done")
                filteredTasks = _taskManager.GetTasks(Status.Done);
            if (filteredTasks == null)
            {
                Console.WriteLine(Messages.HelpMessage);
                return;
            }
            if (filteredTasks.Count == 0)
            {
                Console.WriteLine(Messages.NoTasks + $" with {statusArgument} status");
                return;
            }
            foreach (var task in filteredTasks)
                Console.WriteLine(task);
        }

        private void ProcessUpdateDescriptionArgument(int id, string description)
        {
            try
            {
                _taskManager.UpdateTaskDescription(id, description);
                Console.WriteLine(Messages.TaskUpdateSuccesMessage);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

    }

}
 