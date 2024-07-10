using ToyRobotSimulator;

string command = "";
int x, y;
Direction direction;
string[] data;
Console.WriteLine("This is a Toy Robot Simulator. The robot moves in a 5x5 grid depending on the direction it is facing.");
Console.WriteLine("Please use the commands below:");
Console.ForegroundColor = ConsoleColor.Cyan;
Console.WriteLine("PLACE X,Y,F");
Console.ForegroundColor = ConsoleColor.White;
Console.WriteLine("Put the toy robot on the table in position X,Y and facing NORTH, SOUTH, EAST or WEST");
Console.ForegroundColor = ConsoleColor.Cyan;
Console.WriteLine("LEFT");
Console.ForegroundColor = ConsoleColor.White;
Console.WriteLine("Turns the robot counterclockwise.");
Console.ForegroundColor = ConsoleColor.Cyan;
Console.WriteLine("RIGHT");
Console.ForegroundColor = ConsoleColor.White;
Console.WriteLine("Turns the robot clockwise.");
Console.ForegroundColor = ConsoleColor.Cyan;
Console.WriteLine("MOVE");
Console.ForegroundColor = ConsoleColor.White;
Console.WriteLine("Moves the robot forward depending on the direction its facing.");
Console.ForegroundColor = ConsoleColor.Cyan;
Console.WriteLine("REPORT");
Console.ForegroundColor = ConsoleColor.White;
Console.WriteLine("Displays the current position and direction of the robot.");
Robot robot = new Robot();

while (true)
{
    command = Console.ReadLine();

    if (command.Contains("PLACE", StringComparison.OrdinalIgnoreCase))
    {
        data = command.Replace("PLACE ", "").Split(',');
        if (data.Length == 3)
        {
            if (!Int32.TryParse(data[0], out x))
            {
                Console.WriteLine("X coordinate input error; Try a number from 0 to 4");
            }
            if (!Int32.TryParse(data[1], out y))
            {
                Console.WriteLine("Y coordinate input error; Try a number from 0 to 4");
            }
            if (!Enum.TryParse(data[2], out direction))
            {
                Console.WriteLine("Direction input error; Try NORTH, EAST, SOUTH OR WEST");
            }
            robot.SetPosition(x, y, direction);
        }
        else
        {
            Console.WriteLine("Wrong format!");
        }
    }
    else if (robot.isPlaced())
    {
        if (command == "MOVE")
        {
            robot.MovePosition();
        }
        else if (command == "LEFT")
        {
            robot.TurnLeft();
        }
        else if (command == "RIGHT")
        {
            robot.TurnRight();
        }
        else if (command == "REPORT")
        {
            robot.ReportPosition();
        }
    }
    else
    {
        Console.WriteLine("Robot is not placed.");
    }
}

