from repository import TaskRepository, FileIdRepository
from task import Task, Status


class TaskManager:
    def __init__(self, task_repository: TaskRepository, id_repository: FileIdRepository):
        self._task_repository = task_repository
        self._id_repository = id_repository

    def create_new_task(self, description):
        new_id = self._id_repository.get_next_id()
        new_task = Task(new_id, description, Status.TODO)
        self._task_repository.save_task(new_task)
        return new_id
