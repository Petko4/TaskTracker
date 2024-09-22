from datetime import datetime
from enum import StrEnum


class Task:
    def __init__(self, task_id, description, status, created_at=datetime.now(), updated_at=datetime.now()):
        self._id = task_id
        self._description = description
        self._status = status
        self._created_at = created_at
        self._updated_at = updated_at

    def set_update_at(self):
        self._updated_at = datetime.now()

    def set_description(self, description):
        self.set_update_at()
        self._description = description

    def set_status(self, status):
        self.set_update_at()
        self._status = status

    def get_id(self):
        return self._id

    def to_dict(self):
        return {
            "id": self._id,
            "description": self._description,
            "status": self._status,
            "created_at": self._created_at.isoformat(),
            "updated_at": self._updated_at.isoformat()
        }

    @classmethod
    def from_dict(cls, data):
        return cls(data["id"],
                   data["description"],
                   data["status"],
                   datetime.fromisoformat(data["created_at"]),
                   datetime.fromisoformat(data["updated_at"]))


class Status(StrEnum):
    TODO = "todo",
    IN_PROGRESS = "in-progress",
    DONE = "done"

