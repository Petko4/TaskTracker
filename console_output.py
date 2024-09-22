class ConsoleOutput:
    help_template = """
Welcome to Task tracker application.
commands:
    add "task description" - create a new task with TODO status
    delete <id> - delete the task
"""

    new_task_template = """Task added successfully (ID: {0})"""
    delete_task_template_success = "The task has been successfully deleted."
    delete_task_template_task_not_found = "The task with ID: {0} not found."
    delete_task_template_value_error = "Provide a task ID as a second parameter."

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
    def delete_task_output_task_not_found(task_id):
        print(ConsoleOutput.delete_task_template_task_not_found.format(task_id))

    @staticmethod
    def delete_task_value_error():
        print(ConsoleOutput.delete_task_template_value_error)