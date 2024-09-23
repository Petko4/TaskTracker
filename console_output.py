class ConsoleOutput:
    help_template = """
Welcome to Task tracker application.
commands:
    add "task description" - create a new task with TODO status
    delete <id> - delete the task
    update <id> "new description" - update existing task
    list - show all tasks
"""

    new_task_template = """Task added successfully (ID: {0})"""
    delete_task_template_success = "The task has been successfully deleted."
    task_not_found_template = "The task with ID: {0} not found."
    task_template_value_error = "Provide a task ID as a second parameter."
    update_task_template_success = "The task has been successfully updated."

    @staticmethod
    def show_help():
        print(ConsoleOutput.help_template)

    @staticmethod
    def new_task_output(new_id):
        print(ConsoleOutput.new_task_template.format(new_id))

    @staticmethod
    def delete_task_output_success():
        print(ConsoleOutput.delete_task_template_success)

    @staticmethod
    def task_not_found(task_id):
        print(ConsoleOutput.task_not_found_template.format(task_id))

    @staticmethod
    def task_value_error():
        print(ConsoleOutput.task_template_value_error)

    @staticmethod
    def update_task_success():
        print(ConsoleOutput.update_task_template_success)

    @staticmethod
    def list_tasks(tasks):
        [print(f"{task.get_id()} \t\"{task.get_description()}\" \t{task.get_status()}") for task in tasks]
