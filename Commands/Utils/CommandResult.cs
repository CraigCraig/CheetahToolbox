/// ======================================================================
///		CheetahToolbox: (https://github.com/CraigCraig/CheetahToolbox)
///				Project:  Craig's CheetahToolbox a Swiss Army Knife
///
///
///			Author: Craig Craig (https://github.com/CraigCraig)
///		License:     MIT License (http://opensource.org/licenses/MIT)
/// ======================================================================
namespace CheetahToolbox.Commands;

public class CommandResult(bool success = true, string message = "")
{
    public bool Success { get; private set; } = success;
    public string Message { get; private set; } = message;
}