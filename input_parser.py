from enum import StrEnum
from task_manager import TaskManager
from repository import JSONFileTaskRepository, FileIdRepository
from console_output import ConsoleOutput


class InputParser:
    def __init__(self, args):
        self._args = args
        self._task_manager = TaskManager(task_repository=JSONFileTaskRepository("tasks.json"),
                                         id_repository=FileIdRepository("last_id.json"),
                                         )

    def parse_input(self):
        try:
            if self._args[1] == Action.ADD and isinstance(self._args[2], str):
                task_id = self._task_manager.create_new_task(self._args[2])
                ConsoleOutput.new_task_output(task_id)

            elif self._args[1] == Action.DELETE and self._args[2]:
                try:
                    task_id = int(self._args[2])
                    if self._task_manager.delete_task(task_id):
                        ConsoleOutput.delete_task_output_success()
                    else:
                        ConsoleOutput.task_not_found(task_id)

                except ValueError:
                    ConsoleOutput.task_value_error()
            elif self._args[1] == Action.UPDATE and self._args[2] and isinstance(self._args[3], str):
                try:
                    task_id = int(self._args[2])
                    new_description = self._args[3]
                    if self._task_manager.update_task(task_id, new_description):
                        ConsoleOutput.update_task_success()
                    else:
                        ConsoleOutput.task_not_found(task_id)
                except ValueError:
                    ConsoleOutput.task_value_error()
            elif self._args[1] == Action.LIST:
                tasks = self._task_manager.get_all_tasks()
                ConsoleOutput.list_tasks(tasks)
        except:
            ConsoleOutput.show_help()
        else:
            ConsoleOutput.show_help()


class Action(StrEnum):
    ADD = "add",
    DELETE = "delete"
    UPDATE = "update"
    LIST = "list"
