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

using CheetahUtils;
using System;

public static class ShortcutManager
{
    public static void Scan()
    {
        Console.WriteLine("Shortcut Scan");

        string startMenuPath = Environment.GetFolderPath(Environment.SpecialFolder.Programs);
        Console.WriteLine($"Start Menu Path: {startMenuPath}");

        string[] startMenuFiles = Directory.GetFiles(startMenuPath, "*.lnk", SearchOption.AllDirectories);
        foreach (string file in startMenuFiles)
        {
            //Console.WriteLine($"Start Menu File: {file}");
            if (ShortcutUtils.IsValid(file))
                Console.WriteLine("File is a valid shortcut");
        }

        Console.WriteLine("Shortcut Scan Done");
    }
}
#endif