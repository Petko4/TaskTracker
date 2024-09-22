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
        print("in parse input")
        print(self._args[1])
        if self._args[1] == Action.ADD and isinstance(self._args[2], str):
            task_id = self._task_manager.create_new_task(self._args[2])
            ConsoleOutput.new_task_output(task_id)


class Action(StrEnum):
    ADD = "add",
