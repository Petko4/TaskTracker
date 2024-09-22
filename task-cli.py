import sys
from console_output import ConsoleOutput
from input_parser import InputParser


def run():
    if len(sys.argv) <= 1:
        ConsoleOutput.show_help()
    else:
        ip = InputParser(sys.argv)
        ip.parse_input()


if __name__ == "__main__":
    run()
