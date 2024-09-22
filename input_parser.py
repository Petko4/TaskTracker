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
                        ConsoleOutput.delete_task_output_task_not_found(task_id)

                except ValueError:
                    ConsoleOutput.delete_task_value_error()
        except:
            ConsoleOutput.show_help()


class Action(StrEnum):
    ADD = "add",
    DELETE = "delete"
