namespace WinToolbox;

using CheeseyUtils;

internal class PluginManager
{
    public static void Initialize()
    {
        Log.Info("PluginManager Initialized");
    }
}

/// <summary>
/// Base class for plugins.
/// </summary>
internal class Plugin
{
    public string Name { get; private set; } = string.Empty;

    public Plugin(string name)
    {
        Name = name;
    }
}