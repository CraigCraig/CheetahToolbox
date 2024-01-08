/// ======================================================================
///		CheetahToolbox: (https://github.com/CraigCraig/CheetahToolbox)
///				Project:  Craig's CheetahToolbox a Swiss Army Knife
///
///
///			Author: Craig Craig (https://github.com/CraigCraig)
///		License:     MIT License (http://opensource.org/licenses/MIT)
/// ======================================================================
namespace CheetahToolbox.Commands;

using Modules;
using System;
using System.Reflection;

public class CommandManager : ManagerBase
{
    public readonly List<CommandBase> Commands = [];

    private readonly List<string> attributeCache = [];
    private readonly List<string> typeCache = [];

    private List<Type> rootTypes = [];
    private readonly List<CommandAttribute> attributes = [];
    public void CacheModule(ModuleBase module)
    {
        Assembly assembly = module.GetType().Assembly;
#if DEBUG && VERBOSE
        Log.Write($"Caching Module: {module.Name}");
        Log.Write($"\tAssembly: {assembly.FullName}");
#endif

        rootTypes = [.. assembly.GetTypes()];
        attributes.Clear();

        foreach (Type type in rootTypes.Where(t => t.BaseType != null && t.BaseType.Equals(typeof(CommandBase))))
        {
            if (type.DeclaringType != null) // This is the parent of the command
            {
                Log.Write($"Command Group: {type.DeclaringType.Name} -> {type.Name}");
            }
            else // This indicates this is a root command
            {
                Log.Write($"Command Root: {type.Name}");
            }

            // TODO: Check if parent is a command

            // TODO: Get command attribute information

            foreach (CommandAttribute attribute in GetCommandAttributes(type))
            {
                if (string.IsNullOrEmpty(attribute.Name))
                {
                    Log.Warn("Attribute With No Name Detected");
                }
                else if (attributeCache.Contains(attribute.Name))
                {
                    Log.Warn($"Duplicate Attribute Detected: {attribute.Name}");
                }
                else
                {
                    Log.Write($"Attribute: {attribute.Name}");
                    Log.Write($"Aliases: {string.Join(",", attribute.Aliases)}");
                    Log.Write($"Description: {attribute.Description}");

                    attributes.Add(attribute);
                }
            }
        }
#if DEBUG && VERBOSE
        //Log.Write($"Cached {rootTypes.Count} Root Types");
        Log.Write($"Cached {attributes.Count} Attributes");
#endif
    }

    public List<CommandAttribute> GetCommandAttributes(Type type)
    {
        List<CommandAttribute> temp = [];

        temp.AddRange(type.GetCustomAttributes().OfType<CommandAttribute>());

        foreach (MethodInfo method in type.GetMethods())
        {
            temp.AddRange(method.GetCustomAttributes().OfType<CommandAttribute>());
        }

        return temp;
    }

    public CommandManager(ToolboxContext context) : base(context, "Commands")
    {
        //Commands.Clear();
        //attributeCache.Clear();
        //typeCache.Clear();

        // Cache Modules
        foreach (ModuleBase module in context.Modules.Modules)
        {
            CacheModule(module);
        }

        //// Cache Commands
        //foreach (CommandAttribute attribute in attributes)
        //{
        //    Log.Write($"Command Attribute: {attribute.Name}");
        //}

        //Log.Write($"Attributes: {string.Join(", ", attributes)}");
    }

    public CommandResult? HandleCommand(string command, string[] arguments)
    {
        // TODO: Handle Command Groups

        if (string.IsNullOrEmpty(command))
            return new CommandResult(false, "Command is null or empty");

        Log.Write($"Commands:\n{string.Join("\n", Commands)}");

        foreach (Type type in rootTypes)
        {
            Log.Write(type.Name);
        }

        //foreach (CommandGroup group in Groups)
        //{
        //    Log.Write($"CommandGroup: {group.Name}");
        //}


        foreach (CommandBase cmd in Commands)
        {
            if (cmd.Name == command)
                Log.Write($"{cmd.Name}");
        }

        return new CommandResult(true, "reworking commands");
        //return new CommandResult(false, $"Command not found: {command}");
    }

    //public void AddCommand(CommandBase command) => _commands.Add(command);
}