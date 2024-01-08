/// ======================================================================
///		CheetahToolbox: (https://github.com/CraigCraig/CheetahToolbox)
///				Project:  Craig's CheetahToolbox a Swiss Army Knife
///
///
///			Author: Craig Craig (https://github.com/CraigCraig)
///		License:     MIT License (http://opensource.org/licenses/MIT)
/// ======================================================================
#if WINDOWS
namespace CheetahToolbox;

public static class Machine
{
    public static string Name
    {
        get
        {
            string? name = Environment.MachineName;
            if (string.IsNullOrEmpty(name))
                name = Environment.GetEnvironmentVariable("COMPUTERNAME");
            return name ?? "";
        }
    }

    public static string DomainName
    {
        get
        {
            string? name = Environment.UserDomainName;
            if (string.IsNullOrEmpty(name))
                name = Environment.GetEnvironmentVariable("USERDOMAIN");
            return name ?? "";
        }
    }

    public static string GetNativeVariable(string name) => Environment.GetEnvironmentVariable(name) ?? "";


}
#endif