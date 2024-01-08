/// ======================================================================
///		CheetahToolbox: (https://github.com/CraigCraig/CheetahToolbox)
///				Project:  Craig's CheetahToolbox a Swiss Army Knife
///
///
///			Author: Craig Craig (https://github.com/CraigCraig)
///		License:     MIT License (http://opensource.org/licenses/MIT)
/// ======================================================================
namespace CheetahToolbox;

#if WINDOWS
using Registry;
using Installer;
#endif
using Applications;
using Commands;
using Packages;

/// <summary>
/// <br>Contains all the managers and context for the toolbox.</br>
/// <br>Managers are used to manage the state of the system.</br>
/// <br>Contexts are used to provide information about the system.</br>
/// </summary>
public class ToolboxContext
{
    #region Core Managers
    public CheetahToolbox Toolbox;
#if WINDOWS
    public RegistryManager Registry;
#endif
    public EnvironmentManager Environment;
#if WINDOWS
    public ApplicationManager Applications;
    public InstallManager Installer;
#endif
    public ModuleManager Modules;
    public CommandManager Commands;
    #endregion

    #region Package Managers
#if WINDOWS
    /// <summary>
    /// Package Managers
    /// </summary>
    public PackageManagers Packages;
    public struct PackageManagers(ToolboxContext context)
    {
        public ChocolateyManager Chocolatey = new(context);
        public WingetManager Winget = new(context);
        public ScoopManager Scoop = new(context);
        public CygwinManager Cygwin = new(context);
        public NpmManager Npm = new(context);
        public YarnManager Yarn = new(context);

        public readonly void Update()
        {
            if (ChocolateyManager.IsInstalled)
            {
                Chocolatey.Update();
            }

            if (ScoopManager.IsInstalled)
            {
                Scoop.Update();
            }

            if (WingetManager.IsInstalled)
            {
                Winget.Update();
            }

            if (NpmManager.IsInstalled)
            {
                Npm.Update();
            }

            if (YarnManager.IsInstalled)
            {
                Yarn.Update();
            }
        }
    }
#endif
    #endregion

    public ToolboxContext(CheetahToolbox toolbox)
    {
        Toolbox = toolbox;
#if WINDOWS
        Registry = new(this);
#endif
        Environment = new(this);
#if WINDOWS
        Applications = new(this);
        Installer = new(this);
#endif
        Modules = new(this);
        Commands = new(this);
#if WINDOWS
        Packages = new(this);
#endif
    }
}