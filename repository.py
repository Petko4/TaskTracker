import json
from abc import ABC, abstractmethod

from task import Task


class TaskRepository(ABC):
    @abstractmethod
    def save_task(self, task):
        pass

    @abstractmethod
    def delete_task(self, task_id):
        pass


class JSONFileTaskRepository(TaskRepository):
    def __init__(self, filename):
        self._filename = filename

    def _load_tasks(self):
        try:
            with open(self._filename, "r") as file:
                return [Task.from_dict(task) for task in json.load(file)]
        except FileNotFoundError:
            return []

    def _save_tasks(self, tasks):
        with open(self._filename, "w") as file:
            json.dump(tasks, default=lambda o: o.to_dict(), indent=4, fp=file)

    def save_task(self, task):
        tasks = self._load_tasks()
        tasks.append(task)
        self._save_tasks(tasks)

    def delete_task(self, task_id):
        tasks = self._load_tasks()
        filtered_tasks = [task for task in tasks if task.get_id() != task_id]
        self._save_tasks(filtered_tasks)
        return len(tasks) > len(filtered_tasks)


class IdRepository(ABC):
    @staticmethod
    @abstractmethod
    def get_next_id():
        pass


class FileIdRepository(IdRepository):
    def __init__(self, filename):
        self._filename = filename

    def _load_last_id(self):
        try:
            with open(self._filename, "r") as file:
                last_id = json.load(file).get("last_id")
                if last_id:
                    return last_id
                else:
                    return 0
        except FileNotFoundError:
            return 0

    def _save_last_id(self, last_id):

        with open(self._filename, "w") as file:
            json.dump({"last_id": last_id}, file)

    def get_next_id(self):
        last_id = self._load_last_id()
        new_id = last_id + 1
        self._save_last_id(new_id)
        return new_id
