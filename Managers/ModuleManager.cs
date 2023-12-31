namespace CheetahToolbox.Managers;

using Modules;
using Commands;
using System.Reflection;

public class ModuleManager : ManagerBase
{
    public List<ModuleBase> Modules { get; private set; } = [];

    public int ModuleCount => Modules.Count;

    public int CommandCount
    {
        get
        {
            int count = 0;
            foreach (ModuleBase module in Modules)
            {
                count += module.Commands.Count;
            }
            return count;
        }
    }

    public ModuleManager(ToolboxContext context) : base(context, "Modules")
    {
        string modulesPath = FolderPaths.Modules;
        if (!Directory.Exists(modulesPath)) _ = Directory.CreateDirectory(modulesPath);

        foreach (string entry in Directory.GetFiles(modulesPath))
        {
            if (entry.EndsWith(".module.dll", StringComparison.OrdinalIgnoreCase)) _ = Assembly.LoadFile(entry);
        }

        foreach (Assembly assembly in AppDomain.CurrentDomain.GetAssemblies())
        {
            Type[] types = assembly.GetTypes();
            foreach (Type type in types)
            {
                if (type.BaseType == null || type.BaseType.FullName == null) continue;
                if (type.BaseType.FullName.Equals(typeof(ModuleBase).FullName, StringComparison.OrdinalIgnoreCase))
                {
                    if (type == null || string.IsNullOrEmpty(type.FullName)) continue;
                    if (assembly.FullName == null) continue;
                    if (Activator.CreateInstance(type, context) is ModuleBase module)
                    {
                        //module.Initialize();
                        Modules.Add(module);

                        // Add Commands from Modules Namespace
                        foreach (Type type2 in types)
                        {
                            if (type2.BaseType == null || type2.BaseType.FullName == null) continue;
                            if (!type2.BaseType.FullName.Equals(typeof(CommandBase).FullName, StringComparison.OrdinalIgnoreCase)) continue;
                            {
                                if (type2 == null || string.IsNullOrEmpty(type2.FullName)) continue;
                                if (Activator.CreateInstance(type2, module) is not CommandBase command) continue;
                                module.Commands.Add(command);
                            }
                        }
                    }
                }
            }
        }
    }

    public ModuleBase? GetModule(string command)
    {
        foreach (ModuleBase module in Modules)
        {
            if (module.Info.Name.Equals(command, StringComparison.OrdinalIgnoreCase))
                return module;
        }
        return null;
    }

    internal CommandResult? ExecuteCommand(string command, string[] cmdArgs)
    {
        // TODO: Split commands by | and execute them in order, allowing for piping
        if (command.StartsWith('?'))
        {
            command = command[1..];
            if (string.IsNullOrEmpty(command)) return new(false, "No Module Specified");

            StringBuilder response = new();

            _ = response.Append($"Modules");

            return new(true, response.ToString());
        }

        foreach (ModuleBase module in Modules)
        {
            foreach (CommandBase cmd in module.Commands)
            {
                if (cmd.Name != null && !string.IsNullOrEmpty(cmd.Name))
                {
                    if (cmd.Name.ToLowerInvariant().Equals(command.ToLowerInvariant(), StringComparison.OrdinalIgnoreCase))
                        return cmd.Execute(command, cmdArgs);
                }
            }
        }
        return new(false, $"Command Not Found: {command}");
    }
}