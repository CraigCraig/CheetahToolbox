/// ======================================================================
///		CheetahToolbox: (https://github.com/CraigCraig/CheetahToolbox)
///				Project:  Craig's CheetahToolbox a Swiss Army Knife
///
///
///			Author: Craig Craig (https://github.com/CraigCraig)
///		License:     MIT License (http://opensource.org/licenses/MIT)
/// ======================================================================
namespace CheetahToolbox.Commands;

/// <summary>
/// </summary>
[AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, Inherited = false)]
public class CommandAttribute : Attribute
{
    public string Name;
    public string[] Aliases;
    public string Description;
    public bool Default;

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE0290:Use primary constructor", Justification = "Breaks Reflection")]
    public CommandAttribute(string? name = null, string[]? aliases = null, string? description = null, bool defaultV = false) : base()
    {
        Name = name ?? string.Empty;
        Aliases = aliases ?? [];
        Description = description ?? string.Empty;
        Default = defaultV;
    }
}