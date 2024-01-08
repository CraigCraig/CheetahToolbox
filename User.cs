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

public static class User
{
    public static string Name
    {
        get
        {
            string? name = Environment.UserName;
            if (string.IsNullOrEmpty(name))
                name = Environment.GetEnvironmentVariable("USERNAME");
            return name ?? "";
        }
    }
}
#endif