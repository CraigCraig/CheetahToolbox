namespace CheetahToolbox.Modules.Core.Commands;

using global::CheetahToolbox.Commands;

public class ColorCommand() : CommandBase("color", "Color Changer")
{
    private ConsoleColor consoleColor;
    public override CommandResult Execute(CommandContext context)
    {
        string[] args = context.Args;
        if (args[0].Contains("help"))
        {
            Console.WriteLine("Simple color changer! provides a lil protogen aswell :3. see next line for available colors.");
            Console.WriteLine("Black, Blue, Cyan, DarkBlue, DarkCyan, DarkGray, DarkGreen, DarkMagenta, DarkRed, DarkYellow, Gray, Green, Magenta, Red, White, Yellow ");
            return new CommandResult(true);
        }
        if (args.Length == 1)
        {
            foreach (var item in args)
            {
                try
                {
                    consoleColor = (ConsoleColor)Enum.Parse(typeof(ConsoleColor), item, true);
                }
                catch (Exception)
                {
                    Console.WriteLine("Not a color silly!!");
                    return new CommandResult(true);
                }
            }
        }
        else if (args.Length >= 2)
        {
            Console.WriteLine("Cant change to more than one color!!");
            return new CommandResult(true);
        }
        else if (args.Length == 0)
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("ermmmm...");
            return new CommandResult(true);
        }
        Console.ForegroundColor = consoleColor;
        Console.WriteLine("changed color to: " + consoleColor + "!!!");
        Console.WriteLine("\r\n\r\n ▄▄▄▄▄▄▀▀▀▀▀▀▀▄▄\r\n █     ▀▄   ▄▀ █▀▀▄▄\r\n   █    █▀ ▀▄▀ ▄▀     ▀▀▄▄\r\n     █    ▀▄█ ▄▀           ▀▀▄ \r\n      █ ▄▄  █ █  █▀█      ▀█ █ \r\n       ██ ▀▀▄▄█  ▀ ▀         █\r\n         ▀█ █   █     ▀▄▄▀▀▄▄█\r\n            ▀█   █▄▄▄▄▄▄▄▄▄▄▄█ ");
        return new CommandResult(true);
    }
}