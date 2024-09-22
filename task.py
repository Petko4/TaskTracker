from datetime import datetime
from enum import StrEnum


class Task:
    def __init__(self, task_id, description, status):
        self._id = task_id
        self._description = description
        self._status = status
        self._created_at = datetime.now()
        self._updated_at = datetime.now()

    def set_update_at(self):
        self._updated_at = datetime.now()

    def set_description(self, description):
        self.set_update_at()
        self._description = description

    def set_status(self, status):
        self.set_update_at()
        self._status = status

    def to_dict(self):
        return {
            "id": self._id,
            "description": self._description,
            "status": self._status,
            "created_at": self._created_at.isoformat(),
            "updated_at": self._updated_at.isoformat()
        }


class Status(StrEnum):
    TODO = "todo",
    IN_PROGRESS = "in-progress",
    DONE = "done"

