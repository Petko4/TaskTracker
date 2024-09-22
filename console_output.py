class ConsoleOutput:
    help_template = """
Welcome to Task tracker application.
commands:
    add "task description" - create a new task with TODO status
"""

    new_task_template = """Task added successfully (ID: {0})"""

    @staticmethod
    def show_help():
        print(ConsoleOutput.help_template)

    @staticmethod
    def new_task_output(new_id):
        print(ConsoleOutput.new_task_template.format(new_id))
